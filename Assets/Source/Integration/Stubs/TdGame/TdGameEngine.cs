namespace MEdge.TdGame{
using Core; using Engine; using Editor; using UnrealEd; using Fp; using Tp; using Ts; using IpDrv; using GameFramework; using TdMenuContent; using TdMpContent; using TdSharedContent; using TdSpBossContent; using TdSpContent; using TdTTContent; using TdTuContent; using TdEditor;

public partial class TdGameEngine : GameEngine/*
		transient
		native
		config(Engine)*/{
	[config, transient] public/*private*/ String DefaultLoadSPMapMoviePrefix;
	[config, transient] public/*private*/ int NumberOfSPMovies;
	[config, transient] public/*private*/ String DefaultLoadTTMapMoviePrefix;
	[config, transient] public/*private*/ int NumberOfTTMovies;
	[config, transient] public/*private*/ String DefaultLoadGameMovie;
	[config, transient] public/*private*/ String DefaultCutSceneMoviePrefix;
	[transient] public/*private*/ String LoadMapMovie;
	[transient] public/*private*/ Object.Pointer MovieIni;
	[transient] public/*private*/ bool bShouldWaitForMovieAfterLoad;
	[transient] public/*private*/ bool bShouldContinueLoadingTextures;
	[transient] public/*private*/ bool bEnabledSkipMovie;
	[transient] public/*private*/ bool bHasLoaded;
	[transient] public/*private*/ RequestedTextureResources ActiveRequestedTextureResources;
	public Object.Vector2D LoadingPos;
	public Object.Vector2D HintPos;
	public String CurrentMapName;
	[config] public float LoadMapLoadTime;
	[transient] public/*private*/ int NumStreamingZonesCleared;
	
	// Export UTdGameEngine::execGetLanguage(FFrame&, void* const)
	public /*native final function */static name GetLanguage()
	{
		NativeMarkers.MarkUnimplemented();
		// stub
		return default;
	}
	
	public virtual /*function */String GetHintMessage(bool bIsTTGame)
	{
		// stub
		return default;
	}
	
	public virtual /*event */void OnLoadLevel()
	{
		// stub
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