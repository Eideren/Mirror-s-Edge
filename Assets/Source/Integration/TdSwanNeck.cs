namespace MEdge.TdGame{
	using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
	
	using _E_struct_FMatrix = MEdge.Core.Object.Matrix;
	using _E_struct_FVector = MEdge.Core.Object.Vector;
	using _E_struct_FRotator = MEdge.Core.Object.Rotator;
	public partial class TdSwanNeck
	{
		// Export UTdSwanNeck::execGetSwanNeckPos(FFrame&, void* const)
        public virtual /*native function */Object.Vector GetSwanNeckPos(/*const */Object.Rotator FrameOfRefRotation)
        {
	        unsafe
	        {
		        _E_struct_FVector output = default;
		        return *GetSwanNeckPos(&output, FrameOfRefRotation);
	        }
        }
        
        unsafe _E_struct_FVector * GetSwanNeckPos(_E_struct_FVector *ret, _E_struct_FRotator a3)
        {
	        _E_struct_FMatrix *v4; // eax
	        float v5; // xmm1_4
	        float v6; // xmm2_4
	        _E_struct_FVector *result; // eax
	        float v8; // xmm3_4
	        float v9; // xmm0_4
	        _E_struct_FMatrix v10; // [esp+10h] [ebp-40h] BYREF

	        v4 = FRotationMatrix(&v10, a3);
	        v5 = v4->XPlane.X;
	        v6 = v4->XPlane.Y;
	        result = ret;
	        v8 = this.Translation.X;
	        ret->Y = v8 * v6;
	        v9 = -0.0f - this.Translation.Y;
	        ret->X = v8 * v5;
	        ret->Z = v9;
	        return result;
        }
	}
}