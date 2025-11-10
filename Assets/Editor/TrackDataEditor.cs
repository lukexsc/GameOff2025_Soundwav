using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TrackData))]
public class TrackDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TrackData track = target as TrackData;

        if (GUILayout.Button("Random ID"))
        {
            track.RandomizeID();
            EditorUtility.SetDirty(this);
        }
    }
}
