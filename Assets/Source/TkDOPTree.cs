namespace MEdge.Source
{
	using Core;
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
	using static TkDOPStatic;
	using static DecFn;
	using static DecFn.ETraceFlags;
	using static System.MathF;
	using KDOP_IDX_TYPE = System.Int32;






	public static class BuildTkDOPTree
	{
		public static TkDOPTree<T> Build<T>(UnityEngine.Mesh mesh, T provider) where T : COLL_DATA_PROVIDER_INTERFACE
		{
			array<FkDOPBuildCollisionTriangle/*<WORD>*/ > kDOPBuildTriangles = default;
			var verts = mesh.vertices;
			var indices = mesh.triangles;
			for( int subMesh = 0; subMesh < mesh.subMeshCount; subMesh++ )
			{
				var submeshDesc = mesh.GetSubMesh(subMesh);
				var end = submeshDesc.indexStart + submeshDesc.indexCount;
				for( int i = submeshDesc.indexStart; i < end; i+=3 )
				{
					kDOPBuildTriangles.Add( new FkDOPBuildCollisionTriangle(indices[i+0],
						indices[i+1],indices[i+2],/*Triangle->MaterialIndex * NumFragments + Triangle->FragmentIndex*/subMesh,
						verts[indices[i+0]].ToUnrealPos(),verts[indices[i+1]].ToUnrealPos(),verts[indices[i+2]].ToUnrealPos()));
				}
			}

			// Calculate the bounding box.

			/*FBox	BoundingBox(0);

			for(UINT VertexIndex = 0;VertexIndex < LODModels(0).NumVertices;VertexIndex++)
			{
				BoundingBox += LODModels(0).PositionVertexBuffer.VertexPosition(VertexIndex);
			}
			BoundingBox.GetCenterAndExtents(Bounds.Origin,Bounds.BoxExtent);

			// Calculate the bounding sphere, using the center of the bounding box as the origin.

			Bounds.SphereRadius = 0.0f;
			for(UINT VertexIndex = 0;VertexIndex < LODModels(0).NumVertices;VertexIndex++)
			{
				Bounds.SphereRadius = Max((LODModels(0).PositionVertexBuffer.VertexPosition(VertexIndex) - Bounds.Origin).Size(),Bounds.SphereRadius);
			}*/
			var kDOPTree = new TkDOPTree<T>();
			kDOPTree.Build(ref kDOPBuildTriangles);
			return kDOPTree;
		}
	}













	public interface COLL_DATA_PROVIDER_INTERFACE
	{
		public INT GetItemIndex(int MaterialIndex);
		public Engine.MaterialInterface GetMaterial( KDOP_IDX_TYPE MaterialIndex );
		public UBOOL ShouldCheckMaterial( INT MaterialIndex );
		public FVector GetVertex(KDOP_IDX_TYPE Index);
		public FMatrix GetLocalToWorld();
		public FMatrix GetWorldToLocal();
		public FMatrix GetLocalToWorldTransposeAdjoint();
		public FLOAT GetDeterminant();
		public TkDOPTree<COLL_DATA_PROVIDER_INTERFACE/*, DWORD*/> GetkDOPTree();
	}

	public static class FkDOPPlanes
	{
		public static FVector[] PlaneNormals = new FVector[NUM_PLANES];
	}



/**
 * Base struct for all collision checks. Holds a reference to the collision
 * data provider, which is a struct that abstracts out the access to a
 * particular mesh/primitives data
 */
public struct TkDOPCollisionCheck<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/> where COLL_DATA_PROVIDER : COLL_DATA_PROVIDER_INTERFACE
{
	/** Exposes data provider type to clients. */
	//typedef COLL_DATA_PROVIDER DataProviderType;

	/** Exposes node type to clients. */
	//typedef TkDOPNode<DataProviderType,KDOP_IDX_TYPE> NodeType;

	/** Exposes tree type to clients. */
	//typedef TkDOPTree<DataProviderType,KDOP_IDX_TYPE> TreeType;

	/** Exposes kDOP type to clients. */
	//typedef typename NodeType::kDOPType	kDOPType;

	/**
	 * Used to get access to local->world, vertices, etc. without using virtuals
	 */
	public readonly COLL_DATA_PROVIDER CollDataProvider;
	/**
	 * The kDOP tree
	 */
	public readonly TkDOPTree<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> kDOPTree;
	/**
	 * The array of the nodes for the kDOP tree
	 */
	public readonly array<TkDOPNode<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>> Nodes;
	/**
	 * The collision triangle data for the kDOP tree
	 */
	public readonly array<FkDOPCollisionTriangle/*<KDOP_IDX_TYPE>*/> CollisionTriangles;

	/**
	 * Hide the default ctor
	 */
	public TkDOPCollisionCheck(in COLL_DATA_PROVIDER InCollDataProvider)
	{
		CollDataProvider = ( InCollDataProvider );
		kDOPTree = (CollDataProvider.GetkDOPTree()) as TkDOPTree<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> ?? throw new System.Exception();
		Nodes = ( kDOPTree.Nodes );
		CollisionTriangles = ( kDOPTree.Triangles );
	}

};

public struct TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/>/* :
public TkDOPLineCollisionCheck<COLL_DATA_PROVIDER,KDOP_IDX_TYPE>*/ where COLL_DATA_PROVIDER : COLL_DATA_PROVIDER_INTERFACE
{
	public TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/> baseT;
	// Constant input vars
	public readonly FVector Extent;
	// Calculated vars
	public FVector LocalExtent;
	public FVector LocalBoxX;
	public FVector LocalBoxY;
	public FVector LocalBoxZ;

	/**
	 * Sets up the TkDOPBoxCollisionCheck structure for performing swept box checks
	 * against a kDOPTree. Initializes all of the variables that are used
	 * throughout the check.
	 *
	 * @param InStart -- The starting point of the trace
	 * @param InEnd -- The ending point of the trace
	 * @param InExtent -- The extent to check
	 * @param InTraceFlags -- The trace flags that might modify searches
	 * @param InCollDataProvider -- The struct that provides access to mesh/primitive
	 *		specific data, such as L2W, W2L, Vertices, and so on
	 * @param InResult -- The out param for hit result information
	 */
	public TkDOPBoxCollisionCheck(in FVector InStart,in FVector InEnd,
	in FVector InExtent,ETraceFlags InTraceFlags,
	in COLL_DATA_PROVIDER InCollDataProvider,ref FCheckResult InResult)
	{
		baseT = new TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/>( InStart, InEnd, InTraceFlags, InCollDataProvider, ref InResult );
		Extent = ( InExtent );
		// Move extent to local space
		LocalExtent = new FBox(-Extent,Extent).TransformBy(baseT.baseT.CollDataProvider.GetWorldToLocal()).GetExtent();
		// Transform the PlaneNormals into local space.
		LocalBoxX = baseT.baseT.CollDataProvider.GetWorldToLocal().TransformNormal(FkDOPPlanes.PlaneNormals[0]);
		LocalBoxY = baseT.baseT.CollDataProvider.GetWorldToLocal().TransformNormal(FkDOPPlanes.PlaneNormals[1]);
		LocalBoxZ = baseT.baseT.CollDataProvider.GetWorldToLocal().TransformNormal(FkDOPPlanes.PlaneNormals[2]);
	}
};

public struct TkDOPPointCollisionCheck<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/> /*:
	public TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER,KDOP_IDX_TYPE>*/ where COLL_DATA_PROVIDER : COLL_DATA_PROVIDER_INTERFACE
{
	public TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/> baseT;
	// Holds the minimum pentration distance for push out calculations
	public FLOAT BestDistance;
	public FVector LocalHitLocation;

	/**
	 * Sets up the TkDOPPointCollisionCheck structure for performing point checks
	 * (point plus extent) against a kDOPTree. Initializes all of the variables
	 * that are used throughout the check.
	 *
	 * @param InLocation -- The point to check for intersection
	 * @param InExtent -- The extent to check
	 * @param InCollDataProvider -- The struct that provides access to mesh/primitive
	 *		specific data, such as L2W, W2L, Vertices, and so on
	 * @param InResult -- The out param for hit result information
	 */
	public TkDOPPointCollisionCheck(in FVector InLocation,in FVector InExtent,
	in COLL_DATA_PROVIDER InCollDataProvider,ref FCheckResult InResult)
	{
		this = default;
		baseT = new TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/>( InLocation, InLocation, InExtent, 0, InCollDataProvider, ref InResult );
		BestDistance = ( 100000f );
	}

	/**
	 * Returns the transformed hit location
	 */
	public FVector GetHitLocation()
	{
		// Push out the hit location from the point along the hit normal and
		// convert into world units
		return baseT.baseT.baseT.CollDataProvider.GetLocalToWorld().TransformFVector(
			baseT.baseT.LocalStart + 
			baseT.baseT.LocalHitNormal * BestDistance);
	}
	};
public struct TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*, typename KDOP_IDX_TYPE*/>/* :
	public TkDOPCollisionCheck<COLL_DATA_PROVIDER,KDOP_IDX_TYPE>*/ where COLL_DATA_PROVIDER : COLL_DATA_PROVIDER_INTERFACE
{
	public TkDOPCollisionCheck<COLL_DATA_PROVIDER> baseT;
	/**
	 * Where the collision results get stored
	 */
	public FCheckResult Result;
	// Constant input vars
	public readonly FVector Start;
	public readonly FVector End;
	/**
	 * Flags for optimizing a trace
	 */
	public readonly ETraceFlags TraceFlags;
	// Locally calculated vectors
	public FVector LocalStart;
	public FVector LocalEnd;
	public FVector LocalDir;
	public FVector LocalOneOverDir;
	// Normal in local space which gets transformed to world at the very end
	public FVector LocalHitNormal;

	/**
	 * Sets up the FkDOPLineCollisionCheck structure for performing line checks
	 * against a kDOPTree. Initializes all of the variables that are used
	 * throughout the line check.
	 *
	 * @param InStart -- The starting point of the trace
	 * @param InEnd -- The ending point of the trace
	 * @param InTraceFlags -- The trace flags that might modify searches
	 * @param InCollDataProvider -- The struct that provides access to mesh/primitive
	 *		specific data, such as L2W, W2L, Vertices, and so on
	 * @param InResult -- The out param for hit result information
	 */
	public TkDOPLineCollisionCheck(in FVector InStart, in FVector InEnd,
		ETraceFlags InTraceFlags,in COLL_DATA_PROVIDER InCollDataProvider,
		ref FCheckResult InResult)
	{
		this = default;
		baseT = new TkDOPCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>(InCollDataProvider);
		InResult.ForceFixAndAllocate();
		Result = ( InResult );
		Start = ( InStart );
		End = ( InEnd );
		TraceFlags = ( InTraceFlags );
			
		FMatrix WorldToLocal = baseT.CollDataProvider.GetWorldToLocal();
		// Move start and end to local space
		LocalStart = WorldToLocal.TransformFVector(Start);
		LocalEnd = WorldToLocal.TransformFVector(End);
		// Calculate the vector's direction in local space
		LocalDir = LocalEnd - LocalStart;
		// Build the one over dir
		LocalOneOverDir.X = LocalDir.X != 0f ? 1f / LocalDir.X : 0f;
		LocalOneOverDir.Y = LocalDir.Y != 0f ? 1f / LocalDir.Y : 0f;
		LocalOneOverDir.Z = LocalDir.Z != 0f ? 1f / LocalDir.Z : 0f;
		// Clear the closest hit time
		Result.Time = MAX_FLT;
	}

	/**
	 * Transforms the local hit normal into a world space normal using the transpose
	 * adjoint and flips the normal if need be
	 */
	public FVector GetHitNormal()
	{
		// Transform the hit back into world space using the transpose adjoint
		FVector Normal = baseT.CollDataProvider.GetLocalToWorldTransposeAdjoint().TransformNormal(LocalHitNormal).SafeNormal();
		// Flip the normal if the triangle is inverted
		if (baseT.CollDataProvider.GetDeterminant() < 0f)
		{
			Normal = -Normal;
		}
		return Normal;
	}
};
public struct FkDOPCollisionTriangle/*<KDOP_IDX_TYPE>*/
{
	// Triangle index (indexes into Vertices)
	public KDOP_IDX_TYPE v1, v2, v3;
	// The material of this triangle
	public KDOP_IDX_TYPE MaterialIndex;

	// Set up indices
	public FkDOPCollisionTriangle(KDOP_IDX_TYPE Index1,KDOP_IDX_TYPE Index2,KDOP_IDX_TYPE Index3)
	{
		v1 = ( Index1 );
		v2 = ( Index2 );
		v3 = ( Index3 );
		MaterialIndex = ( default );
	}
	/**
	 * Full constructor that sets indices and material
	 */
	public FkDOPCollisionTriangle(KDOP_IDX_TYPE Index1,KDOP_IDX_TYPE Index2,KDOP_IDX_TYPE Index3,KDOP_IDX_TYPE Material)
	{
		v1 = ( Index1 );
		v2 = ( Index2 );
		v3 = ( Index3 );
		MaterialIndex = ( Material );
	}
};
public struct FkDOPBuildCollisionTriangle/*<KDOP_IDX_TYPE>*/ /*: public FkDOPCollisionTriangle<KDOP_IDX_TYPE>*/
{
	public FkDOPCollisionTriangle/*<KDOP_IDX_TYPE>*/ baseT;
	/**
	 * Centroid of the triangle used for determining which bounding volume to
	 * place the triangle in
	 */
	public FVector Centroid;
	/**
	 * First vertex in the triangle
	 */
	public FVector V0;
	/**
	 * Second vertex in the triangle
	 */
	public FVector V1;
	/**
	 * Third vertex in the triangle
	 */
	public FVector V2;

	/**
	 * Sets the indices, material index, calculates the centroid using the
	 * specified triangle vertex positions
	 */
	public FkDOPBuildCollisionTriangle(KDOP_IDX_TYPE Index1,KDOP_IDX_TYPE Index2,KDOP_IDX_TYPE Index3,
		KDOP_IDX_TYPE InMaterialIndex,
	in FVector vert0,in FVector vert1,in FVector vert2)
	{
		this = default;
		FkDOPCollisionTriangle(Index1,Index2,Index3,InMaterialIndex);
		V0 = ( vert0 );
		V1 = ( vert1 );
		V2 = ( vert2 );
		// Now calculate the centroid for the triangle
		Centroid = (V0 + V1 + V2) / 3f;
	}
	
	void FkDOPCollisionTriangle(KDOP_IDX_TYPE Index1,KDOP_IDX_TYPE Index2,KDOP_IDX_TYPE Index3,KDOP_IDX_TYPE Material)
	{
		baseT.v1 = ( Index1 );
		baseT.v2 = ( Index2 );
		baseT.v3 = ( Index3 );
		baseT.MaterialIndex = ( Material );
	}
};
	
public unsafe struct TkDOP<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/>/* : FkDOPPlanes*/ where COLL_DATA_PROVIDER : COLL_DATA_PROVIDER_INTERFACE
{
	
	/** Exposes data provider type to clients. */
	//typedef COLL_DATA_PROVIDER DataProviderType;

	/**
	 * Min planes for this bounding volume
	 */
	public fixed FLOAT Min[NUM_PLANES];
	/**
	 * Max planes for this bounding volume
	 */
	public fixed FLOAT Max[NUM_PLANES];

	/**
	 * Copies the passed in FkDOP and expands it by the extent. Note assumes AABB.
	 *
	 * @param kDOP -- The kDOP to copy
	 * @param Extent -- The extent to expand it by
	 */
	public TkDOP(in TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> kDOP,in FVector Extent)
	{
		Min[0] = kDOP.Min[0] - Extent.X;
		Min[1] = kDOP.Min[1] - Extent.Y;
		Min[2] = kDOP.Min[2] - Extent.Z;
		Max[0] = kDOP.Max[0] + Extent.X;
		Max[1] = kDOP.Max[1] + Extent.Y;
		Max[2] = kDOP.Max[2] + Extent.Z;
	}

	/**
	 * Adds a new point to the kDOP volume, expanding it if needed.
	 *
	 * @param Point The vector to add to the volume
	 */
	void AddPoint(in FVector Point)
	{
		// Dot against each plane and expand the volume out to encompass it if the
		// point is further away than either (min/max) of the previous points
		for (INT Plane = 0; Plane < NUM_PLANES; Plane++)
		{
			// Project this point onto the plane normal
			FLOAT Dot = Point | FkDOPPlanes.PlaneNormals[Plane];
			// Move the plane out as needed
			if (Dot < Min[Plane])
			{
				Min[Plane] = Dot;
			}
			if (Dot > Max[Plane])
			{
				Max[Plane] = Dot;
			}
		}
	}

	/**
	 * Adds a list of triangles to this volume
	 *
	 * @param Start the starting point in the build triangles array
	 * @param NumTris the number of tris to iterate through adding from the array
	 * @param BuildTriangles the list of triangles used for building the collision data
	 */
	public void AddTriangles(KDOP_IDX_TYPE StartIndex,KDOP_IDX_TYPE NumTris,
		in array<FkDOPBuildCollisionTriangle/*<KDOP_IDX_TYPE>*/ > BuildTriangles)
	{
		// Reset the min/max planes
		Init();
		// Go through the list and add each of the triangle verts to our volume
		for (KDOP_IDX_TYPE Triangle = StartIndex; Triangle < StartIndex + NumTris; Triangle++)
		{
			AddPoint(BuildTriangles[Triangle].V0);
			AddPoint(BuildTriangles[Triangle].V1);
			AddPoint(BuildTriangles[Triangle].V2);
		}
	}

	/**
	 * Sets the data to an invalid state (inside out volume)
	 */
	public void Init()
	{
		for (INT nPlane = 0; nPlane < NUM_PLANES; nPlane++)
		{
			Min[nPlane] = MAX_FLT;
			Max[nPlane] = -MAX_FLT;
		}
	}

	/**
	 * Checks a line against this kDOP. Note this assumes a AABB. If more planes
	 * are to be used, this needs to be rewritten. Also note, this code is Andrew's
	 * original code modified to work with FkDOP
	 *
	 * input:	Check The aggregated line check structure
	 *			HitTime The out value indicating hit time
	 */
	public UBOOL LineCheck(ref TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check,out FLOAT HitTime)
	{
		FVector	Time = (0f,0f,0f);
		UBOOL Inside = true;

		HitTime = 0.0f;  // always initialize (prevent valgrind whining) --ryan.

		if(Check.LocalStart.X < Min[0])
		{
			if(Check.LocalDir.X <= 0.0f)
				return false;
			else
			{
				Inside = false;
				Time.X = (Min[0] - Check.LocalStart.X) * Check.LocalOneOverDir.X;
			}
		}
		else if(Check.LocalStart.X > Max[0])
		{
			if(Check.LocalDir.X >= 0.0f)
				return false;
			else
			{
				Inside = false;
				Time.X = (Max[0] - Check.LocalStart.X) * Check.LocalOneOverDir.X;
			}
		}

		if(Check.LocalStart.Y < Min[1])
		{
			if(Check.LocalDir.Y <= 0.0f)
				return false;
			else
			{
				Inside = false;
				Time.Y = (Min[1] - Check.LocalStart.Y) * Check.LocalOneOverDir.Y;
			}
		}
		else if(Check.LocalStart.Y > Max[1])
		{
			if(Check.LocalDir.Y >= 0.0f)
				return false;
			else
			{
				Inside = false;
				Time.Y = (Max[1] - Check.LocalStart.Y) * Check.LocalOneOverDir.Y;
			}
		}

		if(Check.LocalStart.Z < Min[2])
		{
			if(Check.LocalDir.Z <= 0.0f)
				return false;
			else
			{
				Inside = false;
				Time.Z = (Min[2] - Check.LocalStart.Z) * Check.LocalOneOverDir.Z;
			}
		}
		else if(Check.LocalStart.Z > Max[2])
		{
			if(Check.LocalDir.Z >= 0.0f)
				return false;
			else
			{
				Inside = false;
				Time.Z = (Max[2] - Check.LocalStart.Z) * Check.LocalOneOverDir.Z;
			}
		}

		if(Inside)
		{
			HitTime = 0f;
			return true;
		}

		HitTime = Time.GetMax();

		if(HitTime >= 0.0f && HitTime <= 1.0f)
		{
			FVector Hit = Check.LocalStart + Check.LocalDir * HitTime;

			return (Hit.X > Min[0] - FUDGE_SIZE && Hit.X < Max[0] + FUDGE_SIZE &&
					Hit.Y > Min[1] - FUDGE_SIZE && Hit.Y < Max[1] + FUDGE_SIZE &&
					Hit.Z > Min[2] - FUDGE_SIZE && Hit.Z < Max[2] + FUDGE_SIZE);
		}
		return false;
	}
	
	/**
	 * Checks a point with extent against this kDOP. The extent is already added in
	 * to the kDOP being tested (Minkowski sum), so this code just checks to see if
	 * the point is inside the kDOP. Note this assumes a AABB. If more planes are 
	 * to be used, this needs to be rewritten.
	 *
	 * @param Check The aggregated point check structure
	 */
	public UBOOL PointCheck(in TkDOPPointCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		return Check.baseT.baseT.LocalStart.X >= Min[0] && Check.baseT.baseT.LocalStart.X <= Max[0] 
			&& Check.baseT.baseT.LocalStart.Y >= Min[1] && Check.baseT.baseT.LocalStart.Y <= Max[1] 
			&& Check.baseT.baseT.LocalStart.Z >= Min[2] && Check.baseT.baseT.LocalStart.Z <= Max[2];
	}

	/**
	 * Check (local space) AABB against this kDOP.
	 *
	 * @param LocalAABB box in local space
	 */
	UBOOL AABBOverlapCheck(in FBox LocalAABB)
	{
		return Min[0] <= LocalAABB.Max.X && LocalAABB.Min.X <= Max[0] &&
			Min[1] <= LocalAABB.Max.Y && LocalAABB.Min.Y <= Max[1] &&
			Min[2] <= LocalAABB.Max.Z && LocalAABB.Min.Z <= Max[2];
	}
}
	
public class TkDOPNode<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/> where COLL_DATA_PROVIDER : COLL_DATA_PROVIDER_INTERFACE
{
	/** Exposes data provider type to clients. */
	//typedef COLL_DATA_PROVIDER							DataProviderType;

	/** Exposes node type to clients. */
	//typedef TkDOPNode<DataProviderType,KDOP_IDX_TYPE>	NodeType;

	/** Exposes kDOP type to clients. */
	//typedef TkDOP<DataProviderType,KDOP_IDX_TYPE>		kDOPType;

	// The bounding kDOP for this node
	public TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> BoundingVolume;

	// Note this isn't smaller since 4 byte alignment will take over anyway
	UBOOL bIsLeaf;

	// Should be an union, can't be bothered
	T t;
	N n;


	struct N
	{
		public KDOP_IDX_TYPE LeftNode;
		public KDOP_IDX_TYPE RightNode;
	}
	struct T
	{
		public KDOP_IDX_TYPE NumTriangles;
		public KDOP_IDX_TYPE StartIndex;
	}

	/**
	 * Inits the data to no child nodes and an inverted volume
	 */
	public TkDOPNode()
	{
		n.LeftNode = -1;
        n.RightNode = -1;
		BoundingVolume.Init();
	}

	/**
	 * Determines if the node is a leaf or not. If it is not a leaf, it subdivides
	 * the list of triangles again adding two child nodes and splitting them on
	 * the mean (splatter method). Otherwise it sets up the triangle information.
	 *
	 * @param Start -- The triangle index to start processing with
	 * @param NumTris -- The number of triangles to process
	 * @param BuildTriangles -- The list of triangles to use for the build process
	 * @param Nodes -- The list of nodes in this tree
	 */
	public void SplitTriangleList(INT Start,INT NumTris,
		ref array<FkDOPBuildCollisionTriangle/*<KDOP_IDX_TYPE>*/ > BuildTriangles,
		ref array<TkDOPNode<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>> Nodes)
	{
		// Add all of the triangles to the bounding volume
		BoundingVolume.AddTriangles(Start,NumTris,BuildTriangles);
		// Figure out if we are a leaf node or not
		if (NumTris > MAX_TRIS_PER_LEAF)
		{
			// Still too many triangles, so continue subdividing the triangle list
			bIsLeaf = false;
			INT BestPlane = -1;
			FLOAT BestMean = 0f;
			FLOAT BestVariance = 0f;
			// Determine how to split using the splatter algorithm
			for (INT nPlane = 0; nPlane < NUM_PLANES; nPlane++)
			{
				FLOAT Mean = 0f;
				FLOAT Variance = 0f;
				// Compute the mean for the triangle list
				for (INT nTriangle = Start; nTriangle < Start + NumTris; nTriangle++)
				{
					// Project the centroid of the triangle against the plane
					// normals and accumulate to find the total projected
					// weighting
					Mean += BuildTriangles[nTriangle].Centroid | FkDOPPlanes.PlaneNormals[nPlane];
				}
				// Divide by the number of triangles to get the average
				Mean /= (FLOAT)(NumTris);
				// Compute variance of the triangle list
				for (INT nTriangle = Start; nTriangle < Start + NumTris;nTriangle++)
				{
					// Project the centroid again
					FLOAT Dot = BuildTriangles[nTriangle].Centroid | FkDOPPlanes.PlaneNormals[nPlane];
					// Now calculate the variance and accumulate it
					Variance += (Dot - Mean) * (Dot - Mean);
				}
				// Get the average variance
				Variance /= (FLOAT)(NumTris);
				// Determine if this plane is the best to split on or not
				if (Variance >= BestVariance)
				{
					BestPlane = nPlane;
					BestVariance = Variance;
					BestMean = Mean;
				}
			}
			// Now that we have the plane to split on, work through the triangle
			// list placing them on the left or right of the splitting plane
			INT Left = Start - 1;
			INT Right = Start + NumTris;
			// Keep working through until the left index passes the right
			while (Left < Right)
			{
				FLOAT Dot;
				// Find all the triangles to the "left" of the splitting plane
				do
				{
					Dot = BuildTriangles[++Left].Centroid | FkDOPPlanes.PlaneNormals[BestPlane];
				}
				while (Dot < BestMean && Left < Right);
				// Find all the triangles to the "right" of the splitting plane
				do
				{
					Dot = BuildTriangles[--Right].Centroid | FkDOPPlanes.PlaneNormals[BestPlane];
				}
				while (Dot >= BestMean && Right > 0 && Left < Right);
				// Don't swap the triangle data if we just hit the end
				if (Left < Right)
				{
					// Swap the triangles since they are on the wrong sides of the
					// splitting plane
					var Temp = BuildTriangles[Left];
					BuildTriangles[Left] = BuildTriangles[Right];
					BuildTriangles[Right] = Temp;
				}
			}
			// Check for wacky degenerate case where more than MAX_TRIS_PER_LEAF
			// fall all in the same kDOP
			if (Left == Start + NumTris || Right == Start)
			{
				Left = Start + (NumTris / 2);
			}
			// Add the two child nodes
			n.LeftNode = Nodes.AddCount(2);
			n.RightNode = n.LeftNode + 1;
			// Have the left node recursively subdivide it's list
			Nodes[n.LeftNode].SplitTriangleList(Start,Left - Start,ref BuildTriangles,ref Nodes);
			// And now have the right node recursively subdivide it's list
			Nodes[n.RightNode].SplitTriangleList(Left,Start + NumTris - Left,ref BuildTriangles,ref Nodes);
		}
		else
		{
			// No need to subdivide further so make this a leaf node
			bIsLeaf = true;
			// Copy in the triangle information
			t.StartIndex = Start;
			t.NumTriangles = NumTris;
		}
	}

	/* 
	 * Determines the line in the FkDOPLineCollisionCheck intersects this node. It
	 * also will check the child nodes if it is not a leaf, otherwise it will check
	 * against the triangle data.
	 *
	 * @param Check -- The aggregated line check data
	 */
	public UBOOL LineCheck(ref TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		UBOOL bHit = false;
		// If this is a node, check the two child nodes and pick the closest one
		// to recursively check against and only check the second one if there is
		// not a hit or the hit returned is further out than the second node
		if (bIsLeaf == false)
		{
			// Holds the indices for the closest and farthest nodes
			INT NearNode = -1;
			INT FarNode = -1;
			// Holds the hit times for the child nodes
			FLOAT NodeHitTime, NearTime = 0f, FarTime = 0f;
			// Assume the left node is closer (it will be adjusted later)
			if (Check.baseT.Nodes[n.LeftNode].BoundingVolume.LineCheck(ref Check,out NodeHitTime))
			{
				NearNode = n.LeftNode;
				NearTime = NodeHitTime;
			}
			// Find out if the second node is closer
			if (Check.baseT.Nodes[n.RightNode].BoundingVolume.LineCheck(ref Check,out NodeHitTime))
			{
				// See if the left node was a miss and make the right the near node
				if (NearNode == -1)
				{
					NearNode = n.RightNode;
					NearTime = NodeHitTime;
				}
				else
				{
					FarNode = n.RightNode;
					FarTime = NodeHitTime;
				}
			}
			// Swap the Near/FarNodes if the right node is closer than the left
			if (NearNode != -1 && FarNode != -1 && FarTime < NearTime)
			{
				Exchange(ref NearNode,ref FarNode);
				Exchange(ref NearTime,ref FarTime);
			}
			// See if we need to search the near node or not
			if (NearNode != -1 && Check.Result.Time > NearTime)
			{
				bHit = Check.baseT.Nodes[NearNode].LineCheck(ref Check);
			}
			// Check for an early out
			UBOOL bStopAtAnyHit = (Check.TraceFlags & TRACE_StopAtAnyHit) != default;
			// Now do the same for the far node. This will only happen if a miss in
			// the near node or the nodes overlapped and this one is closer
			if (FarNode != -1 &&
				(Check.Result.Time > FarTime || bHit == FALSE) &&
				(bHit == FALSE || bStopAtAnyHit == FALSE))
			{
				bHit |= Check.baseT.Nodes[FarNode].LineCheck(ref Check);
			}
		}
		else
		{
			// This is a leaf, check the triangles for a hit
			bHit = LineCheckTriangles(ref Check);
		}
		return bHit;
	}

	/**
	 * Works through the list of triangles in this node checking each one for a
	 * collision.
	 *
	 * @param Check -- The aggregated line check data
	 */
	public UBOOL LineCheckTriangles(ref TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		// Assume a miss
		UBOOL bHit = FALSE;
		// Check for an early out
		UBOOL bStopAtAnyHit = (Check.TraceFlags & TRACE_StopAtAnyHit) != default;
		// Loop through all of our triangles. We need to check them all in case
		// there are two (or more) potential triangles that would collide and let
		// the code choose the closest
		for (KDOP_IDX_TYPE CollTriIndex = t.StartIndex;
			CollTriIndex < t.StartIndex + t.NumTriangles &&
			(bHit == FALSE || bStopAtAnyHit == FALSE);
			CollTriIndex++)
		{
			// Get the collision triangle that we are checking against
			ref FkDOPCollisionTriangle/*<KDOP_IDX_TYPE>*/ CollTri =	ref Check.baseT.CollisionTriangles[CollTriIndex];
			if(Check.baseT.CollDataProvider.ShouldCheckMaterial(CollTri.MaterialIndex))
			{
				// Now get refs to the 3 verts to check against
				FVector v1 = Check.baseT.CollDataProvider.GetVertex(CollTri.v1);
				FVector v2 = Check.baseT.CollDataProvider.GetVertex(CollTri.v2);
				FVector v3 = Check.baseT.CollDataProvider.GetVertex(CollTri.v3);
				// Now check for an intersection
				bHit |= LineCheckTriangle(ref Check,v1,v2,v3,CollTri.MaterialIndex);
			}
		}
		return bHit;
	}

	/**
	 * Performs collision checking against the triangle using the old collision
	 * code to handle it. This is done to provide consistency in collision.
	 *
	 * @param Check -- The aggregated line check data
	 * @param v1 -- The first vertex of the triangle
	 * @param v2 -- The second vertex of the triangle
	 * @param v3 -- The third vertex of the triangle
	 * @param MaterialIndex -- The material for this triangle if it is hit
	 */
	unsafe UBOOL LineCheckTriangle(ref TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check,
		in FVector v1,in FVector v2,in FVector v3,KDOP_IDX_TYPE MaterialIndex)
	{
		// Calculate the hit normal the same way the old code
		// did so things are the same
		FVector LocalNormal = ((v2 - v3) ^ (v1 - v3)).SafeNormal();
		// Calculate the hit time the same way the old code
		// did so things are the same
		FPlane TrianglePlane = new(v1,LocalNormal);
		FLOAT StartDist = TrianglePlane.PlaneDot(Check.LocalStart);
		FLOAT EndDist = TrianglePlane.PlaneDot(Check.LocalEnd);
		if ((StartDist == EndDist) || (StartDist < -0.001f && EndDist < -0.001f) || (StartDist > 0.001f && EndDist > 0.001f))
		{
			return FALSE;
		}
		// Figure out when it will hit the triangle
		FLOAT Time = -StartDist / (EndDist - StartDist);
		// If this triangle is not closer than the previous hit, reject it
		if (Time < 0f || Time >= Check.Result.Time)
		{
			return FALSE;
		}
		// Calculate the line's point of intersection with the node's plane
		FVector Intersection = Check.LocalStart + Check.LocalDir * Time;
		FVector* Verts = stackalloc FVector[]
		{ 
			v1, v2, v3
		};
		// Check if the point of intersection is inside the triangle's edges.
		for( INT SideIndex = 0; SideIndex < 3; SideIndex++ )
		{
			FVector SideDirection = LocalNormal ^
				(Verts[(SideIndex + 1) % 3] - Verts[SideIndex]);
			FLOAT SideW = SideDirection | Verts[SideIndex];
			if (((SideDirection | Intersection) - SideW) >= 0.001f)
			{
				return FALSE;
			}
		}
		// Return results
		Check.LocalHitNormal = LocalNormal;
		Check.Result.Time = Time;
		Check.Result.Material = Check.baseT.CollDataProvider.GetMaterial(MaterialIndex);
		Check.Result.Item = Check.baseT.CollDataProvider.GetItemIndex(MaterialIndex);
		return TRUE;
	}

	/**
	 * Determines the line + extent in the FkDOPBoxCollisionCheck intersects this
	 * node. It also will check the child nodes if it is not a leaf, otherwise it
	 * will check against the triangle data.
	 *
	 * @param Check -- The aggregated box check data
	 */
	public UBOOL BoxCheck(ref TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		UBOOL bHit = FALSE;
		// If this is a node, check the two child nodes and pick the closest one
		// to recursively check against and only check the second one if there is
		// not a hit or the hit returned is further out than the second node
		if (bIsLeaf == false)
		{
			// Holds the indices for the closest and farthest nodes
			INT NearNode = -1;
			INT FarNode = -1;
			// Holds the hit times for the child nodes
			FLOAT NodeHitTime = 0f, NearTime = 0f, FarTime = 0f;
			// Update the kDOP with the extent and test against that
			var kDOPNear = new TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>(Check.baseT.baseT.Nodes[n.LeftNode].BoundingVolume,
				Check.LocalExtent);
			// Assume the left node is closer (it will be adjusted later)
			if (kDOPNear.LineCheck(ref Check.baseT,out NodeHitTime))
			{
				NearNode = n.LeftNode;
				NearTime = NodeHitTime;
			}
			// Update the kDOP with the extent and test against that
			var kDOPFar = new TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>(Check.baseT.baseT.Nodes[n.RightNode].BoundingVolume,
				Check.LocalExtent);
			// Find out if the second node is closer
			if (kDOPFar.LineCheck(ref Check.baseT, out NodeHitTime))
			{
				// See if the left node was a miss and make the right the near node
				if (NearNode == -1)
				{
					NearNode = n.RightNode;
					NearTime = NodeHitTime;
				}
				else
				{
					FarNode = n.RightNode;
					FarTime = NodeHitTime;
				}
			}
			// Swap the Near/FarNodes if the right node is closer than the left
			if (NearNode != -1 && FarNode != -1 && FarTime < NearTime)
			{
				Exchange(ref NearNode,ref FarNode);
				Exchange(ref NearTime,ref FarTime);
			}
			// See if we need to search the near node or not
			if (NearNode != -1 && Check.baseT.Result.Time > NearTime)
			{
				bHit = Check.baseT.baseT.Nodes[NearNode].BoxCheck(ref Check);
			}
			// Check for an early out
			UBOOL bStopAtAnyHit = (Check.baseT.TraceFlags & TRACE_StopAtAnyHit) != default;
			// Now do the same for the far node. This will only happen if a miss in
			// the near node or the nodes overlapped and this one is closer
			if (FarNode != -1 &&
				(Check.baseT.Result.Time > FarTime || bHit == FALSE) &&
				(bHit == FALSE || bStopAtAnyHit == FALSE))
			{
				bHit |= Check.baseT.baseT.Nodes[FarNode].BoxCheck(ref Check);
			}
		}
		else
		{
			// This is a leaf, check the triangles for a hit
			bHit = BoxCheckTriangles(ref Check);
		}
		return bHit;
	}

	/**
	 * Works through the list of triangles in this node checking each one for a
	 * collision.
	 *
	 * @param Check -- The aggregated box check data
	 */
	public UBOOL BoxCheckTriangles(ref TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		// Assume a miss
		UBOOL bHit = false;
		// Use an early out if possible
		UBOOL bStopAtAnyHit = (Check.baseT.TraceFlags & TRACE_StopAtAnyHit) != default;
		// Loop through all of our triangles. We need to check them all in case
		// there are two (or more) potential triangles that would collide and let
		// the code choose the closest
		for (KDOP_IDX_TYPE CollTriIndex = t.StartIndex;
			CollTriIndex < t.StartIndex + t.NumTriangles &&
			(bHit == FALSE || bStopAtAnyHit == FALSE);
			CollTriIndex++)
		{
			// Get the collision triangle that we are checking against
			var CollTri = Check.baseT.baseT.CollisionTriangles[CollTriIndex];
			if(Check.baseT.baseT.CollDataProvider.ShouldCheckMaterial(CollTri.MaterialIndex))
			{
				// Now get refs to the 3 verts to check against
				FVector v1 = Check.baseT.baseT.CollDataProvider.GetVertex(CollTri.v1);
				FVector v2 = Check.baseT.baseT.CollDataProvider.GetVertex(CollTri.v2);
				FVector v3 = Check.baseT.baseT.CollDataProvider.GetVertex(CollTri.v3);
				// Now check for an intersection using the Separating Axis Theorem
				bHit |= BoxCheckTriangle(ref Check,v1,v2,v3,CollTri.MaterialIndex);
			}
		}
		return bHit;
	}

	/**
	 * Uses the separating axis theorem to check for triangle box collision.
	 *
	 * @param Check -- The aggregated box check data
	 * @param v1 -- The first vertex of the triangle
	 * @param v2 -- The second vertex of the triangle
	 * @param v3 -- The third vertex of the triangle
	 * @param MaterialIndex -- The material for this triangle if it is hit
	 */
	public UBOOL BoxCheckTriangle(ref TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check,
		in FVector v1,in FVector v2,in FVector v3,INT MaterialIndex)
	{
		FLOAT HitTime = 1f;
		FVector HitNormal = (0f,0f,0f);
		// Now check for an intersection using the Separating Axis Theorem
		UBOOL Result = FindSeparatingAxis(v1,v2,v3,Check.baseT.LocalStart,
			Check.baseT.LocalEnd,Check.Extent,Check.LocalBoxX,Check.LocalBoxY,
			Check.LocalBoxZ,out HitTime, out HitNormal);
		if (Result)
		{
			if (HitTime < Check.baseT.Result.Time)
			{
				// Store the better time
				Check.baseT.Result.Time = HitTime;
				// Get the material and item that was hit
				Check.baseT.Result.Material = Check.baseT.baseT.CollDataProvider.GetMaterial(MaterialIndex);
				Check.baseT.Result.Item = Check.baseT.baseT.CollDataProvider.GetItemIndex(MaterialIndex);
				// Normal will get transformed to world space at end of check
				Check.baseT.LocalHitNormal = HitNormal;
			}
			else
			{
				Result = FALSE;
			}
		}
		return Result;
	}

	/**
	 * Determines the point + extent in the FkDOPPointCollisionCheck intersects
	 * this node. It also will check the child nodes if it is not a leaf, otherwise
	 * it will check against the triangle data.
	 *
	 * @param Check -- The aggregated point check data
	 */
	public UBOOL PointCheck(ref TkDOPPointCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		UBOOL bHit = FALSE;
		// If this is a node, check the two child nodes recursively
		if (bIsLeaf == false)
		{
			// Holds the indices for the closest and farthest nodes
			INT NearNode = -1;
			INT FarNode = -1;
			// Update the kDOP with the extent and test against that
			var kDOPNear = new TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>(Check.baseT.baseT.baseT.Nodes[n.LeftNode].BoundingVolume,
				Check.baseT.LocalExtent);
			// Assume the left node is closer (it will be adjusted later)
			if (kDOPNear.PointCheck(Check))
			{
				NearNode = n.LeftNode;
			}
			// Update the kDOP with the extent and test against that
			var kDOPFar = new TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>(Check.baseT.baseT.baseT.Nodes[n.RightNode].BoundingVolume,
				Check.baseT.LocalExtent);
			// Find out if the second node is closer
			if (kDOPFar.PointCheck(Check))
			{
				// See if the left node was a miss and make the right the near node
				if (NearNode == -1)
				{
					NearNode = n.RightNode;
				}
				else
				{
					FarNode = n.RightNode;
				}
			}
			// See if we need to search the near node or not
			if (NearNode != -1)
			{
				bHit = Check.baseT.baseT.baseT.Nodes[NearNode].PointCheck(ref Check);
			}
			// Now do the same for the far node
			if (FarNode != -1)
			{
				bHit |= Check.baseT.baseT.baseT.Nodes[FarNode].PointCheck(ref Check);
			}
		}
		else
		{
			// This is a leaf, check the triangles for a hit
			bHit = PointCheckTriangles(ref Check);
		}
		return bHit;
	}

	/**
	 * Works through the list of triangles in this node checking each one for a
	 * collision.
	 *
	 * @param Check -- The aggregated point check data
	 */
	UBOOL PointCheckTriangles(ref TkDOPPointCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		// Assume a miss
		UBOOL bHit = FALSE;
		// Loop through all of our triangles. We need to check them all in case
		// there are two (or more) potential triangles that would collide and let
		// the code choose the closest
		for (KDOP_IDX_TYPE CollTriIndex = t.StartIndex;
			CollTriIndex < t.StartIndex + t.NumTriangles;
			CollTriIndex++)
		{
			// Get the collision triangle that we are checking against
			var CollTri = Check.baseT.baseT.baseT.CollisionTriangles[CollTriIndex];
			if(Check.baseT.baseT.baseT.CollDataProvider.ShouldCheckMaterial(CollTri.MaterialIndex))
			{
				// Now get refs to the 3 verts to check against
				FVector v1 = Check.baseT.baseT.baseT.CollDataProvider.GetVertex(CollTri.v1);
				FVector v2 = Check.baseT.baseT.baseT.CollDataProvider.GetVertex(CollTri.v2);
				FVector v3 = Check.baseT.baseT.baseT.CollDataProvider.GetVertex(CollTri.v3);
				// Now check for an intersection using the Separating Axis Theorem
				bHit |= PointCheckTriangle(ref Check,v1,v2,v3,CollTri.MaterialIndex);
			}
		}
		return bHit;
	}

	/**
	 * Uses the separating axis theorem to check for triangle box collision.
	 *
	 * @param Check -- The aggregated box check data
	 * @param v1 -- The first vertex of the triangle
	 * @param v2 -- The second vertex of the triangle
	 * @param v3 -- The third vertex of the triangle
	 * @param MaterialIndex -- The material for this triangle if it is hit
	 */
	public UBOOL PointCheckTriangle(ref TkDOPPointCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check,
		in FVector v1,in FVector v2,in FVector v3,INT InMaterialIndex)
	{
		// Use the separating axis theorem to see if we hit
		var ThePointCheck = new FSeparatingAxisPointCheck(v1,v2,v3,Check.baseT.baseT.LocalStart,Check.baseT.Extent,
			Check.baseT.LocalBoxX,Check.baseT.LocalBoxY,Check.baseT.LocalBoxZ,Check.BestDistance);

		// If we hit and it is closer update the out values
		if (ThePointCheck.Hit && ThePointCheck.BestDist < Check.BestDistance)
		{
			// Get the material and item that was hit
			Check.baseT.baseT.Result.Material = Check.baseT.baseT.baseT.CollDataProvider.GetMaterial(InMaterialIndex);
			Check.baseT.baseT.Result.Item = Check.baseT.baseT.baseT.CollDataProvider.GetItemIndex(InMaterialIndex);
			// Normal will get transformed to world space at end of check
			Check.baseT.baseT.LocalHitNormal = ThePointCheck.HitNormal;
			// Copy the distance for push out calculations
			Check.BestDistance = ThePointCheck.BestDist;
			return TRUE;
		}
		return FALSE;
	}
};

struct FSeparatingAxisPointCheck
{
	public FVector	HitNormal;
	public FLOAT	BestDist;
	public UBOOL	Hit;

	public readonly FVector	V0, V1, V2;

	public UBOOL TestSeparatingAxis(
		in FVector Axis,
		FLOAT ProjectedPoint,
		FLOAT ProjectedExtent
		)
	{
		FLOAT	ProjectedV0 = Axis | V0,
				ProjectedV1 = Axis | V1,
				ProjectedV2 = Axis | V2,
				TriangleMin = Min(ProjectedV0,Min(ProjectedV1,ProjectedV2)) - ProjectedExtent,
				TriangleMax = Max(ProjectedV0,Max(ProjectedV1,ProjectedV2)) + ProjectedExtent;

		if(ProjectedPoint >= TriangleMin && ProjectedPoint <= TriangleMax)
		{
			// Use inverse sqrt because that is fast and we do more math with the inverse value anyway
			FLOAT	InvAxisMagnitude = appInvSqrt(Axis.X * Axis.X +	Axis.Y * Axis.Y + Axis.Z * Axis.Z),
					ScaledBestDist = BestDist / InvAxisMagnitude,
					MinPenetrationDist = ProjectedPoint - TriangleMin,
					MaxPenetrationDist = TriangleMax - ProjectedPoint;
			if(MinPenetrationDist < ScaledBestDist)
			{
				BestDist = MinPenetrationDist * InvAxisMagnitude;
				HitNormal = -Axis * InvAxisMagnitude;
			}
			if(MaxPenetrationDist < ScaledBestDist)
			{
				BestDist = MaxPenetrationDist * InvAxisMagnitude;
				HitNormal = Axis * InvAxisMagnitude;
			}
			return true;
		}
		else
			return false;
	}

	public UBOOL TestSeparatingAxis(
		in FVector Axis,
		in FVector Point,
		FLOAT ProjectedExtent
		)
	{
		return TestSeparatingAxis(Axis,Axis | Point,ProjectedExtent);
	}

	UBOOL TestSeparatingAxis(
		in FVector Axis,
		in FVector Point,
		in FVector BoxX,
		in FVector BoxY,
		in FVector BoxZ,
		in FVector BoxExtent
		)
	{
		FLOAT	ProjectedExtent = BoxExtent.X * Abs(Axis | BoxX) + BoxExtent.Y * Abs(Axis | BoxY) + BoxExtent.Z * Abs(Axis | BoxZ);
		return TestSeparatingAxis(Axis,Axis | Point,ProjectedExtent);
	}

	UBOOL FindSeparatingAxis(
		in FVector Point,
		in FVector BoxExtent,
		in FVector BoxX,
		in FVector BoxY,
		in FVector BoxZ
		)
	{
		// Box faces. We need to calculate this by crossing edges because BoxX etc are the _edge_ directions - not the faces.
		// The box may be sheared due to non-unfiform scaling and rotation so FaceX normal != BoxX edge direction

		if(!TestSeparatingAxis(BoxX ^ BoxY,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		if(!TestSeparatingAxis(BoxY ^ BoxZ,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		if(!TestSeparatingAxis(BoxZ ^ BoxX,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		// Triangle normal.

		if(!TestSeparatingAxis((V2 - V1) ^ (V1 - V0),Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		// Box X edge x triangle edges.

		if(!TestSeparatingAxis((V1 - V0) ^ BoxX,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		if(!TestSeparatingAxis((V2 - V1) ^ BoxX,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		if(!TestSeparatingAxis((V0 - V2) ^ BoxX,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		// Box Y edge x triangle edges.

		if(!TestSeparatingAxis((V1 - V0) ^ BoxY,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		if(!TestSeparatingAxis((V2 - V1) ^ BoxY,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;
		
		if(!TestSeparatingAxis((V0 - V2) ^ BoxY,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;
		
		// Box Z edge x triangle edges.

		if(!TestSeparatingAxis((V1 - V0) ^ BoxZ,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		if(!TestSeparatingAxis((V2 - V1) ^ BoxZ,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;
		
		if(!TestSeparatingAxis((V0 - V2) ^ BoxZ,Point,BoxX,BoxY,BoxZ,BoxExtent))
			return false;

		return true;
	}

	public FSeparatingAxisPointCheck(
		in FVector InV0,
		in FVector InV1,
		in FVector InV2,
		in FVector Point,
		in FVector BoxExtent,
		in FVector BoxX,
		in FVector BoxY,
		in FVector BoxZ,
		FLOAT InBestDist
		)
	{
		
		HitNormal = (0,0,0);
		BestDist = (InBestDist);
		Hit = (default);
		V0 = (InV0);
		V1 = (InV1);
		V2 = (InV2);
		Hit = FindSeparatingAxis(Point,BoxExtent,BoxX,BoxY,BoxZ);
	}
};

public class TkDOPTree<COLL_DATA_PROVIDER/*, KDOP_IDX_TYPE*/> where COLL_DATA_PROVIDER : COLL_DATA_PROVIDER_INTERFACE
{
	/** Exposes data provider type to clients. */
	//typedef COLL_DATA_PROVIDER							DataProviderType;

	/** Exposes node type to clients. */
	//typedef TkDOPNode<DataProviderType,KDOP_IDX_TYPE>	NodeType;

	/** Exposes kDOP type to clients. */
	//typedef typename NodeType::kDOPType					kDOPType;

	/** The list of nodes contained within this tree. Node 0 is always the root node. */
	public array<TkDOPNode<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>> Nodes;

	/** The list of collision triangles in this tree. */
	public array<FkDOPCollisionTriangle/*<KDOP_IDX_TYPE>*/ > Triangles;

	/**
	 * Creates the root node and recursively splits the triangles into smaller
	 * volumes
	 *
	 * @param BuildTriangles -- The list of triangles to use for the build process
	 */
	public void Build(ref array<FkDOPBuildCollisionTriangle/*<KDOP_IDX_TYPE>*/ > BuildTriangles)
	{
		// Empty the current set of nodes and preallocate the memory so it doesn't
		// reallocate memory while we are recursively walking the tree
		Nodes.Empty(BuildTriangles.Num() * 2);
		// Add the root node
		Nodes.Add(new TkDOPNode<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>());
		// Now tell that node to recursively subdivide the entire set of triangles
		Nodes[0].SplitTriangleList(0,BuildTriangles.Num(),ref BuildTriangles,ref Nodes);
		// Don't waste memory.
		//Nodes.Shrink();
		// Copy over the triangle information afterward, since they will have
		// been sorted into their bounding volumes at this point
		Triangles.Empty(BuildTriangles.Num());
		Triangles.AddCount(BuildTriangles.Num());
		// Copy the triangles from the build list into the full list
		for (INT nIndex = 0; nIndex < BuildTriangles.Num(); nIndex++)
		{
			Triangles[nIndex] = BuildTriangles[nIndex].baseT;
		}
	}
	
	/**
	 * Figures out whether the check even hits the root node's bounding volume. If
	 * it does, it recursively searches for a triangle to hit.
	 *
	 * @param Check -- The aggregated line check data
	 */
	public UBOOL LineCheck(ref TkDOPLineCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		UBOOL bHit = FALSE;
		FLOAT HitTime;
		// Check against the first bounding volume and decide whether to go further
		if (Nodes[0].BoundingVolume.LineCheck(ref Check,out HitTime))
		{
			// Recursively check for a hit
			bHit = Nodes[0].LineCheck(ref Check);
		}
		return bHit;
	}

	/**
	 * Figures out whether the check even hits the root node's bounding volume. If
	 * it does, it recursively searches for a triangle to hit.
	 *
	 * @param Check -- The aggregated box check data
	 */
	public UBOOL BoxCheck(ref TkDOPBoxCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		UBOOL bHit = FALSE;
		FLOAT HitTime;
		// Check the root node's bounding volume expanded by the extent
		var kDOP = new TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>(Nodes[0].BoundingVolume,Check.LocalExtent);
		// Check against the first bounding volume and decide whether to go further
		if (kDOP.LineCheck(ref Check.baseT,out HitTime))
		{
			// Recursively check for a hit
			bHit = Nodes[0].BoxCheck(ref Check);
		}
		return bHit;
	}

	/**
	 * Figures out whether the check even hits the root node's bounding volume. If
	 * it does, it recursively searches for a triangle to hit.
	 *
	 * @param Check -- The aggregated point check data
	 */
	public UBOOL PointCheck(ref TkDOPPointCollisionCheck<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/> Check)
	{
		UBOOL bHit = FALSE;
		// Check the root node's bounding volume expanded by the extent
		var kDOP = new TkDOP<COLL_DATA_PROVIDER/*,KDOP_IDX_TYPE*/>(Nodes[0].BoundingVolume,Check.baseT.LocalExtent);
		// Check against the first bounding volume and decide whether to go further
		if (kDOP.PointCheck(Check))
		{
			// Recursively check for a hit
			bHit = Nodes[0].PointCheck(ref Check);
		}
		return bHit;
	}
}
}