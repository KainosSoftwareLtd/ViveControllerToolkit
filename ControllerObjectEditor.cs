using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace ViveController
{
    public class ControllerObjectEditor : Editor
    {
        public bool DependencyCheck(MonoBehaviour tar)
        {
            Collider col = tar.GetComponent<Collider>();
            Rigidbody rb = tar.GetComponent<Rigidbody>();
            if (col == null || rb == null)
            {
                EditorGUILayout.HelpBox(
                    (col == null ? "Requires a Collider.\n" : "") +
                    (rb == null ? "May require a Rigidbody.\n" : ""),
                    MessageType.Warning);
                if (col == null && GUILayout.Button("Add Collider"))
                    tar.gameObject.AddComponent<BoxCollider>();
                if (rb == null && GUILayout.Button("Add Rigidbody"))
                    tar.gameObject.AddComponent<Rigidbody>();
                return true;
            }
            return false;
        }
    }
}
