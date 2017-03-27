using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViveController
{
	public class GrabController : MonoBehaviour 
	{
		private GameObject _grabbedObject;
		private PickupType _pickupType;
		private bool _hideController;
		private Vector3 _position;
		private Quaternion _rotation;
		private float _duration = 0.1f;
		private bool isGrabbing = false;
		private GameObject oldParent;
		public bool dismiss = false;

		//TODO Think about things with gravity? Param to auto turn on isKinematic?
		//TODO Think about re-parenting? Param?

		public void Grab(GameObject grabbedObject, PickupType pickupType = PickupType.OriginLerp, bool hideController = true)
		{
			grab(grabbedObject, pickupType, hideController);
		}

		public void Grab(GameObject grabbedObject, Vector3 position, Quaternion rotation, bool hideController = true)
		{
			grab(grabbedObject, PickupType.Custom, hideController);
			_position = position;
			_rotation = rotation;
		}

		public GameObject getGrabbedObject()
		{
			return _grabbedObject;
		}

		public void dropObject()
		{
			isGrabbing = false;
			//_grabbedObject.transform.parent = oldParent.transform;
			transform.Find("Model").gameObject.SetActive(true);
		}

		private void grab(GameObject grabbedObject, PickupType pickupType, bool hideController)
		{
			_grabbedObject = grabbedObject;
			_pickupType = pickupType;
			_hideController = hideController;
			isGrabbing = true;
			oldParent = _grabbedObject.transform.parent.gameObject;
			_grabbedObject.transform.parent = this.gameObject.transform;
		}

		private void Update()
		{
			if (isGrabbing)
			{
				switch (_pickupType)
				{
					case PickupType.Origin:
						_grabbedObject.transform.localPosition = Vector3.zero;
						_grabbedObject.transform.localRotation = Quaternion.identity;
						break;
					case PickupType.Natural:
						break;
					case PickupType.OriginLerp:
						_grabbedObject.transform.localPosition = Vector3.Lerp(_grabbedObject.transform.localPosition, Vector3.zero, _duration);
						_grabbedObject.transform.localRotation = Quaternion.Lerp(_grabbedObject.transform.localRotation, Quaternion.identity, _duration);
						break;
					case PickupType.Custom:
						_grabbedObject.transform.localPosition = Vector3.Lerp(_grabbedObject.transform.localPosition, _position, _duration);
						_grabbedObject.transform.localRotation = Quaternion.Lerp(_grabbedObject.transform.localRotation, _rotation, _duration);
						break;
				}
				if (_hideController)
				{
					transform.Find("Model").gameObject.SetActive(false);
				}
			}
		}
	}
}
