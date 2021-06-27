namespace MEdge.Core
{
	using _E_struct_FRotator = Object.Rotator;
	using _E_struct_Quat = Object.Quat;
	using _E_struct_FVector = Object.Vector;
	using _E_struct_Matrix = Object.Matrix;
	
	public partial class Object
	{
		public static unsafe class Decompiled
		{
			public static readonly float[] E_RotTable_dword_2028088 = new float[16384];
	        
			static Decompiled()
			{
				int v0; // edx
				//float *result; // eax
				double v2; // st5
				int v3; // [esp+0h] [ebp-4h]

				v0 = 0;
				//result = E_RotTable_dword_2028088;
				v3 = 0;
				do
				{
					v2 = (double)v3;
					v3 = ++v0;
					E_RotTable_dword_2028088[v0 - 1] = (float)System.Math.Sin(v2 * 2.0 * 0.0001917475984857051);
				}
				while ( v0 < 16384 );
				//return result;
			}
			
			public static _E_struct_Matrix* E_RotatorToMatrix(_E_struct_Matrix *thisMatrix, _E_struct_FRotator *a2)
			{
				_E_struct_Matrix *someMatrix; // eax
				/*signed */int v3; // edx
				float v4; // xmm5_4
				/*signed */int v5; // ecx
				float v6; // xmm6_4
				float v7; // xmm2_4
				float v8; // xmm7_4
				float v9; // xmm3_4
				float v10; // xmm0_4
				
				someMatrix = thisMatrix;
				v3 = a2->Roll;
				v4 = E_RotTable_dword_2028088[(v3 >> 2) & 16383];
				v5 = a2->Yaw;
				v6 = E_RotTable_dword_2028088[((int)a2->Pitch >> 2) & 16383];
				v7 = E_RotTable_dword_2028088[(v5 >> 2) & 16383];
				v8 = E_RotTable_dword_2028088[((v3 + 16384) >> 2) & 16383];
				v9 = E_RotTable_dword_2028088[((/*signed */int)(a2->Pitch + 16384) >> 2) & 16383];
				v10 = E_RotTable_dword_2028088[((v5 + 16384) >> 2) & 16383];
				someMatrix->M[0] = v10 * v9;
				someMatrix->M[1] = v9 * v7;
				someMatrix->M[3] = 0.0f;
				someMatrix->M[4] = (float)((float)(v10 * v6) * v4) - (float)(v8 * v7);
				someMatrix->M[2] = v6;
				someMatrix->M[5] = (float)((float)(v7 * v6) * v4) + (float)(v10 * v8);
				someMatrix->M[6] = -0.0f - (float)(v9 * v4);
				someMatrix->M[9] = (float)(v10 * v4) - (float)((float)(v8 * v7) * v6);
				someMatrix->M[7] = 0.0f;
				someMatrix->M[8] = -0.0f - (float)((float)((float)(v10 * v8) * v6) + (float)(v7 * v4));
				someMatrix->M[10] = v9 * v8;
				someMatrix->M[11] = 0.0f;
				someMatrix->M[12] = 0.0f;
				someMatrix->M[13] = 0.0f;
				someMatrix->M[14] = 0.0f;
				someMatrix->M[15] = 1.0f;
				return someMatrix;
			}
			
			static _E_struct_FRotator* /**__thiscall*/ E_Maybe_ConvertMatrixToRotator(_E_struct_Matrix *thisMatrix, _E_struct_FRotator *a2_out)
			{
				/*long */double v2; // st7
				/*long */double v3; // st6
				/*unsigned */int v4; // ecx
				_E_struct_Matrix *v5; // eax
				float v7; // [esp+4h] [ebp-68h]
				float v8; // [esp+4h] [ebp-68h]
				float v9; // [esp+4h] [ebp-68h]
				float v10; // [esp+8h] [ebp-64h]
				float v11; // [esp+Ch] [ebp-60h]
				float v12; // [esp+10h] [ebp-5Ch]
				float v13; // [esp+14h] [ebp-58h]
				float v14; // [esp+18h] [ebp-54h]
				float v15; // [esp+1Ch] [ebp-50h]
				float v16; // [esp+28h] [ebp-44h]
				_E_struct_Matrix someMatrix = default; // [esp+2Ch] [ebp-40h] BYREF

				v2 = thisMatrix->M[0];
				v3 = thisMatrix->M[1];
				v16 = thisMatrix->M[2];
				v13 = thisMatrix->M[4];
				v14 = thisMatrix->M[5];
				v15 = thisMatrix->M[6];
				v10 = thisMatrix->M[8];
				v11 = thisMatrix->M[9];
				v12 = thisMatrix->M[10];
				v7 = atan2(v3, v2) * 32768.0f * 0.3183098861837907f;
				v4 = (int)v7;
				v8 = 32768.0f * atan2(v16, sqrt(v2 * v2 + v3 * v3)) * 0.3183098861837907f;
				a2_out->Yaw = v4;
				a2_out->Pitch = (int)v8;
				a2_out->Roll = 0;
				v5 = E_RotatorToMatrix(&someMatrix, a2_out);
				v9 = atan2(v12 * v5->M[6] + v5->M[5] * v11 + v5->M[4] * v10, v5->M[6] * v15 + v5->M[5] * v14 + v5->M[4] * v13) * 32768.0f * 0.3183098861837907f;
				a2_out->Roll = (int)v9;
				return a2_out;
			}



			public static /*unsigned int __stdcall*/_E_struct_FRotator E_UObject_execQuatToRotator(_E_struct_Quat A)//(int a1, int *a2)
			{
				/*unsigned __int8 *v2; // eax
				int v3; // edx
				int v4; // ecx
				_BYTE *v5; // eax
				int v6; // ecx
				*/
				_E_struct_Matrix *someMatrix; // eax
				_E_struct_FRotator *v8; // eax
				//unsigned int result; // eax
				var position = stackalloc int[ 3 ];//[3]; // [esp+10h] [ebp-5Ch] BYREF
				//_E_struct_Quat A; // [esp+1Ch] [ebp-50h] BYREF
				_E_struct_Matrix matrix = default; // [esp+2Ch] [ebp-40h] BYREF
				/*
				v2 = *(unsigned __int8 **)(a1 + 12);
				v3 = *v2;
				v4 = *(_DWORD *)(a1 + 8);
				*(_DWORD *)(a1 + 12) = v2 + 1;
				((void (__thiscall *)(int, int, _E_struct_Quat *))maybe_UScript_stack_dword_20504E0[v3])(v4, a1, &A);
				v5 = (_BYTE *)++*(_DWORD *)(a1 + 12);
				if ( *v5 == 65 )
				{
					v6 = *(_DWORD *)(a1 + 8);
					*(_DWORD *)(a1 + 12) = v5 + 1;
					off_20505E4(v6, a1, 0);
				}*/
				position[0] = 0;
				position[1] = 0;
				position[2] = 0;
				someMatrix = E_Maybe_MatrixFromQuatPos(&matrix, &A, (_E_struct_FVector *)position);
				/*v8 =*/return *E_Maybe_ConvertMatrixToRotator(someMatrix, (_E_struct_FRotator *)position);
				/**A = *v8;
				*a2 = v8->Pitch;
				a2[1] = v8->Yaw;
				result = v8->Roll;
				a2[2] = result;
				return result;*/
			}
			
			static _E_struct_Matrix */*__thiscall*/ E_Maybe_MatrixFromQuatPos(_E_struct_Matrix *thisMatrix, _E_struct_Quat *a2, _E_struct_FVector *position)
			{
				_E_struct_Matrix *result; // eax
				float v5; // xmm0_4
				float v6; // xmm3_4
				float v7; // xmm1_4
				float v8; // xmm6_4
				float v9; // xmm4_4
				float v10; // xmm2_4
				float v11; // xmm5_4
				float v12; // xmm7_4
				float v13; // xmm0_4
				float v14; // xmm2_4
				float v15; // xmm7_4
				float v16; // xmm3_4
				float v17; // xmm5_4
				float v18; // xmm6_4
				double v19; // st7
				float v20; // [esp+0h] [ebp-8h]
				float v21; // [esp+4h] [ebp-4h]
				float v22; // [esp+Ch] [ebp+4h]

				result = thisMatrix;
				v5 = a2->X;
				v6 = a2->Y;
				v7 = a2->Z * 2.0f;
				v8 = a2->X * 2.0f;
				v9 = v6 * 2.0f;
				v10 = a2->X * (float)(v6 * 2.0);
				v22 = a2->Z * v7;
				v11 = a2->W;
				v20 = v10;
				v12 = v5;
				v13 = v5 * v7;
				v14 = v6 * (float)(v6 * 2.0);
				v21 = v6 * v7;
				v15 = v12 * v8;
				v16 = v11 * v8;
				v17 = v11 * v7;
				v18 = a2->W * v9;
				result->M[0] = 1.0f - (float)(v22 + v14);
				result->M[4] = v20 - v17;
				result->M[8] = v18 + v13;
				result->M[12] = position->X;
				result->M[1] = v17 + v20;
				result->M[5] = 1.0f - (float)(v22 + v15);
				result->M[9] = v21 - v16;
				v19 = position->Y;
				result->M[2] = v13 - v18;
				result->M[13] = (float)v19; // float conversion manually added, explicit double ?
				result->M[10] = 1.0f - (float)(v14 + v15);
				result->M[6] = v16 + v21;
				result->M[14] = position->Z;
				result->M[3] = 0.0f;
				result->M[7] = 0.0f;
				result->M[11] = 0.0f;
				result->M[15] = 1.0f;
				return result;
			}
			
			
			public static _E_struct_FRotator /**__stdcall*/ E_UObject_execRLerp( Rotator A, Rotator B, float Alpha, bool bShortestPath )//(int bShortestPath, _DWORD *a2)
			{
			    /*int v2; // esi
			    unsigned __int8 *v3; // eax
			    int v4; // edx
			    int v5; // ecx
			    unsigned __int8 *v6; // eax
			    int v7; // edx
			    int v8; // ecx
			    unsigned __int8 *v9; // eax
			    int v10; // ecx
			    int v11; // edx
			    unsigned __int8 *v12; // eax
			    int v13; // ecx
			    int v14; // edx
			    int v15; // eax
			    _BYTE *v16; // eax
			    int v17; // ecx
			    */
			    int v18_Delta_Pitch; // ecx
			    int v19_Delta_Yaw; // edx
			    int v20_Delta_Roll; // eax
			    _E_struct_FRotator *v21_func_ret; // eax
			    int v22_Delta_Roll_Alpha; // esi
			    int v23__Delta_Yaw_Alpha; // edx
			    int v24_Yaw_Delta_Yaw_Alpha; // edx
			    int v25_Roll_Delta_Roll_Alpha; // esi
			    _E_struct_FRotator *result; // eax
			    //float Alpha; // [esp+28h] [ebp-38h] BYREF
			    float v28_temp_accum; // [esp+2Ch] [ebp-34h]
			    //_E_struct_FRotator A; // [esp+30h] [ebp-30h] BYREF
			    //_E_struct_FRotator B; // [esp+3Ch] [ebp-24h] BYREF
			    _E_struct_FRotator v31; // [esp+48h] [ebp-18h] BYREF
			    _E_struct_FRotator rotatorB; // [esp+54h] [ebp-Ch] BYREF

			    /*v2 = bShortestPath;
			    v3 = *(unsigned __int8 **)(bShortestPath + 12);
			    v4 = *v3;
			    v5 = *(_DWORD *)(bShortestPath + 8);
			    *(_DWORD *)(bShortestPath + 12) = v3 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FRotator *))maybe_UScript_stack_dword_20504E0[v4])(v5, v2, &A);
			    v6 = *(unsigned __int8 **)(v2 + 12);
			    v7 = *v6;
			    v8 = *(_DWORD *)(v2 + 8);
			    *(_DWORD *)(v2 + 12) = v6 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FRotator *))maybe_UScript_stack_dword_20504E0[v7])(v8, v2, &B);
			    v9 = *(unsigned __int8 **)(v2 + 12);
			    v10 = *(_DWORD *)(v2 + 8);
			    Alpha = 0.0;
			    v11 = *v9;
			    *(_DWORD *)(v2 + 12) = v9 + 1;
			    ((void (__thiscall *)(int, int, float *))maybe_UScript_stack_dword_20504E0[v11])(v10, v2, &Alpha);
			    dword_201872C &= 0xFFFFFFFD;
			    v12 = *(unsigned __int8 **)(v2 + 12);
			    v13 = *(_DWORD *)(v2 + 8);
			    bShortestPath = 0;
			    v14 = *v12;
			    *(_DWORD *)(v2 + 12) = v12 + 1;
			    ((void (__thiscall *)(int, int, int *))maybe_UScript_stack_dword_20504E0[v14])(v13, v2, &bShortestPath);
			    v15 = bShortestPath != 0;
			    ++*(_DWORD *)(v2 + 12);
			    bShortestPath = v15;
			    v16 = *(_BYTE **)(v2 + 12);
			    if ( *v16 == 65 )
			    {
			        v17 = *(_DWORD *)(v2 + 8);
			        *(_DWORD *)(v2 + 12) = v16 + 1;
			        off_20505E4(v17, v2, 0);
			    }*/
			    v18_Delta_Pitch = B.Pitch - A.Pitch;
			    v19_Delta_Yaw = B.Yaw - A.Yaw;
			    v20_Delta_Roll = B.Roll - A.Roll;
			    v31.Pitch = B.Pitch - A.Pitch;
			    v31.Yaw = B.Yaw - A.Yaw;
			    v31.Roll = B.Roll - A.Roll;
			    if ( bShortestPath )
			    {
			        v21_func_ret = E_Rotator_ShortestPath(&v31, &rotatorB);
			        v18_Delta_Pitch = v21_func_ret->Pitch;
			        v19_Delta_Yaw = v21_func_ret->Yaw;
			        v20_Delta_Roll = v21_func_ret->Roll;
			    }
			    v28_temp_accum = (float)v20_Delta_Roll * Alpha;
			    v22_Delta_Roll_Alpha = (int)v28_temp_accum;
			    v28_temp_accum = (float)v19_Delta_Yaw * Alpha;
			    v23__Delta_Yaw_Alpha = (int)v28_temp_accum;
			    v28_temp_accum = (float)v18_Delta_Pitch * Alpha;
			    v24_Yaw_Delta_Yaw_Alpha = A.Yaw + v23__Delta_Yaw_Alpha;
			    v25_Roll_Delta_Roll_Alpha = A.Roll + v22_Delta_Roll_Alpha;
			    /*result = (_E_struct_FRotator *)a2;
			    *a2 = (int)v28_temp_accum + A.Pitch;*/
			    result = default;
			    result->Pitch = (int)(v28_temp_accum + A.Pitch);
			    result->Yaw = v24_Yaw_Delta_Yaw_Alpha;
			    result->Roll = v25_Roll_Delta_Roll_Alpha;
			    return *result;
			}
			
			static _E_struct_FRotator */*__thiscall*/ E_Rotator_ShortestPath(_E_struct_FRotator *thisRotator, _E_struct_FRotator *rotatorB)
			{
				_E_struct_FRotator *result; // eax
				uint v3; // edx
				uint v4; // ecx
				uint v5; // ecx
				uint v6; // ecx
				uint v7; // ecx

				result = rotatorB;
				rotatorB->Pitch = thisRotator->Pitch;
				v3 = (uint)thisRotator->Yaw;
				v4 = (uint)thisRotator->Roll;
				rotatorB->Yaw = (int)v3;
				rotatorB->Roll = (int)v4;
				v5 = /*(unsigned __int16)*/(System.UInt16)rotatorB->Pitch;
				if ( v5 > 32767 )
					v5 -= 65536;
				rotatorB->Pitch = (int)v5;
				v6 = /*(unsigned __int16)*/(System.UInt16)rotatorB->Roll;
				if ( v6 > 32767 )
					v6 -= 65536;
				rotatorB->Roll = (int)v6;
				v7 = /*(unsigned __int16)*/(System.UInt16)rotatorB->Yaw;
				if ( v7 > 32767 )
					v7 -= 65536;
				rotatorB->Yaw = (int)v7;
				return result;
			}
			
			
			public static float /*__userpurge*/ E_UObject_execGetAxes(Object.Rotator A, ref Object.Vector X, ref Object.Vector Y, ref Object.Vector Z)//@<eax>(int a1, int _C0)
			{
				/*
			    unsigned __int8 *v2; // eax
			    int v3; // edx
			    int v4; // ecx
			    unsigned __int8 *v5; // eax
			    int v6; // edx
			    int v7; // ecx
			    unsigned __int8 *v8; // eax
			    int v9; // edx
			    int v10; // ecx
			    _E_struct_FVector *refToY; // ebx
			    unsigned __int8 *v12; // eax
			    int v13; // edx
			    int v14; // ecx
			    _E_struct_FVector *refToZ; // edi
			    _BYTE *v16; // eax
			    int v17; // ecx
			    */
			    float v18; // xmm0_4
			    float v19; // ecx
			    float v20; // xmm0_4
			    float v21; // xmm0_4
			    float v22; // ecx
			    float v23; // xmm0_4
			    float v24; // edx
			    float v25; // xmm0_4
			    float result; // eax
			    float v27; // xmm0_4
			    //_E_struct_FVector *refToX; // [esp+34h] [ebp-80h]
			    float v29; // [esp+38h] [ebp-7Ch]
			    float v30; // [esp+38h] [ebp-7Ch]
			    float v31; // [esp+3Ch] [ebp-78h]
			    float v32; // [esp+40h] [ebp-74h]
			    /*_E_struct_FVector X; // [esp+44h] [ebp-70h] BYREF
			    _E_struct_FVector Y; // [esp+50h] [ebp-64h] BYREF
			    _E_struct_FVector Z; // [esp+5Ch] [ebp-58h] BYREF
			    _E_struct_FRotator A; // [esp+68h] [ebp-4Ch] BYREF
			    */
			    _E_struct_Matrix matrixFromRotator; // [esp+74h] [ebp-40h] BYREF
/*
			    v2 = *(unsigned __int8 **)(a1 + 12);
			    v3 = *v2;
			    v4 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v2 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FRotator *))maybe_UScript_stack_dword_20504E0[v3])(v4, a1, &A);
			    dword_2018724 = 0;
			    v5 = *(unsigned __int8 **)(a1 + 12);
			    v6 = *v5;
			    v7 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v5 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v6])(v7, a1, &X);
			    if ( dword_2018728 )
			        (*(void (__thiscall **)(int, int))(*(_DWORD *)dword_2018728 + 184))(dword_2018728, dword_201871C);
			    if ( dword_2018724 )
			        refToX = (_E_struct_FVector *)dword_2018724;
			    else
			        refToX = &X;
			    dword_2018724 = 0;
			    v8 = *(unsigned __int8 **)(a1 + 12);
			    v9 = *v8;
			    v10 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v8 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v9])(v10, a1, &Y);
			    if ( dword_2018728 )
			        (*(void (__thiscall **)(int, int))(*(_DWORD *)dword_2018728 + 184))(dword_2018728, dword_201871C);
			    refToY = (_E_struct_FVector *)dword_2018724;
			    if ( !dword_2018724 )
			        refToY = &Y;
			    dword_2018724 = 0;
			    v12 = *(unsigned __int8 **)(a1 + 12);
			    v13 = *v12;
			    v14 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v12 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v13])(v14, a1, &Z);
			    if ( dword_2018728 )
			        (*(void (__thiscall **)(int, int))(*(_DWORD *)dword_2018728 + 184))(dword_2018728, dword_201871C);
			    refToZ = (_E_struct_FVector *)dword_2018724;
			    if ( !dword_2018724 )
			        refToZ = &Z;
			    v16 = (_BYTE *)++*(_DWORD *)(a1 + 12);
			    if ( *v16 == 65 )
			    {
			        v17 = *(_DWORD *)(a1 + 8);
			        *(_DWORD *)(a1 + 12) = v16 + 1;
			        off_20505E4(v17, a1, 0);
			    }*/

				fixed(Object.Vector* refToX = &X)
					fixed(Object.Vector* refToY = &Y)
						fixed( Object.Vector* refToZ = & Z )
						{
			    E_RotatorToMatrix(&matrixFromRotator, &A);
			    v18 = matrixFromRotator.M[2];
			    v19 = matrixFromRotator.M[1];
			    refToX->X = matrixFromRotator.M[0];
			    v32 = v18;
			    v20 = matrixFromRotator.M[4];
			    refToX->Y = v19;
			    v29 = v20;
			    v21 = matrixFromRotator.M[5];
			    refToX->Z = v32;
			    v22 = v21;
			    v23 = matrixFromRotator.M[8];
			    v24 = matrixFromRotator.M[6];
			    refToY->X = v29;
			    refToY->Y = v22;
			    v30 = v23;
			    v25 = matrixFromRotator.M[9];
			    result = v30;
			    refToY->Z = v24;
			    v31 = v25;
			    v27 = matrixFromRotator.M[10];
			    refToZ->X = v30;
			    refToZ->Y = v31;
			    refToZ->Z = v27;
			    return result;
						}
			}
			
			public static float /*__userpurge*/ E_UObject_execGetUnAxes(Object.Rotator A, ref Object.Vector X, ref Object.Vector Y, ref Object.Vector Z)//@<eax>(int a1, int _100)
			{
			    /*
				unsigned __int8 *v2; // eax
			    int v3; // edx
			    int v4; // ecx
			    unsigned __int8 *v5; // eax
			    int v6; // edx
			    int v7; // ecx
			    unsigned __int8 *v8; // eax
			    int v9; // edx
			    int v10; // ecx
			    _E_struct_FVector *refToY; // ebx
			    unsigned __int8 *v12; // eax
			    int v13; // edx
			    int v14; // ecx
			    _E_struct_FVector *refToZ; // edi
			    _BYTE *v16; // eax
			    int v17; // ecx
			    */
			    _E_struct_Matrix *matrixRotRet; // eax
			    float v19; // xmm0_4
			    float v20; // edx
			    float v21; // xmm0_4
			    float v22; // xmm0_4
			    float v23; // eax
			    float v24; // xmm0_4
			    float v25; // ecx
			    float v26; // xmm0_4
			    float v27; // xmm0_4
			    float result; // eax
			    float v29; // [esp+34h] [ebp-C0h]
			    float v30; // [esp+34h] [ebp-C0h]
			    float v31; // [esp+38h] [ebp-BCh]
			    float v32; // [esp+3Ch] [ebp-B8h]
			    //_E_struct_FVector *refToX; // [esp+40h] [ebp-B4h]
			    //_E_struct_FVector Y; // [esp+44h] [ebp-B0h] BYREF
			    //_E_struct_FRotator A; // [esp+50h] [ebp-A4h] BYREF
			    //_E_struct_FVector X; // [esp+5Ch] [ebp-98h] BYREF
			    //_E_struct_FVector Z; // [esp+68h] [ebp-8Ch] BYREF
			    _E_struct_Matrix matrixInverse; // [esp+74h] [ebp-80h] BYREF
			    _E_struct_Matrix matrixRotStack; // [esp+B4h] [ebp-40h] BYREF

			    /*v2 = *(unsigned __int8 **)(a1 + 12);
			    v3 = *v2;
			    v4 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v2 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FRotator *))maybe_UScript_stack_dword_20504E0[v3])(v4, a1, &A);
			    dword_2018724 = 0;
			    v5 = *(unsigned __int8 **)(a1 + 12);
			    v6 = *v5;
			    v7 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v5 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v6])(v7, a1, &X);
			    if ( dword_2018728 )
			        (*(void (__thiscall **)(int, int))(*(_DWORD *)dword_2018728 + 184))(dword_2018728, dword_201871C);
			    if ( dword_2018724 )
			        refToX = (_E_struct_FVector *)dword_2018724;
			    else
			        refToX = &X;
			    dword_2018724 = 0;
			    v8 = *(unsigned __int8 **)(a1 + 12);
			    v9 = *v8;
			    v10 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v8 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v9])(v10, a1, &Y);
			    if ( dword_2018728 )
			        (*(void (__thiscall **)(int, int))(*(_DWORD *)dword_2018728 + 184))(dword_2018728, dword_201871C);
			    refToY = (_E_struct_FVector *)dword_2018724;
			    if ( !dword_2018724 )
			        refToY = &Y;
			    dword_2018724 = 0;
			    v12 = *(unsigned __int8 **)(a1 + 12);
			    v13 = *v12;
			    v14 = *(_DWORD *)(a1 + 8);
			    *(_DWORD *)(a1 + 12) = v12 + 1;
			    ((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v13])(v14, a1, &Z);
			    if ( dword_2018728 )
			        (*(void (__thiscall **)(int, int))(*(_DWORD *)dword_2018728 + 184))(dword_2018728, dword_201871C);
			    refToZ = (_E_struct_FVector *)dword_2018724;
			    if ( !dword_2018724 )
			        refToZ = &Z;
			    v16 = (_BYTE *)++*(_DWORD *)(a1 + 12);
			    if ( *v16 == 65 )
			    {
			        v17 = *(_DWORD *)(a1 + 8);
			        *(_DWORD *)(a1 + 12) = v16 + 1;
			        off_20505E4(v17, a1, 0);
			    }*/

			    fixed(Object.Vector* refToX = &X)
				    fixed(Object.Vector* refToY = &Y)
					    fixed( Object.Vector* refToZ = & Z )
					    {
			    matrixRotRet = E_RotatorToMatrix(&matrixRotStack, &A);
			    E_InverseMatrix(matrixRotRet, &matrixInverse);
			    v19 = matrixInverse.M[2];
			    v20 = matrixInverse.M[1];
			    refToX->X = matrixInverse.M[0];
			    v32 = v19;
			    v21 = matrixInverse.M[4];
			    refToX->Y = v20;
			    v29 = v21;
			    v22 = matrixInverse.M[5];
			    refToX->Z = v32;
			    v23 = v22;
			    v24 = matrixInverse.M[8];
			    v25 = matrixInverse.M[6];
			    refToY->X = v29;
			    refToY->Y = v23;
			    v30 = v24;
			    v26 = matrixInverse.M[9];
			    refToY->Z = v25;
			    v31 = v26;
			    v27 = matrixInverse.M[10];
			    result = v31;
			    refToZ->X = v30;
			    refToZ->Y = v31;
			    refToZ->Z = v27;
			    return result;
						}
			}
			
			static _E_struct_Matrix */*__thiscall*/ E_InverseMatrix(_E_struct_Matrix *thisMatrix, _E_struct_Matrix *a2)
			{
				_E_struct_Matrix *result; // eax

				result = a2;
				a2->M[0] = thisMatrix->M[0];
				a2->M[1] = thisMatrix->M[4];
				a2->M[2] = thisMatrix->M[8];
				a2->M[3] = thisMatrix->M[12];
				a2->M[4] = thisMatrix->M[1];
				a2->M[5] = thisMatrix->M[5];
				a2->M[6] = thisMatrix->M[9];
				a2->M[7] = thisMatrix->M[13];
				a2->M[8] = thisMatrix->M[2];
				a2->M[9] = thisMatrix->M[6];
				a2->M[10] = thisMatrix->M[10];
				a2->M[11] = thisMatrix->M[14];
				a2->M[12] = thisMatrix->M[3];
				a2->M[13] = thisMatrix->M[7];
				a2->M[14] = thisMatrix->M[11];
				a2->M[15] = thisMatrix->M[15];
				return result;
			}
			
			public static _E_struct_FVector /**__stdcall*/ UObject_execGreaterGreater_VectorRotator( Vector A, Rotator B )//(int a1, _E_struct_FVector *arg4)
			{
				/*
				unsigned __int8 *v2; // eax
				int v3; // edx
				int v4; // ecx
				unsigned __int8 *v5; // eax
				int v6; // edx
				int v7; // ecx
				_BYTE *v8; // eax
				int v9; // ecx
				*/
				_E_struct_Matrix *v10; // eax
				float v11; // xmm0_4
				float v12; // xmm1_4
				float v13; // xmm2_4
				float v14; // xmm3_4
				_E_struct_FVector *result; // eax
				//_E_struct_FVector A; // [esp+18h] [ebp-58h] BYREF
				//_E_struct_FRotator B; // [esp+24h] [ebp-4Ch] BYREF
				_E_struct_Matrix thisMatrix; // [esp+30h] [ebp-40h] BYREF

				/*
				v2 = *(unsigned __int8 **)(a1 + 12);
				v3 = *v2;
				v4 = *(_DWORD *)(a1 + 8);
				*(_DWORD *)(a1 + 12) = v2 + 1;
				((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v3])(v4, a1, &A);
				v5 = *(unsigned __int8 **)(a1 + 12);
				v6 = *v5;
				v7 = *(_DWORD *)(a1 + 8);
				*(_DWORD *)(a1 + 12) = v5 + 1;
				((void (__thiscall *)(int, int, _E_struct_FRotator *))maybe_UScript_stack_dword_20504E0[v6])(v7, a1, &B);
				v8 = (_BYTE *)++*(_DWORD *)(a1 + 12);
				if ( *v8 == 65 )
				{
					v9 = *(_DWORD *)(a1 + 8);
					*(_DWORD *)(a1 + 12) = v8 + 1;
					off_20505E4(v9, a1, 0);
				}*/
				v10 = E_RotatorToMatrix(&thisMatrix, &B);
				v11 = (float)((float)((float)(v10->M[4] * A.Y) + (float)(v10->M[8] * A.Z)) + (float)(v10->M[0] * A.X)) + (float)(v10->M[12] * 0.0);
				v12 = (float)((float)((float)(v10->M[1] * A.X) + (float)(v10->M[5] * A.Y)) + (float)(v10->M[9] * A.Z)) + (float)(v10->M[13] * 0.0);
				v13 = (float)((float)(v10->M[2] * A.X) + (float)(v10->M[6] * A.Y)) + (float)(v10->M[10] * A.Z);
				v14 = v10->M[14];
				return new Vector()
				{
					X = v11,
					Y = v12,
					Z = v13 + (float)(v14 * 0.0),
				};
				/*result = arg4;
				arg4->X = v11;
				arg4->Y = v12;
				arg4->Z = v13 + (float)(v14 * 0.0);
				return result;*/
			}
			
			public static _E_struct_FVector /**__stdcall*/ UObject_execLessLess_VectorRotator(_E_struct_FVector A, Rotator B)//(int a1, _E_struct_FVector *arg4)
			{
				/*
				unsigned __int8 *v2; // eax
				int v3; // edx
				int v4; // ecx
				unsigned __int8 *v5; // eax
				int v6; // edx
				int v7; // ecx
				_BYTE *v8; // eax
				int v9; // ecx
				*/
				_E_struct_Matrix *v10; // eax
				_E_struct_Matrix *v11; // eax
				float v12; // xmm0_4
				float v13; // xmm1_4
				float v14; // xmm2_4
				float v15; // xmm3_4
				_E_struct_FVector *result; // eax
				//_E_struct_FVector A; // [esp+18h] [ebp-98h] BYREF
				//_E_struct_FRotator B; // [esp+24h] [ebp-8Ch] BYREF
				_E_struct_Matrix a2; // [esp+30h] [ebp-80h] BYREF
				_E_struct_Matrix thisMatrix; // [esp+70h] [ebp-40h] BYREF
				/*
				v2 = *(unsigned __int8 **)(a1 + 12);
				v3 = *v2;
				v4 = *(_DWORD *)(a1 + 8);
				*(_DWORD *)(a1 + 12) = v2 + 1;
				((void (__thiscall *)(int, int, _E_struct_FVector *))maybe_UScript_stack_dword_20504E0[v3])(v4, a1, &A);
				v5 = *(unsigned __int8 **)(a1 + 12);
				v6 = *v5;
				v7 = *(_DWORD *)(a1 + 8);
				*(_DWORD *)(a1 + 12) = v5 + 1;
				((void (__thiscall *)(int, int, _E_struct_FRotator *))maybe_UScript_stack_dword_20504E0[v6])(v7, a1, &B);
				v8 = (_BYTE *)++*(_DWORD *)(a1 + 12);
				if ( *v8 == 65 )
				{
					v9 = *(_DWORD *)(a1 + 8);
					*(_DWORD *)(a1 + 12) = v8 + 1;
					off_20505E4(v9, a1, 0);
				}*/
				v10 = E_RotatorToMatrix(&thisMatrix, &B);
				v11 = E_InverseMatrix(v10, &a2);
				v12 = (float)((float)((float)(v11->M[4] * A.Y) + (float)(v11->M[8] * A.Z)) + (float)(v11->M[0] * A.X)) + (float)(v11->M[12] * 0.0);
				v13 = (float)((float)((float)(v11->M[1] * A.X) + (float)(v11->M[5] * A.Y)) + (float)(v11->M[9] * A.Z)) + (float)(v11->M[13] * 0.0);
				v14 = (float)((float)(v11->M[2] * A.X) + (float)(v11->M[6] * A.Y)) + (float)(v11->M[10] * A.Z);
				v15 = v11->M[14];
				return new Vector()
				{
					X = v12,
					Y = v13,
					Z = v14 + (float)(v15 * 0.0),
				};
				/*result = arg4;
				arg4->X = v12;
				arg4->Y = v13;
				arg4->Z = v14 + (float)(v15 * 0.0);
				return result;*/
			}
		}
	}
}