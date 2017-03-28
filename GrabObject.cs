using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace ViveController
{
    public class GrabObject : MonoBehaviour
    {
        [SerializeField]
        private Button _button = Button.Trigger;
        [SerializeField]
        private PickupType _pickupType = PickupType.OriginLerp;
        [SerializeField]
        private ControllerEvent _grabEvent = ControllerEvent.Both;
        [SerializeField]
        private bool _hideController = true;
        [SerializeField]
        private Vector3 _position;
        [SerializeField]
        private Quaternion _rotation;
        [SerializeField]
        private bool _duringCollision = false;
        private ControllerObject controllerObject;
        public bool dismiss = false;

        private void Start()
        {
            controllerObject = new ControllerObject();
        }

        private void Update()
        {
            if (_duringCollision)
            {
                switch (_button)
                {
                    case Button.None:
                        controllerObject.grabController.Grab(this.gameObject, _pickupType, _hideController);
                        break;
                    case Button.Grip:
                        if(controllerObject.device.GetPressDown(EVRButtonId.k_EButton_Grip))
                            controllerObject.grabController.Grab(this.gameObject, _pickupType, _hideController);
                        else if(controllerObject.device.GetPressUp(EVRButtonId.k_EButton_Grip))
                            controllerObject.grabController.DropObject();
                        break;
                    case Button.Touch:
                        if(controllerObject.device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad))
                            controllerObject.grabController.Grab(this.gameObject, _pickupType, _hideController);
                        else if(controllerObject.device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad))
                            controllerObject.grabController.DropObject();
                        break;
                    case Button.Trigger:
                        if(controllerObject.device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger))
                            controllerObject.grabController.Grab(this.gameObject, _pickupType, _hideController);
                        else if(controllerObject.device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger))
                            controllerObject.grabController.DropObject();
                        break;
                }
            }
        }

        private void OnEnter()
        {
            _duringCollision = true;
        }

        private void OnExit()
        {
            _duringCollision = false;
        }

        private bool ControllerCheck(GameObject go)
        {
            return go.name.Contains("Controller");
        }

        private void OnCollisionEnter(Collision col)
        {
            if (ControllerCheck(col.gameObject))
            {
                if (_grabEvent != ControllerEvent.Trigger)
                {
                    controllerObject.controller = col.gameObject;
                    OnEnter();
                }
            }
        }

        private void OnTriggerEnter(Collider col)
        {
            if (ControllerCheck(col.gameObject))
            {
                if (_grabEvent != ControllerEvent.Collision)
                {
                    controllerObject.controller = col.gameObject;
                    OnEnter();
                }
            }
        }

        private void OnCollisionExit(Collision col)
        {
            if (ControllerCheck(col.gameObject))
            {
                if (_grabEvent != ControllerEvent.Trigger)
                    OnExit();
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (ControllerCheck(col.gameObject))
            {
                if (_grabEvent != ControllerEvent.Collision)
                    OnExit();
            }
        }

        public Button button
        {
            get { return _button; }
            set { _button = value; }
        }

        public PickupType pickupType
        {
            get { return _pickupType; }
            set { _pickupType = value; }
        }

        public ControllerEvent grabEvent
        {
            get { return _grabEvent; }
            set { _grabEvent = value; }
        }

        public bool hideController
        {
            get { return _hideController; }
            set { _hideController = value; }
        }

        public Vector3 position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Quaternion rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
    }
}
