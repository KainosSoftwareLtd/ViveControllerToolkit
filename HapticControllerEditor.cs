using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ViveController
{
    [CustomEditor(typeof(HapticController))]
    public class ControllerEditor : ControllerObjectEditor
    {
        public override void OnInspectorGUI()
        {
            HapticController hapticController = (HapticController)target;
            DependencyCheck(hapticController);
        }
    }
}
