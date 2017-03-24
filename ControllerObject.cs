using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViveController
{
    public class ControllerObject
    {
        private GameObject _controller;
        private HapticController _hapticController;
        public GameObject controller
        {
            get { return _controller; }
            set
            {
                _controller = value;
                _hapticController = _controller.GetComponent<HapticController>();
            }
        }

        public HapticController hapticController
        {
            get { return _hapticController; }
        }
    }
}
