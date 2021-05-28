namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdAIVoiceOverData : Object{
	public array<TdAIVoiceOverManager.AIVoiceOver> VOs;
	public array<SoundCue> RadioStart;
	public array<SoundCue> RadioStop;
	public int FirstVO;
	public int LastVo;
	
}
}