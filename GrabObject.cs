using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViveController
{
    public enum Button { Trigger, Grip, Touch, TouchDown, None }
    public enum PickupType { Origin, Natural, OriginLerp, Custom }

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

        private void Start()
        {
            controllerObject = new ControllerObject();
        }

        private void Update()
        {
            if (_duringCollision)
            {
                bool grab = false;
                switch (_button)
                {
                    //TODO check if each button is pressed
                    case Button.Grip:
                        break;
                    case Button.None:
                        grab = true;
                        break;
                    case Button.Touch:
                        break;
                    case Button.TouchDown:
                        break;
                    case Button.Trigger:
                        break;
                }
                if (grab)
                    Grab();
            }
        }

        private void Grab()
        {
            switch (_pickupType)
            {
                //TODO 
                case PickupType.Origin:
                    break;
                case PickupType.OriginLerp:
                    break;
                case PickupType.Natural:
                    break;
                case PickupType.Custom:
                    break;
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

        private bool ControllerCheck()
        {
            //TODO
            return true;
        }

        private void OnCollisionEnter(Collision col)
        {
            if (ControllerCheck())
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
            if (ControllerCheck())
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
            if (ControllerCheck())
            {
                if (_grabEvent != ControllerEvent.Trigger)
                    OnExit();
            }
        }

        private void OnTriggerExit(Collider col)
        {
            if (ControllerCheck())
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
