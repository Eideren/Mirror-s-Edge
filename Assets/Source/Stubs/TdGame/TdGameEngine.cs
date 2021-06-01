namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameEngine : GameEngine/*
		transient
		native
		config(Engine)*/{
	public /*private config transient */String DefaultLoadSPMapMoviePrefix;
	public /*private config transient */int NumberOfSPMovies;
	public /*private config transient */String DefaultLoadTTMapMoviePrefix;
	public /*private config transient */int NumberOfTTMovies;
	public /*private config transient */String DefaultLoadGameMovie;
	public /*private config transient */String DefaultCutSceneMoviePrefix;
	public /*private transient */String LoadMapMovie;
	public /*private transient */Object.Pointer MovieIni;
	public /*private transient */bool bShouldWaitForMovieAfterLoad;
	public /*private transient */bool bShouldContinueLoadingTextures;
	public /*private transient */bool bEnabledSkipMovie;
	public /*private transient */bool bHasLoaded;
	public /*private transient */RequestedTextureResources ActiveRequestedTextureResources;
	public Object.Vector2D LoadingPos;
	public Object.Vector2D HintPos;
	public String CurrentMapName;
	public /*config */float LoadMapLoadTime;
	public /*private transient */int NumStreamingZonesCleared;
	
	// Export UTdGameEngine::execGetLanguage(FFrame&, void* const)
	public /*native final function */static name GetLanguage()
	{
		#warning NATIVE FUNCTION !
		return default;
	}
	
	public virtual /*function */String GetHintMessage(bool bIsTTGame)
	{
	
		return default;
	}
	
	public virtual /*event */void OnLoadLevel()
	{
	
	}
	
	public TdGameEngine()
	{
		// Object Offset:0x00546B7E
		DefaultLoadSPMapMoviePrefix = "LoadingFaith";
		NumberOfSPMovies = 3;
		DefaultLoadTTMapMoviePrefix = "LoadingFaith";
		NumberOfTTMovies = 3;
		DefaultLoadGameMovie = "LoadingSimple";
		DefaultCutSceneMoviePrefix = "scene_";
		LoadingPos = new Vector2D
		{
			X=0.130f,
			Y=0.880f
		};
		HintPos = new Vector2D
		{
			X=0.350f,
			Y=0.870f
		};
		LoadMapLoadTime = 29.0f;
		NumStreamingZonesCleared = -1;
	}
}
}