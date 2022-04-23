namespace MEdge.Source
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.CompilerServices;
	using Core;
	using Engine;
	using TdGame;
	using static UnityEngine.Debug;
	using Object = Core.Object;
	using String = Core.String;



	public static partial class Asset
	{
		public static HashSet<string> NotImplementedFor = new HashSet<string>();
		public static ConditionalWeakTable<object, UnityEngine.Object> UScriptToUnity = new();
		private static AssetDB _assetDB;


		public static UnityEngine.AudioClip GetClip(name path, bool skipLoadAll = false)
		{
			path = path.ToString().Replace( '.', '/' );

			UnityEngine.AudioClip clip = null;
			
			if( _clips.TryGetValue( path, out clip ) )
				return clip;
			
			clip ??= UnityEngine.Resources.Load<UnityEngine.AudioClip>( path );
			
			_assetDB ??= UnityEngine.Resources.Load<AssetDB>("AssetDB");
			if (clip == null && _assetDB.NameToPath.TryGetValue(path, out var actualPath))
				clip = UnityEngine.Resources.Load<UnityEngine.AudioClip>( actualPath );
			
			if(clip == null && path.ToString().LastIndexOf( '.' ) is int i && i != -1 )
			{
				name shortName = path.ToString().Substring( i + 1 );
				_clips.TryGetValue(shortName, out clip);
				
				if (clip == null && _assetDB.NameToPath.TryGetValue(shortName, out actualPath))
					clip = UnityEngine.Resources.Load<UnityEngine.AudioClip>( actualPath );
			}
			
			_clips.Add( path, clip );
			return clip;
		}



		static Dictionary<name, UnityEngine.AudioClip> _clips = new();

		static Dictionary<string, PhysicalMaterial> _physMat = new();
		static Dictionary<string, Material> _Mat = new();



		public class DummyMaterial : Material
		{
			public override Material GetMaterial() => this;
			public override PhysicalMaterial GetPhysicalMaterial() => this.PhysMaterial;
		}



		public static Material GetDefaultMatFor(string matType)
		{
			if( _Mat.TryGetValue( matType, out var output ) )
				return output;

			output = new DummyMaterial {PhysMaterial = GetDefaultPhysMat( matType )};
			
			_Mat.Add(matType, output);
			return output;
		}



		public static PhysicalMaterial GetDefaultPhysMat(string matType)
		{
			if( _physMat.TryGetValue( matType, out var output ) )
				return output;
			
			output = new PhysicalMaterial
			{
				PhysicalMaterialProperty = new TdPhysicalMaterialProperty
				{
					TdPhysicalMaterialFootSteps = new TdPhysicalMaterialFootSteps
					{
						_01_Female_FootStepCrouch = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._01_Female_FootStepCrouch)}" ),
						_02_Female_FootStepWalk = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._02_Female_FootStepWalk)}" ),
						_03_Female_FootStepRun = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._03_Female_FootStepRun)}" ),
						_04_Female_FootStepSprint = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._04_Female_FootStepSprint)}" ),
						_05_Female_FootStepSprintRelease = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._05_Female_FootStepSprintRelease)}" ),
						_06_Female_FootStepWallRun = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._06_Female_FootStepWallRun)}" ),
						_07_Female_FootStepWallrunRelease = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._07_Female_FootStepWallrunRelease)}" ),
						_08_Female_FootStepLandSoft = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._08_Female_FootStepLandSoft)}" ),
						_09_Female_FootStepLandMedium = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._09_Female_FootStepLandMedium)}" ),
						_10_Female_FootStepLandHard = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._10_Female_FootStepLandHard)}" ),
						_11_Female_FootStepAttack = LoadAsset<SoundCue>( $"A_Material_Footstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._11_Female_FootStepAttack)}" ),
						_21_Female_HandStepSoft = LoadAsset<SoundCue>( $"A_Material_Handstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._21_Female_HandStepSoft)}" ),
						_22_Female_HandStepMedium = LoadAsset<SoundCue>( $"A_Material_Handstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._22_Female_HandStepMedium)}" ),
						_23_Female_HandStepHard = LoadAsset<SoundCue>( $"A_Material_Handstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._23_Female_HandStepHard)}" ),
						_24_Female_HandStepLongRelease = LoadAsset<SoundCue>( $"A_Material_Handstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._24_Female_HandStepLongRelease)}" ),
						_25_Female_HandStepShortRelease = LoadAsset<SoundCue>( $"A_Material_Handstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._25_Female_HandStepShortRelease)}" ),
						_26_Female_HandStepAttack = LoadAsset<SoundCue>( $"A_Material_Handstep.{matType}.{nameof(TdPhysicalMaterialFootSteps._26_Female_HandStepAttack)}" ),
						
						// Not sure where to find those ...
						_31_Female_BodyAttack = LoadAsset<SoundCue>( $"NO_CLUE_WHERE_THIS_IS.{matType}.{nameof(TdPhysicalMaterialFootSteps._26_Female_HandStepAttack)}" ),
						_32_Female_BodyLandSoft = LoadAsset<SoundCue>( $"NO_CLUE_WHERE_THIS_IS.{matType}.{nameof(TdPhysicalMaterialFootSteps._26_Female_HandStepAttack)}" ),
						_33_Female_BodyLandHard = LoadAsset<SoundCue>( $"NO_CLUE_WHERE_THIS_IS.{matType}.{nameof(TdPhysicalMaterialFootSteps._26_Female_HandStepAttack)}" ),
						_34_Female_BodyLandRoll = LoadAsset<SoundCue>( $"NO_CLUE_WHERE_THIS_IS.{matType}.{nameof(TdPhysicalMaterialFootSteps._26_Female_HandStepAttack)}" ),
						_35_Female_BodyVault = LoadAsset<SoundCue>( $"NO_CLUE_WHERE_THIS_IS.{matType}.{nameof(TdPhysicalMaterialFootSteps._26_Female_HandStepAttack)}" ),
						_36_Female_BodySlide = LoadAsset<SoundCue>( $"NO_CLUE_WHERE_THIS_IS.{matType}.{nameof(TdPhysicalMaterialFootSteps._26_Female_HandStepAttack)}" ),
					}
				}
			};

			_physMat.Add( matType, output );

			return output;
		}
		
		



		public static TClass LoadAsset<TClass>( String assetPath ) where TClass : new()
		{
			switch( assetPath.ToString() )
			{
				case "AS_C1P_Unarmed.AS_C1P_Unarmed":
					return (TClass)(object)Get_AS_C1P_Unarmed();
				case "AS_F3P_Unarmed.AS_F3P_Unarmed":
					return (TClass)(object)Get_AS_F3P_Unarmed();
			}
			
			var splits = assetPath.ToString().Split( '.' );
			string path = assetPath.ToString();
			// Ex: 'AT_C1P.AT_C1P'
			if( splits.Length == 2 && splits[ 0 ] == splits[ 1 ] )
			{
				path = splits[ 0 ];
			}

			if( typeof(TClass) == typeof(SoundNodeWave) && GetClip( assetPath ) != null )
			{
				goto DEFAULT_FALLBACK;
			}

			object resourceAsset;
			try
			{
				resourceAsset = UnityEngine.Resources.Load( path.Replace( '.', '/' ) );
			}
			catch(Exception e)
			{
				LogError( e );
				goto DEFAULT_FALLBACK;
			}

			if( Class.InSpawningDefault == 0 )
			{
				if( resourceAsset is UnityEngine.Object asUnityObj )
					resourceAsset = UnityEngine.Object.Instantiate( asUnityObj );
			}

			if( resourceAsset is IAsset iAsset )
				return (TClass) iAsset.GetRuntimeAsset();
			else if( resourceAsset is TClass == false )
			{
				if( typeof(TClass) == typeof(SkeletalMesh) 
				    && resourceAsset is UnityEngine.GameObject prefabRoot 
				    && prefabRoot.GetComponentInChildren<UnityEngine.SkinnedMeshRenderer>() is UnityEngine.SkinnedMeshRenderer usm )
				{
					var unrealObj = new TClass();
					var sm = unrealObj as SkeletalMesh;
					
					// Default offsets for the character meshes, as seen in ME's editor
					sm.Origin.Y = 94f;
					sm.RotOrigin = new (0, -16384, 16384); // 16384 is 90 degrees

					name[] bones;
					switch( path )
					{
						case "CH_TKY_Crim_Fixer_1P.SK_UpperBody":
						case "CH_TKY_Crim_Fixer_1P.SK_LowerBody":
							bones = TrackBoneNames_1P;
							break;
						case "CH_TKY_Crim_Fixer.SK_TKY_Crim_Fixer":
							bones = TrackBoneNames_3P;
							break;
						default: 
							throw new Exception();
					}
					var nonDicTrs = usm.transform.parent.GetComponentsInChildren<UnityEngine.Transform>();
					var trs = nonDicTrs.Where(t => t != usm.transform && t != usm.transform.parent).ToDictionary( trs => (name)trs.name );
					trs[ "root" ].localRotation = UnityEngine.Quaternion.identity;

					sm.RefSkeleton = new();
					for( int i = 0; i < bones.Length; i++ )
					{
						var bone = trs[bones[i]];

						// var _ref = decFPModelJPos[ i ];
						// Position won't match ref, not sure why I have to transform it so
						
						sm.RefSkeleton[ i ] = new AnimNode.FMeshBone
						{
							Name = bone.name,
							BonePos = new AnimNode.VJointPos
							{
								Orientation = bone.localRotation.ToUnrealAnim(),
								Position = bone.localPosition.ToUnrealAnim(),
							},
							ParentIndex = Array.FindIndex( bones, other => other == bone.parent.name ),
							NumChildren = bone.childCount,
							//Depth = depth,// Inspecting memory showed that this value is always zero
						};
					}

					var link = usm.gameObject.AddComponent<UnrealObjectLink>();
					if(link != null)
						link.Object = (Object) (object) unrealObj;
					lock( UScriptToUnity )
						UScriptToUnity.Add( unrealObj, usm );
					return unrealObj;
				}
			}

			NotImplementedFor.Add( assetPath );
			if(NotImplementedFor.Count == 1)
				LogWarning($"{nameof(LoadAsset)} not implemented yet, requesting '{assetPath}'. Any other unimplemented request will silently fail but will be logged when exiting play mode.");
			
			DEFAULT_FALLBACK:
			var output = new TClass();
			if( output is Object obj )
				obj.Name = path;
			return output;
		}
		
		
						

		static unsafe Object.Quat FromUInt4( uint a, uint b, uint c, uint d )
		{
			Object.Quat q = default;
			((uint*) & q)[0] = a;
			((uint*) & q)[1] = b;
			((uint*) & q)[2] = c;
			((uint*) & q)[3] = d;
			return q;
		}
		static unsafe Object.Vector FromUInt( uint a, uint b, uint c )
		{
			Object.Vector q = default;
			((uint*) & q)[0] = a;
			((uint*) & q)[1] = b;
			((uint*) & q)[2] = c;
			return q;
		}
		static AnimNode.VJointPos[] decFPModelJPos = new AnimNode.VJointPos[]
		{
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 0, 2147483648, 0 )},
			new() {Orientation = FromUInt4( 1024614358, 1024614358, 1060424124, 3207907771 ), Position = FromUInt( 0, 3269031164, 1078773069 )},
			new() {Orientation = FromUInt4( 0, 3174989524, 0, 3212818710 ), Position = FromUInt( 1085004549, 644481477, 2805989376 )},
			new() {Orientation = FromUInt4( 0, 3181468644, 0, 3212784711 ), Position = FromUInt( 1098336570, 657475004, 2815426560 )},
			new() {Orientation = FromUInt4( 1060417209, 1060417210, 3174079038, 3174079038 ), Position = FromUInt( 3236011403, 1092345392, 3222646426 )},
			new() {Orientation = FromUInt4( 1033420854, 2147483648, 0, 3212790135 ), Position = FromUInt( 2841116672, 3258322198, 2863136768 )},
			new() {Orientation = FromUInt4( 3202766933, 841573527, 833268236, 3211043088 ), Position = FromUInt( 679477248, 3258471183, 675282944 )},
			new() {Orientation = FromUInt4( 3200209079, 845225137, 833969817, 3211621601 ), Position = FromUInt( 681574400, 3245868586, 2805989376 )},
			new() {Orientation = FromUInt4( 3203959291, 3204685812, 1057202165, 3203959291 ), Position = FromUInt( 671088640, 2826960896, 677904384 )},
			new() {Orientation = FromUInt4( 3174079038, 3174079038, 3207900858, 3207900857 ), Position = FromUInt( 3236011643, 3239829045, 3222646379 )},
			new() {Orientation = FromUInt4( 1033420854, 2147483648, 0, 3212790135 ), Position = FromUInt( 671088640, 1110838515, 913486817 )},
			new() {Orientation = FromUInt4( 3202766933, 2996525253, 2988213053, 3211043088 ), Position = FromUInt( 677380096, 1110987547, 892274154 )},
			new() {Orientation = FromUInt4( 3200209079, 2147483648, 0, 3211621601 ), Position = FromUInt( 662700032, 1098384920, 935023555 )},
			new() {Orientation = FromUInt4( 658383520, 2815603808, 2840396160, 3212836864 ), Position = FromUInt( 2810183680, 687865856, 2793406464 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 668119059, 3274062260, 1090583925 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 2811128264, 2147483648, 0 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1078632338, 1099401329, 3236051737 )},
			new() {Orientation = FromUInt4( 3162840441, 3172868301, 3200676877, 3211509347 ), Position = FromUInt( 1096003501, 1062522140, 3221915275 )},
			new() {Orientation = FromUInt4( 1021509188, 1053022343, 3158051869, 3211552803 ), Position = FromUInt( 1103402809, 687865856, 889431287 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1104048423, 2998635696, 884844647 )},
			new() {Orientation = FromUInt4( 3168045662, 975998925, 1008341559, 3212830471 ), Position = FromUInt( 2810183680, 2835349504, 698351616 )},
			new() {Orientation = FromUInt4( 1016768486, 1028236624, 1016958176, 3212810420 ), Position = FromUInt( 1061995439, 3189106621, 1042078132 )},
			new() {Orientation = FromUInt4( 3177181218, 3175261684, 3177408612, 3212766843 ), Position = FromUInt( 1090775388, 2826960896, 2826960896 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1082527523, 687865856, 0 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1076325789, 2147483648, 692060160 )},
			new() {Orientation = FromUInt4( 1011211996, 3173758339, 1014119940, 3212819056 ), Position = FromUInt( 1062313251, 3187383946, 3194952608 )},
			new() {Orientation = FromUInt4( 3174809636, 1031975069, 3176907873, 3212760758 ), Position = FromUInt( 1090390068, 2147483648, 2826960896 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1082575091, 2826960896, 2818572288 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1072933554, 687865856, 697303040 )},
			new() {Orientation = FromUInt4( 3148476899, 3186828056, 3153347751, 3212717517 ), Position = FromUInt( 1063021097, 3199023878, 3209326283 )},
			new() {Orientation = FromUInt4( 3167824827, 1041925912, 3171701891, 3212629235 ), Position = FromUInt( 1090248082, 2826960896, 2818572288 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1079404485, 687865856, 0 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1068833929, 700448768, 2826960896 )},
			new() {Orientation = FromUInt4( 1028484985, 1039468971, 1026919064, 3212678449 ), Position = FromUInt( 1062371078, 1026756390, 1060771289 )},
			new() {Orientation = FromUInt4( 3182646516, 3187732174, 3181425450, 3212586031 ), Position = FromUInt( 1090724160, 2835349504, 2826960896 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1082315467, 2826960896, 671088640 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1075262687, 692060160, 2850029568 )},
			new() {Orientation = FromUInt4( 1058313421, 1050538512, 1023583588, 3208692337 ), Position = FromUInt( 1065103324, 1063556589, 1073758981 )},
			new() {Orientation = FromUInt4( 0, 1036482545, 0, 3212757099 ), Position = FromUInt( 1083014763, 698351616, 692060160 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 1023553648, 3212828387 ), Position = FromUInt( 1081901544, 2843738112, 2845835264 )},
			new() {Orientation = FromUInt4( 3159657180, 2147483648, 0, 3212835452 ), Position = FromUInt( 2850029568, 2857369600, 694157312 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 1095659815, 2859466752, 2818572288 )},
			new() {Orientation = FromUInt4( 1036298734, 1036298734, 1060329380, 3207813028 ), Position = FromUInt( 2836970159, 1093367594, 3239464471 )},
			new() {Orientation = FromUInt4( 0, 3183648440, 0, 3212760940 ), Position = FromUInt( 1089360207, 2789868691, 0 )},
			new() {Orientation = FromUInt4( 1065353216, 2147483648, 0, 613232946 ), Position = FromUInt( 663644613, 970131358, 898541409 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 3226115989, 3246884651, 1088568091 )},
			new() {Orientation = FromUInt4( 3162840441, 3172868301, 3200676877, 3211509347 ), Position = FromUInt( 3243487170, 3210001514, 1074431640 )},
			new() {Orientation = FromUInt4( 1021509188, 1053022343, 3158051871, 3211552803 ), Position = FromUInt( 3250886710, 3119612934, 3045865559 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 3251531876, 969850477, 3116087885 )},
			new() {Orientation = FromUInt4( 3168045662, 975998925, 1008341559, 3212830471 ), Position = FromUInt( 671088640, 679477248, 679477248 )},
			new() {Orientation = FromUInt4( 1016768486, 1028236624, 1016958176, 3212810420 ), Position = FromUInt( 3209487276, 1041581675, 3189533515 )},
			new() {Orientation = FromUInt4( 3159618139, 3174626602, 3177929573, 3212790597 ), Position = FromUInt( 3238258622, 974270524, 3114938345 )},
			new() {Orientation = FromUInt4( 845001687, 2147483648, 0, 3212836864 ), Position = FromUInt( 3230011768, 3113137093, 957487834 )},
			new() {Orientation = FromUInt4( 848239549, 2147483648, 0, 3212836864 ), Position = FromUInt( 3223809960, 3102620095, 957319159 )},
			new() {Orientation = FromUInt4( 1029486213, 3173914626, 1012221669, 3212795881 ), Position = FromUInt( 3209799794, 1039885375, 1047481740 )},
			new() {Orientation = FromUInt4( 3174710739, 1032549849, 3175417679, 3212761041 ), Position = FromUInt( 3237874089, 3114355907, 950165786 )},
			new() {Orientation = FromUInt4( 842335475, 2147483648, 0, 3212836864 ), Position = FromUInt( 3230058301, 966348693, 3107911864 )},
			new() {Orientation = FromUInt4( 847249408, 2147483648, 0, 3212836864 ), Position = FromUInt( 3220417813, 3104027411, 937806086 )},
			new() {Orientation = FromUInt4( 1024886733, 3186771585, 3159108605, 3212706329 ), Position = FromUInt( 3210511502, 1051524067, 1061849808 )},
			new() {Orientation = FromUInt4( 3167696104, 1042084161, 3165587336, 3212629337 ), Position = FromUInt( 3237731540, 943075689, 3086915947 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 3226887484, 965479210, 3106047919 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 3216318382, 3105210791, 949332406 )},
			new() {Orientation = FromUInt4( 1035782913, 1039201804, 1028272529, 3212627709 ), Position = FromUInt( 3209858460, 3174302948, 3208251819 )},
			new() {Orientation = FromUInt4( 3182742892, 3186847161, 3182810147, 3212584956 ), Position = FromUInt( 3238207961, 3109791942, 958756128 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 3229799183, 3100384175, 952099378 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 3222745768, 951442382, 3101764003 )},
			new() {Orientation = FromUInt4( 1058313421, 1050538512, 1023583588, 3208692337 ), Position = FromUInt( 3212593099, 3211047542, 3221241184 )},
			new() {Orientation = FromUInt4( 842279073, 1036482545, 814549928, 3212757099 ), Position = FromUInt( 3230497996, 969072306, 955506124 )},
			new() {Orientation = FromUInt4( 845018305, 2950815176, 1023553648, 3212828387 ), Position = FromUInt( 3229385294, 3095666500, 949734247 )},
			new() {Orientation = FromUInt4( 3159657180, 2147483648, 0, 3212835452 ), Position = FromUInt( 687865856, 2147483648, 698351616 )},
			new() {Orientation = FromUInt4( 1057323589, 3208078018, 3203229120, 842182390 ), Position = FromUInt( 1111746840, 3263599912, 3257808904 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 3243143573, 3102935049, 951330858 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 672604262, 3274062260, 1090583925 )},
			new() {Orientation = FromUInt4( 0, 2147483648, 0, 3212836864 ), Position = FromUInt( 311427072, 2147483648, 654311424 )},
		};

		static name[] TrackBoneNames_3P = new name[]
		{
			(name) "root",
			(name) "Hips",
			(name) "Spine",
			(name) "Spine1",
			(name) "Spine2",
			(name) "Neck",
			(name) "Head",
			(name) "LeftShoulder",
			(name) "LeftArm",
			(name) "LeftForeArm",
			(name) "LeftHand",
			(name) "LeftWeapon",
			(name) "LeftHandMiddle0",
			(name) "LeftHandMiddle1",
			(name) "LeftHandMiddle2",
			(name) "LeftHandMiddle3",
			(name) "LeftHandRing0",
			(name) "LeftHandRing1",
			(name) "LeftHandRing2",
			(name) "LeftHandRing3",
			(name) "LeftHandPinky0",
			(name) "LeftHandPinky1",
			(name) "LeftHandPinky2",
			(name) "LeftHandPinky3",
			(name) "LeftHandIndex0",
			(name) "LeftHandIndex1",
			(name) "LeftHandIndex2",
			(name) "LeftHandIndex3",
			(name) "LeftHandThumb1",
			(name) "LeftHandThumb2",
			(name) "LeftHandThumb3",
			(name) "LeftForeArmRoll",
			(name) "LeftArmRoll",
			(name) "RightShoulder",
			(name) "RightArm",
			(name) "RightForeArm",
			(name) "RightHand",
			(name) "RightWeapon",
			(name) "RightHandMiddle0",
			(name) "RightHandMiddle1",
			(name) "RightHandMiddle2",
			(name) "RightHandMiddle3",
			(name) "RightHandRing0",
			(name) "RightHandRing1",
			(name) "RightHandRing2",
			(name) "RightHandRing3",
			(name) "RightHandPinky0",
			(name) "RightHandPinky1",
			(name) "RightHandPinky2",
			(name) "RightHandPinky3",
			(name) "RightHandIndex0",
			(name) "RightHandIndex1",
			(name) "RightHandIndex2",
			(name) "RightHandIndex3",
			(name) "RightHandThumb1",
			(name) "RightHandThumb2",
			(name) "RightHandThumb3",
			(name) "LeftHand_GameIK",
			(name) "RightForeArmRoll",
			(name) "RightArmRoll",
			(name) "LeftUpLeg",
			(name) "LeftLeg",
			(name) "LeftFoot",
			(name) "LeftToeBase",
			(name) "LeftUpLegRoll",
			(name) "RightUpLeg",
			(name) "RightLeg",
			(name) "RightFoot",
			(name) "RightToeBase",
			(name) "RightUpLegRoll",
		};

		static name[] TrackBoneNames_1P = new name[]
		{
			(name) "root",
			(name) "Hips",
			(name) "Spine",
			(name) "Spine1",
			(name) "LeftUpLeg",
			(name) "LeftLeg",
			(name) "LeftFoot",
			(name) "LeftToeBase",
			(name) "LeftUpLegRoll",
			(name) "RightUpLeg",
			(name) "RightLeg",
			(name) "RightFoot",
			(name) "RightToeBase",
			(name) "RightUpLegRoll",
			(name) "SpineX",
			(name) "SpineXLeft",
			(name) "LeftShoulder",
			(name) "LeftArm",
			(name) "LeftForeArm",
			(name) "LeftHand",
			(name) "LeftWeapon",
			(name) "LeftHandMiddle0",
			(name) "LeftHandMiddle1",
			(name) "LeftHandMiddle2",
			(name) "LeftHandMiddle3",
			(name) "LeftHandRing0",
			(name) "LeftHandRing1",
			(name) "LeftHandRing2",
			(name) "LeftHandRing3",
			(name) "LeftHandPinky0",
			(name) "LeftHandPinky1",
			(name) "LeftHandPinky2",
			(name) "LeftHandPinky3",
			(name) "LeftHandIndex0",
			(name) "LeftHandIndex1",
			(name) "LeftHandIndex2",
			(name) "LeftHandIndex3",
			(name) "LeftHandThumb1",
			(name) "LeftHandThumb2",
			(name) "LeftHandThumb3",
			(name) "LeftWristRoll",
			(name) "LeftForeArmRoll",
			(name) "Neck",
			(name) "Head",
			(name) "SpineXRight",
			(name) "RightShoulder",
			(name) "RightArm",
			(name) "RightForeArm",
			(name) "RightHand",
			(name) "RightWeapon",
			(name) "RightHandMiddle0",
			(name) "RightHandMiddle1",
			(name) "RightHandMiddle2",
			(name) "RightHandMiddle3",
			(name) "RightHandRing0",
			(name) "RightHandRing1",
			(name) "RightHandRing2",
			(name) "RightHandRing3",
			(name) "RightHandPinky0",
			(name) "RightHandPinky1",
			(name) "RightHandPinky2",
			(name) "RightHandPinky3",
			(name) "RightHandIndex0",
			(name) "RightHandIndex1",
			(name) "RightHandIndex2",
			(name) "RightHandIndex3",
			(name) "RightHandThumb1",
			(name) "RightHandThumb2",
			(name) "RightHandThumb3",
			(name) "RightWristRoll",
			(name) "LeftHand_GameIK",
			(name) "RightForeArmRoll",
			(name) "EyeJoint",
			(name) "CameraJoint",
		};

	}
}