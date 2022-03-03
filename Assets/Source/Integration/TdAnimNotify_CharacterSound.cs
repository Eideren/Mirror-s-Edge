namespace MEdge.TdGame
{
  using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;
	
	public partial class TdAnimNotify_CharacterSound
  {
    public override void Notify(AnimNodeSequence AnimSeqInstigator)
		{
			SkeletalMeshComponent skelComp; // esi
      Actor owner; // ecx
      int bUseLocation; // ebx
      Actor v6; // eax
      TdPawn tdPawn; // eax
      //Vector *v8; // eax
      float posX; // ebp
      float posY; // edi
      float posZ; // esi
      PlayerController v12; // eax
      int v13; // eax
      SoundCue soundCue; // [esp+14h] [ebp-1Ch]
      //name v15; // [esp+18h] [ebp-18h] BYREF
      float v16; // [esp+20h] [ebp-10h]
      Vector a2a; // [esp+24h] [ebp-Ch] BYREF
      TdPawn tdPawn2; // [esp+34h] [ebp+4h]

      skelComp = AnimSeqInstigator.SkelComponent;
      owner = skelComp.Owner;
      bUseLocation = 0;
      if ( owner )
      {
        v6 = owner as Pawn;//(AActor *)(*(int (**)(void))(owner.VfTableObject.Dummy + 720))();// 0xB5F7A0, 0xB99630 => this, Probably GetAPawn()
        tdPawn = v6 as TdPawn;
        tdPawn2 = tdPawn;
        if ( tdPawn )
        {
          if ( tdPawn.Controller )
          {
            soundCue = tdPawn.GetCharacterSound_Maybe((uint)this.TriggerType, 1);// ATdPawn::GetCharacterSound_Maybe
            if ( soundCue )
            {
              a2a.X = 0.0f;
              a2a.Y = 0.0f;
              a2a.Z = 0.0f;
              /*v15.Index = 0;
              v15.Number = 0;*/
              if ( this.BoneName != default )
              {
                bUseLocation = 1;
                a2a = skelComp.GetBoneLocation(this.BoneName, 0);
                posX = a2a.X;
                posY = a2a.Y;
                posZ = a2a.Z;
              }
              else if ( (this.bFollowActor) != default )
              {
                posZ = a2a.Z;
                posY = a2a.Y;
                posX = a2a.X;
              }
              else
              {
                posY = skelComp.LocalToWorld.WPlane.Y;
                posX = skelComp.LocalToWorld.WPlane.X;
                v16 = skelComp.LocalToWorld.WPlane.Z;
                posZ = v16;
                bUseLocation = 1;
              }

              UWorldBridge.GetUWorld().PlaySoundCue(soundCue, owner, bUseLocation!=0, new Vector(posX, posY, posZ));
              /*v12 = (APlayerController *)sub_5D95A0(tdPawn2.Controller);
              if ( v12 )
              {
                v13 = (*(int (__stdcall **)(int, AActor *__ptr32, _DWORD, int, float, float, float))(v12.VfTableObject.Dummy + 1024))(soundCue, owner, 0, bUseLocation, COERCE_FLOAT(LODWORD(posX)), COERCE_FLOAT(LODWORD(posY)), COERCE_FLOAT(LODWORD(posZ)));// GetPooledAudioComponent
                if ( v13 )
                {
                  *(_DWORD *)(v13 + 108) ^= (*(_DWORD *)(v13 + 108) ^ ((GIsGame == 0) << 12)) & 0x1000;
                  *(_DWORD *)(v13 + 108) &= ((_WORD)GIsGame << 11) | 0xFFFFF7FF;
                  sub_B6A240(v13);
                }
              }*/
            }
          }
        }
      }
		}
	}
}