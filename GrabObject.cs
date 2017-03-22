using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Button { Trigger, Grip, Touch, TouchDown, None }
public enum PickupType { Origin, Natural, OriginLerp, Custom }

public class GrabObject : MonoBehaviour
{
    public Button button = Button.Trigger;
    public PickupType pickupType = PickupType.Origin;
    public bool hideController = true;
    public Vector3 position;
    public Vector3 rotation;

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}
}
