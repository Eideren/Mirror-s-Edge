namespace MEdge.TdGame
{
	public partial class TdPawn
	{
        public virtual /*native function */float GetAverageSpeed(float Time)
        {
            #warning need to populate those arrays before this works, have a dummy return for now
            return Velocity.Size();
            
            float paramFloat = Time;
            
            float v2; // xmm2_4
            float v3; // xmm3_4
            float v4; // xmm1_4
            float v5; // xmm0_4
            int v6; // ebx
            int v7; // edx
            double result; // st7
            int v9; // eax
            int v10; // eax
            array<float> v11; // esi
            array<float> v12; // edi
            int v13; // ebp
            int v14; // eax
            int v15; // edx
            int v16; // ecx
            float v17; // xmm2_4
            float v18; // xmm4_4
            int v19; // ecx
            float v20; // xmm1_4
            float v21; // xmm3_4
            int v22; // ecx
            int v23; // ebx
            float v24; // xmm0_4
            int v25; // esi
            int v26; // edi
            int v27; // ecx
            int v28; // edx
            int v29; // eax
            int v30; // [esp+0h] [ebp-20h]
            int v31; // [esp+4h] [ebp-1Ch]
            int v32; // [esp+Ch] [ebp-14h]
            int v33; // [esp+10h] [ebp-10h]
            TdPawn v34; // [esp+14h] [ebp-Ch]
            int v35; // [esp+18h] [ebp-8h]
            int v36; // [esp+1Ch] [ebp-4h]
            array<float> asDistanceData; // [esp+1Ch] [ebp-4h]
            int paramFloata; // [esp+24h] [ebp+4h]
            array<float> asTimeData; // [esp+24h] [ebp+4h]

            v2 = this.ASFilterTime;
            v3 = paramFloat;
            v34 = this;
            v4 = 0.0f;
            v5 = 0.0f;
            if ( paramFloat >= v2 )
                v3 = this.ASFilterTime;
            v6 = this.ASPollSlots;
            v7 = (int)(float)((float)((float)v6 * v3) / v2);
            paramFloata = v6;
            v35 = v7;
            if ( v7 <= 0 )
                return 0.0f;
            v9 = 0;
            if ( v7 >= 4 )
            {
                v10 = this.ASSlotPointer;
                v11 = this.ASTimeData;
                v12 = this.ASDistanceData;
                v31 = v10 - 2;
                v30 = v10;
                v13 = v10 + v6 - 2;
                v14 = 4 * (v10 - 2);
                v32 = 1 - v6;
                v15 = (int)(((uint)(v7 - 4) >> 2) + 1);
                v33 = -1 - v6;
                v36 = 4 * v15;
                do
                {
                    v16 = v14 + 8;
                    if ( v30 < 0 )
                        v16 += 4 * v6;
                    v17 = v11[v16 / 4] + v4;
                    v18 = v12[v16 / 4] + v5;
                    v19 = v14 + 4;
                    if ( v13 + v32 < 0 )
                        v19 += 4 * paramFloata;
                    v20 = v11[v19 / 4] + v17;
                    v21 = v12[v19 / 4] + v18;
                    v22 = v14;
                    if ( v31 < 0 )
                        v22 = v14 + 4 * paramFloata;
                    v23 = v14 - 4;
                    if ( v13 + v33 < 0 )
                        v23 += 4 * paramFloata;
                    v30 -= 4;
                    v31 -= 4;
                    v4 = v11[v23 / 4] + (v11[v22 / 4] + v20);
                    v24 = v12[v23 / 4];
                    v6 = paramFloata;
                    v14 -= 16;
                    v13 -= 4;
                    --v15;
                    v5 = v24 + v12[v22 / 4] + v21;
                }
                while ( v15>0 );
                v7 = v35;
                v9 = v36;
            }
            if ( v9 < v7 )
            {
                asTimeData = this.ASTimeData;
                asDistanceData = this.ASDistanceData;
                v25 = this.ASSlotPointer - v9;
                v26 = v25 + v6;
                v27 = 4 * v25;
                v28 = v7 - v9;
                do
                {
                    v29 = v27;
                    if ( v25 < 0 )
                        v29 = v27 + 4 * v6;
                    v4 = asTimeData[v29 / 4] + v4;
                    v27 -= 4;
                    --v25;
                    --v26;
                    --v28;
                    v5 = asDistanceData[v29 / 4] + v5;
                }
                while ( v28 > 0 );
            }

            if( v5 == 0.0f )
                return 0f;
            else
                return (v5 / v4);
        }
	}
}