namespace MEdge
{
	using System.Collections.Generic;
	using Engine;



	public class ChainOfEvents
	{
		public void Do()
		{
			LevelStartup();
			PlayerLogIn();
		}
		
		void LevelStartup()
		{
			// https://wiki.beyondunreal.com/Legacy:Chain_Of_Events_At_Level_Startup
			
			#error fill-in
			GameInfo gi = default;
			gi.InitGame();

			#error fill-in
			List<Actor> actors = new List<Actor>();
			foreach( var actor in actors )
				actor.PreBeginPlay();
			foreach( var actor in actors )
				actor.BeginPlay();
			// actor zones
			// actor volumes
			foreach( var actor in actors )
				actor.PhysicsVolume.
			foreach( var actor in actors )
				actor.PhysicsVolumeChange(  );
			foreach( var actor in actors )
				actor.PostBeginPlay();
			foreach( var actor in actors )
				actor.PostNetBeginPlay();
			foreach( var actor in actors )
				actor.SetInitialState();
			
			#warning Implement AttachTag with Actor Bases once I have a repro (actor.Tag? maybe)
		}



		void PlayerLogIn()
		{
			// https://wiki.beyondunreal.com/Legacy:Chain_Of_Events_When_A_Player_Logs_In
			GameInfo gi = default;
			gi.PreLogin();
			// Mutator.OverrideDownload()
			gi.Login();
		}


	}
}