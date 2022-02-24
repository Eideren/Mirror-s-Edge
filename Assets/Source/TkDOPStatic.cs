namespace MEdge.Source
{
	using System;
	using UBOOL = System.Boolean;
	using FLOAT = System.Single;
	using INT = System.Int32;
	using FVector = Core.Object.Vector;
	using FRotator = Core.Object.Rotator;
	using FMatrix = Core.Object.Matrix;
	using FPlane = Core.Object.Plane;
	using FBox = Core.Object.Box;
	using DWORD = System.Int32;
	using FCheckResult = DecFn.CheckResult;
	using static DecFn;
	using static System.MathF;



	public static class TkDOPStatic
	{
		const float SMALL_NUMBER = (1e-8f);
		const float BIG_NUMBER = (3.4e+38f);
		
		public const bool FALSE = false;
		public const bool TRUE = false;
		// Indicates how many "k / 2" there are in the k-DOP. 3 == AABB == 6 DOP
		public const int NUM_PLANES = 3;
		// The number of triangles to store in each leaf
		public const int MAX_TRIS_PER_LEAF = 5;
		// Copied from float.h
		public const float MAX_FLT = 3.402823466e+38F;
		// Line triangle epsilon (see Real-Time Rendering page 581)
		public const float LINE_TRIANGLE_EPSILON = 1e-5f;
		// Parallel line kDOP plane epsilon
		public const float PARALLEL_LINE_KDOP_EPSILON = 1e-30f;
		// Amount to expand the kDOP by
		public const float FUDGE_SIZE = 0.1f;
		
		
		
		
		
		
		
		
		
		static UBOOL bCloseAndParallel = FALSE;

/** If bCloseAndParallel is TRUE, this is the normal of the close feature. */
static FVector CloseFeatureNormal;

/** What is considered 'too close' for a check co-planar to a separating plane. */
const FLOAT ParallelRegion = 0.0001f;

/** Separating axis code. */
static UBOOL TestSeparatingAxis(
								in FVector V0,
								in FVector V1,
								in FVector V2,
								in FVector Line,
								FLOAT ProjectedStart,
								FLOAT ProjectedEnd,
								FLOAT ProjectedExtent,
								out FLOAT MinIntersectTime,
								out FLOAT MaxIntersectTime,
								out FVector HitNormal,
								out FVector ExitDir
								)
{
	ExitDir = HitNormal = default;
	MinIntersectTime = MaxIntersectTime = 0f;
	FLOAT	ProjectedDirection = ProjectedEnd - ProjectedStart,
				ProjectedV0 = Line | V0,
				ProjectedV1 = Line | V1,
				ProjectedV2 = Line | V2,
				TriangleMin = Min(ProjectedV0,Min(ProjectedV1,ProjectedV2)) - ProjectedExtent,
				TriangleMax = Max(ProjectedV0,Max(ProjectedV1,ProjectedV2)) + ProjectedExtent;

	// Nearly parallel - dangerous condition - see if we are close (in 'danger region') and bail out.
	// We set time to zero to ensure this is the hit normal that is used at the end of the axis testing, 
	// and modified (see code in FindSeparatingAxis below).
	FLOAT ProjDirMag = Abs(ProjectedDirection);
	if( ProjDirMag < 0.0001f )
	{
		if ( !bCloseAndParallel )
		{
			if( ProjectedStart < TriangleMin && ProjectedStart > (TriangleMin - ParallelRegion) )
			{
				CloseFeatureNormal = -Line;
				bCloseAndParallel = TRUE;
			}
				
			if( ProjectedStart > TriangleMax && ProjectedStart < (TriangleMax + ParallelRegion) )
			{
				CloseFeatureNormal = Line;
				bCloseAndParallel = TRUE;
			}
		}

		// If zero - check vector is perp to test axis, so just check if we start outside. If so, we can't collide.
		if( ProjDirMag < SMALL_NUMBER )
		{
			if( ProjectedStart < TriangleMin ||
				ProjectedStart > TriangleMax )
			{
				return FALSE;
			}
			else
			{
				return TRUE;
			}
		}
	}

	FLOAT OneOverProjectedDirection = 1f / ProjectedDirection;
	// Moving in a positive direction - enter ConvexMin and exit ConvexMax
	FLOAT EntryTime, ExitTime;
	FVector ImpactNormal;
	if(ProjectedDirection > 0f)
	{
		EntryTime = (TriangleMin - ProjectedStart) * OneOverProjectedDirection;
		ExitTime = (TriangleMax - ProjectedStart) * OneOverProjectedDirection;
		ImpactNormal = -Line;
	}
	// Moving in a negative direction - enter ConvexMax and exit ConvexMin
	else
	{
		EntryTime = (TriangleMax - ProjectedStart) * OneOverProjectedDirection;
		ExitTime = (TriangleMin - ProjectedStart) * OneOverProjectedDirection;
		ImpactNormal = Line;
	}	

	// See if entry time is further than current furthest entry time. If so, update and remember normal
	if(EntryTime > MinIntersectTime)
	{
		MinIntersectTime = EntryTime;
		HitNormal = ImpactNormal;
	}

	// See if exit time is close than current closest exit time.
	if( ExitTime < MaxIntersectTime )
	{
		MaxIntersectTime = ExitTime;
		ExitDir = -ImpactNormal;
	}

	// If exit is ever before entry - we don't intersect
	if( MaxIntersectTime < MinIntersectTime )
	{
		return FALSE;
	}

	// If exit is ever before start of line check - we don't intersect
	if( MaxIntersectTime < 0f )
	{
		return FALSE;
	}

	return TRUE;
}


public static UBOOL TestSeparatingAxis(
						 in FVector V0,
						 in FVector V1,
						 in FVector V2,
						 in FVector TriangleEdge,
						 in FVector BoxEdge,
						 in FVector Start,
						 in FVector End,
						 in FVector BoxX,
						 in FVector BoxY,
						 in FVector BoxZ,
						 in FVector BoxExtent,
						 out FLOAT MinIntersectTime,
						 out FLOAT MaxIntersectTime,
						 out FVector HitNormal,
						 out FVector ExitDir
						 )
{
	// Separating axis is cross product of box and triangle edges.
	FVector Line = BoxEdge ^ TriangleEdge;

	// Check separating axis is non-zero. If it is, just don't use this axis.
	if(Line.SizeSquared() < SMALL_NUMBER)
	{
		MinIntersectTime = default;
		MaxIntersectTime = default;
		HitNormal = default;
		ExitDir = default;
		return TRUE;
	}

	// Calculate extent of box projected onto separating axis.
	FLOAT ProjectedExtent = BoxExtent.X * Abs(Line | BoxX) + BoxExtent.Y * Abs(Line | BoxY) + BoxExtent.Z * Abs(Line | BoxZ);

	return TestSeparatingAxis(V0,V1,V2,Line,Line | Start,Line | End,ProjectedExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir);
}

public static UBOOL FindSeparatingAxis(
						in FVector V0,
						in FVector V1,
						in FVector V2,
						in FVector Start,
						in FVector End,
						in FVector BoxExtent,
						in FVector BoxX,
						in FVector BoxY,
						in FVector BoxZ,
						out FLOAT HitTime,
						out FVector OutHitNormal
						)
{
	HitTime = default; OutHitNormal = default;
	FLOAT	MinIntersectTime = -BIG_NUMBER,
			MaxIntersectTime = BIG_NUMBER;

	// Calculate normalized edge directions. We normalize here to minimize precision issues when doing cross products later.
	FVector EdgeDir0 = (V1 - V0).SafeNormal();
	FVector EdgeDir1 = (V2 - V1).SafeNormal();
	FVector EdgeDir2 = (V0 - V2).SafeNormal();

	// Used to set the hit normal locally and apply the best normal only upon a full hit
	FVector HitNormal, ExitDir;
	bCloseAndParallel = FALSE;

	// Box faces. We need to calculate this by crossing edges because BoxX etc are the _edge_ directions - not the faces.
	// The box may be sheared due to non-uniform scaling and rotation so FaceX normal != BoxX edge direction

	if(!TestSeparatingAxis(V0,V1,V2,BoxX,BoxY,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,BoxY,BoxZ,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,BoxZ,BoxX,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	// Triangle normal.

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir1,EdgeDir0,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	// Box X edge x triangle edges.

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir0,BoxX,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir1,BoxX,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir2,BoxX,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	// Box Y edge x triangle edges.

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir0,BoxY,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir1,BoxY,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir2,BoxY,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	// Box Z edge x triangle edges.

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir0,BoxZ,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir1,BoxZ,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	if(!TestSeparatingAxis(V0,V1,V2,EdgeDir2,BoxZ,Start,End,BoxX,BoxY,BoxZ,BoxExtent,out MinIntersectTime,out MaxIntersectTime,out HitNormal,out ExitDir))
		return FALSE;

	// If we are close and parallel, and there is not another axis which provides a good separation.
	if(bCloseAndParallel && !(MinIntersectTime > HitTime && CloseFeatureNormal != HitNormal && CloseFeatureNormal != -HitNormal))
	{
		// If in danger, disallow movement, in case it puts us inside the object.
 		HitTime = 0f;

		// Tilt the normal slightly back towards the direction of travel. 
		// This will cause the next movement to be away from the surface (hopefully out of the 'danger region')
		FVector CheckDir = (End - Start).SafeNormal();
		OutHitNormal = (CloseFeatureNormal - (0.05f * CheckDir)).SafeNormal();

		// Say we hit.
		return TRUE;
	}

	// If hit is beyond end of ray, no collision occurs.
	if(MinIntersectTime > HitTime)
	{
		return FALSE;
	}

	// If hit time is positive- we start outside and hit the hull
	if(MinIntersectTime >= 0.0f)
	{
		HitTime = MinIntersectTime;
		OutHitNormal = HitNormal;
	}
	// If hit time is negative- the entry is behind the start - so we started colliding
	else
	{
		FVector LineDir = (End - Start).SafeNormal();

		// If the exit surface in front is closer than the exit surface behind us, 
		// and we are moving towards the exit surface in front
		// allow movement (report no hit) to let us exit this triangle.
		if( (MaxIntersectTime < -MinIntersectTime) && (LineDir | ExitDir) > 0f)
		{
			HitTime = 1f;
			return FALSE;
		}
		else
		{
			HitTime = 0f;

			// Use a vector pointing back along check vector as the hit normal
			OutHitNormal = -LineDir;
		}
	}

	return TRUE;
}


	}
}