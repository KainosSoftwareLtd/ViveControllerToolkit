using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace ViveController
{
    public class GrabObject : MonoBehaviour
    {
        private Button _button = Button.Trigger;
        private PickupType _pickupType = PickupType.Origin;
        private ControllerEvent _grabEvent = ControllerEvent.Both;
        private bool _hideController = true;
        private Vector3 _position;
        private Vector3 _rotation;
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
                    //TODO check if each button is pressed
                    case Button.Grip:
                        break;
                    case Button.None:
                        controllerObject.grabController.Grab(this.gameObject, _pickupType, _hideController);
                        break;
                    case Button.Touch:
                        break;
                    case Button.TouchDown:
                        break;
                    case Button.Trigger:
                        if(controllerObject.device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger))
                            controllerObject.grabController.Grab(this.gameObject, _pickupType, _hideController);
                        if(controllerObject.device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger))
                            controllerObject.grabController.dropObject();
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

        public Vector3 rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
    }
}
