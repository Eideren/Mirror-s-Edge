namespace MEdge.Engine{
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

	public partial class AnimNodeAimOffset
	{
		// Export UAnimNodeAimOffset::execSetActiveProfileByName(FFrame&, void* const)
		public virtual /*native function */void SetActiveProfileByName(name ProfileName)
		{
			if(TemplateNode != null)
			{
				// Look through profiles to find a name that matches.
				for(var i=0; i<TemplateNode.Profiles.Length; i++)
				{
					// Found it - change to it.
					if(TemplateNode.Profiles[i].ProfileName == ProfileName)
					{
						SetActiveProfileByIndex(i);
						return;
					}
				}
			}
			else
			{
				// Look through profiles to find a name that matches.
				for(var i=0; i<Profiles.Length; i++)
				{
					// Found it - change to it.
					if(Profiles[i].ProfileName == ProfileName)
					{
						SetActiveProfileByIndex(i);
						return;
					}
				}
			}
		}
	}
}