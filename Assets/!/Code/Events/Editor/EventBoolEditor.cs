using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.UI;
using NUnit.Framework.Internal;

[CustomEditor(typeof(GameEventBool), editorForChildClasses: true)]
public class EventBoolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        GameEventBool e = target as GameEventBool;
        if (GUILayout.Button("Raise True"))
            e.Raise(true);

        if (GUILayout.Button("Raise False"))
            e.Raise(false);
    }
}
