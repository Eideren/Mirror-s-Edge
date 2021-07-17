namespace MEdge.TdGame{
	using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
	
	using _E_struct_FMatrix = MEdge.Core.Object.Matrix;
	using _E_struct_FVector = MEdge.Core.Object.Vector;
	public partial class TdSwanNeck
	{
		// Export UTdSwanNeck::execGetSwanNeckPos(FFrame&, void* const)
        public virtual /*native function */Object.Vector GetSwanNeckPos(/*const */Object.Rotator FrameOfRefRotation)
        {
	        unsafe
	        {
		        var _arg0 = new _E_struct_FVector();
		        _E_struct_FVector* arg0 = &_arg0;
		        _E_struct_FMatrix *v4; // eax
		        float v5; // xmm1_4
		        float v6; // xmm2_4
		        _E_struct_FVector *result; // eax
		        float v8; // xmm3_4
		        float v9; // xmm0_4
		        _E_struct_FMatrix thisMatrix; // [esp+10h] [ebp-40h] BYREF

		        var v = FRotationMatrix( FrameOfRefRotation );
		        v4 = &v;
		        v5 = v4->M[0];
		        v6 = v4->M[1];
		        result = arg0;
		        v8 = this.Translation.X;
		        arg0->Y = v8 * v6;
		        v9 = -0.0f - this.Translation.Y;
		        arg0->X = v8 * v5;
		        arg0->Z = v9;
		        return *result;
	        }
        }
	}
}