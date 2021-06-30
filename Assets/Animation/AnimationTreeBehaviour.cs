namespace MEdge
{
	using Engine;
	using Source;
	using T3D;
	using UnityEngine;



	public class AnimationTreeBehaviour : MonoBehaviour
	{
		public T3DFile File;
		public AnimationClip[] Clips;
		AnimationPlayer _player;
		Actor _actor;
		AnimNodeEditor.AnimNodeEditorWindow _window;
		AnimSet _animSet;
		


		void Start()
		{
			_actor = new Actor();
			_window = AnimNodeEditor.AnimNodeEditorWindow.CreateInstance<AnimNodeEditor.AnimNodeEditorWindow>();
			_player = new AnimationPlayer( Clips, Asset.Get_AS_C1P_Unarmed,  (AnimNode) _window.LoadFile( File ), this.gameObject, _actor );
			_window.Show();
		}



		void OnDestroy()
		{
			_window.Close();
		}



		void Update()
		{
			_player.Sample( Time.deltaTime );
		}
	}
}