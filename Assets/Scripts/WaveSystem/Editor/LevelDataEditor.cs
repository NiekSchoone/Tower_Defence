/*using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor{
	private ReorderableList list;

	private void OnEnable(){
		list = new ReorderableList(serializedObject,
				serializedObject.FindProperty("Waves"),
				true, true, true, true);
	}

	public override void OnInspectorGUI(){
		SerializedObject.Update();
		list.DoLayoutList();
		SerializedObject.ApplyModifiedProperties();
	}
}*/