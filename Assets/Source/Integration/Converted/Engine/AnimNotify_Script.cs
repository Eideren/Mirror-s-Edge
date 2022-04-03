namespace MEdge.Engine{
	using System;
	using Core; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdGame; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class AnimNotify_Script : AnimNotify/*
		native
		editinlinenew
		collapsecategories
		hidecategories(Object)*/{
	[Category] public name NotifyName;
	
	public override void Notify( AnimNodeSequence NodeSeq )
	{
		Actor Owner = NodeSeq.SkelComponent.GetOwner();
		if( Owner && NotifyName != NAME_None )
		{
			UWorldBridge.GetUWorld().BuildCallableFunction(NotifyName, Owner).Invoke();
			/*if( !GWorld->HasBegunPlay() )
			{
				debugf( NAME_Log, TEXT("Editor: skipping AnimNotify_Script %s"), *NotifyName.ToString() );
			}
			else
			{
				Function Function = Owner.FindFunction( NotifyName );
				if( Function )
				{
					if( Function.FunctionFlags & FUNC_Delegate )
					{
						UDelegateProperty* DelegateProperty = FindField<UDelegateProperty>( Owner->GetClass(), *FString::Printf(TEXT("__%s__Delegate"),*NotifyName.ToString()) );
						FScriptDelegate* ScriptDelegate = (FScriptDelegate*)((BYTE*)Owner + DelegateProperty->Offset);
						Owner.ProcessDelegate( NotifyName, ScriptDelegate, NULL );
					}
					else
					{
						Owner.ProcessEvent( Function, NULL );								
					}
				}
			}*/
		}

	}
}
}