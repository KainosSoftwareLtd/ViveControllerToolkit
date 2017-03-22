using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GrabObject))]
public class GrabObjectEditor : ControllerObjectEditor
{
    public override void OnInspectorGUI()
    {
        GrabObject grabObject = (GrabObject)target;
        DependencyCheck(grabObject);
        grabObject.button = (Button)EditorGUILayout.EnumPopup("Button", grabObject.button);
        grabObject.pickupType = (PickupType)EditorGUILayout.EnumPopup("Pickup Type", grabObject.pickupType);
        if (grabObject.pickupType == PickupType.Custom)
        {
            grabObject.position = EditorGUILayout.Vector3Field("Custom Position", grabObject.position);
            grabObject.rotation = EditorGUILayout.Vector3Field("Custom Rotation", grabObject.rotation);
        }
        grabObject.grabEvent = (ControllerEvent)EditorGUILayout.EnumPopup("Grab Event", grabObject.grabEvent);
        grabObject.hideController = EditorGUILayout.ToggleLeft("Hide Controller", grabObject.hideController);
    }
}
