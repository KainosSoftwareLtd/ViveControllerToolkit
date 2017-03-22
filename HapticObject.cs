using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticObject : MonoBehaviour
{
    private int _strength = 3999;
    private float _duration = 0.1f;
    private HapticForm _hapticForm = HapticForm.OnEnter;
    private HapticStyle _hapticStyle = HapticStyle.Default;
    private HapticEvent _hapticEvent = HapticEvent.Both;
    private bool _overwrite = true;
    private bool duringCollision = false;
    private ControllerObject controllerObject;

    private void Start()
    {
        controllerObject = new ControllerObject();
    }
	
	private void Update ()
    {
        if (duringCollision)
        {
            controllerObject.hapticController.Haptic(_strength, _overwrite);
        }
    }

    private void OnEnter ()
    {
        switch (_hapticForm)
        {
            case HapticForm.OnEnter:
                controllerObject.hapticController.Haptic(_duration, _strength, _hapticStyle, _overwrite);
                break;
            case HapticForm.DuringCollision:
                duringCollision = true;
                break;
        }
    }

    private void OnExit()
    {
        switch (_hapticForm)
        {
            case HapticForm.OnExit:
                controllerObject.hapticController.Haptic(_duration, _strength, _hapticStyle, _overwrite);
                break;
            case HapticForm.DuringCollision:
                duringCollision = false;
                break;
        }
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
            if (_hapticEvent != HapticEvent.Trigger)
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
            if (_hapticEvent != HapticEvent.Collision)
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
            if (_hapticEvent != HapticEvent.Trigger)
                OnExit();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (ControllerCheck())
        {
            if (_hapticEvent != HapticEvent.Collision)
                OnExit();
        }
    }

    public int strength
    {
        get { return _strength; }
        set { _strength = value; }
    }

    public float duration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    public HapticForm hapticForm
    {
        get { return _hapticForm; }
        set { _hapticForm = value; }
    }

    public HapticStyle hapticStyle
    {
        get { return _hapticStyle; }
        set { _hapticStyle = value; }
    }

    public HapticEvent hapticEvent
    {
        get { return _hapticEvent; }
        set { _hapticEvent = value; }
    }

    public bool overwrite
    {
        get { return _overwrite; }
        set { _overwrite = value; }
    }
}