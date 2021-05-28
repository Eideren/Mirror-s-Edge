namespace MEdge.TdTuContent{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdEditor;

public partial class TdTutorialMessage : TdLocalMessage{
	public /*const localized */array</*localized */string> MCDesc;
	
	public /*function */static string GetString(/*optional */int Switch = default, /*optional */bool bPRI1HUD = default, /*optional */PlayerReplicationInfo Killer = default, /*optional */PlayerReplicationInfo Victim = default, /*optional */Object OptionalObject = default)
	{
	
		return default;
	}
	
	public TdTutorialMessage()
	{
		// Object Offset:0x00002608
		MCDesc = new array</*localized */string>
		{
			"<StringAliasMap:Accept> Now time you jump carefully and make it to the next roopf.",
			"<StringAliasMap:Accept> Run towards the fence and vault over it by timing your jump",
			"<StringAliasMap:Accept> Jump to the next roof and slide under the prop",
			"<StringAliasMap:Accept> Vault over that object by running at it and jumping when you get close",
			"<StringAliasMap:Accept> Try and do a wallrun by running towards the sign at an angle at approximately 28.9 degrees",
			"Wallrun up this sign by running towards it and jumping close to it",
			"Barge open the door by running at it and attacking close to it",
			"Balance across this beam.",
			"Climb upp the pipe",
			"Jump over to the pipe next to you",
			"Jump over to the ledge and heave yourself up",
			"Remember the wallrun? Do it again, but turn 180 and jump out from it",
			"Wallrun up this .. thing...and grab the edge",
			"Now turn around and jump to the mysteriously short ladder",
			"Want to loose some skin on your fingers? Use this steel line to slide down",
			"Release the line to land on the tarp covering this pile of concrete blocks",
			"Now run along this wall and then jump out from it, to the hanging beams",
			"Jump high using these boxes as a stepping stone. If you want, try pulling your feet up to clear the edge after",
			"Freeestyle maaan",
			"Now go back to where you started",
		};
		MessageArea = TdLocalMessage.EMessageArea.EMA_Centered;
		bDrawOutline = true;
		Lifetime = 6.0f;
		PosY = 0.90f;
	}
}
}