using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HapticObject))]
public class HapticObjectEditor : ControllerObjectEditor {

    public override void OnInspectorGUI()
    {
        HapticObject hapticObject = (HapticObject)target;
        DependencyCheck(hapticObject);
        hapticObject.strength = EditorGUILayout.IntSlider("Strength", hapticObject.strength, 0, 3999);
        if (hapticObject.hapticForm != HapticForm.DuringCollision)
        {
            hapticObject.duration = EditorGUILayout.FloatField("Duration", hapticObject.duration);
            if (hapticObject.duration < 0)
                hapticObject.duration = 0;
            
        }
        hapticObject.hapticForm = (HapticForm)EditorGUILayout.EnumPopup("Haptic Form", hapticObject.hapticForm);
        if (hapticObject.hapticForm != HapticForm.DuringCollision)
        {
            hapticObject.hapticStyle = (HapticStyle)EditorGUILayout.EnumPopup("Haptic Style", hapticObject.hapticStyle);
        }
        hapticObject.hapticEvent = (ControllerEvent)EditorGUILayout.EnumPopup("Haptic Event", hapticObject.hapticEvent);
        hapticObject.overwrite = EditorGUILayout.ToggleLeft("Overwrite ", hapticObject.overwrite); 
    }
}
