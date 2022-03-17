namespace MEdge.Source.Editor
{
	using Editor = UnityEditor.Editor;
	using UnityEditor;
	
	
	[CustomEditor(typeof(UnityTdLadderVolume))]
	public class HandlesForTd : Editor
	{
		public void OnSceneGUI()
		{
			var tdLadder = (UnityTdLadderVolume)target;
			for( int i = 0; i < tdLadder.SplineControls.Count; i++ )
			{
				var sPoint = tdLadder.SplineControls[ i ];
				sPoint = tdLadder.TransformNoScale( sPoint );
				EditorGUI.BeginChangeCheck();
				var nPoint = Handles.PositionHandle( sPoint, tdLadder.transform.rotation );
				if (EditorGUI.EndChangeCheck() && sPoint != nPoint )
				{
					Undo.RecordObject (tdLadder, $"Moved spline point on {tdLadder.gameObject.name}");
					tdLadder.SplineControls[ i ] = tdLadder.InverseTransformNoScale( nPoint );
				}
			}
		}
	}
}