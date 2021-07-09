namespace MEdge.TdGame{
	using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class TdAnimNodeSlot
	{
		// Export UTdAnimNodeSlot::execSetBlendOutTime(FFrame&, void* const)
		public virtual /*native function */void SetBlendOutTime(float BlendTime)
		{
			// maybe ?
			this.BlendTimeToGo = BlendTime < 0f ? 0f : BlendTime;
		}
	}
}