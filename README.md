# Vive Controller #

Implement grab mechanics and haptics without writing any code. 

Improved API for both haptics and grabbing. B

Built to work with SteamVR.

## Grab Controller ##

To be placed on both controllers in the SteamVR CameraRig.
Requires SteamVRTrackedObject, a Collider, may require a Rigidbody.

### Public Methods ###

**Grab** - Grabs object passed in.

* grabbedObject [GameObject]
* pickupType [PickupType]
* hidecontroller [Bool]

**Grab** - Grabs object passed in. Position and rotation used for custom pickupType.

* grabbedObject [GameObject]
* position [Vector3]
* rotation [Quaternion]
* hidecontroller [Bool]

**GetGrabbedObject** - Returns current held object. Returns null if not holding.

* Returns grabbedObject [GameObject]

**DropObject** - Releases current held object.

### Public Properties ###

grabbedObject [GameObject]

* Gameobject being held.

pickupType [PickupType]

* Default: OriginLerp.
* Enum for different types of pickup:
* Origin – grabbedObject origined on the controller.
* Natrual – maintain relative distance to controller from pickup.
* OriginLerp – start in natural position, lerp over duration to origin.
* Custom – start in natural position, lerp over duration to position and rotation.

hideController [bool]

* Default: true
* Hide controller on pickup or not.

position [Vector3]

* For custom pickup. Vector relative to controller.

rotation [Quaternion]

* For custom pickup. Quaternion relative to controller.

duration [float]

* Default: 0.1s
* For custom / originLerp pickup. Duration of lerp in seconds.

stopGravity [bool]

* Default: true.
* Set rigidbody to isKinematic on pickup.

## Grab Object ##

Can be placed on any object and configured to grab on some form of contact.
Requires a Collider and may require a Rigidbody.
Works in conjunction with GrabController. This script is to be used to provide grab functionality that can be configured in the inspector without writing code. It is optional and you my write your own code using the GrabController exposed methods.

### Public Properties ###

button [Button]

* Default: Trigger
* Enum for which button is used for pickup:
* Trigger.
* Grip.
* Touch – Touchpad.
* None – Not possible to release something picked up using this option.

pickupType [PickupType]

* Default: OriginLerp.
* Enum for different types of pickup:
* Origin – grabbedObject origined on the controller.
* Natrual – maintain relative distance to controller from pickup.
* OriginLerp – start in natural position, lerp over duration to origin.
* Custom – start in natural position, lerp over duration to position and rotation.

grabEvent [ControllerEvent]

* Default: Both
* Enum for type of collision event:
* Both
* Collision
* Trigger

hidecontroller [bool]

* Default: true
* Hide controller on pickup or not.

position [Vector3]
* For custom pickup. Vector relative to controller.

rotation [Quaternion]

* For custom pickup. Quaternion relative to controller.

## Haptics Controller ##

To be placed on both controllers in the SteamVR CameraRig.
Requires SteamVRTrackedObject, a Collider, may require a Rigidbody.

### Public Methods ###

**Haptic** - Haptic Feedback.

* duration [float]
* strength [int]
* haptic Style [HapticStyle]
* overwrite [bool]

** Haptic ** - Haptic Feedback. Custom hapticStyle using strengths array spread evenly over duration.

* duration [float]
* strengths [int[]]
* overwrite [bool]

** Haptic ** - One frame of haptic feedback.
* strength [int] 
* overwrite [bool]

### Public Properties ###

duration [float]

* Length of feedback, in seconds
* strength [int]
* Default: 3999

Strength of feedback. From 0 – 3999 (min - max)

* strengths [int[]]
* Custom array of strengths

hapticStyle [HapticStyle]

* Default: Default
* Enum for style of haptics:
* Default - Feedback for x duration at y strength.
* Crescendo - Feedback for x duration, changing linearly from 0 to y strength.
* Diminuendo - Feedback for x duration, changing linearly from y to 0 strength. 

## Haptic Object ##

Can be placed on any object and configured to give haptics on some form of contact.
Requires a Collider may require a Rigidbody.
Works in conjunction with HapticController. This script is to be used to provide haptic functionality that can be configured in the inspector without writing code. It is optional and you my write your own code using the HapticController exposed methods.

### Public Properties ###

duration [float]

* Length of feedback, in seconds

strength [int]

* Default: 3999
* Strength of feedback. From 0 – 3999 (min - max)

hapticForm [HapticForm]

* Default: OnEnter
* Enum for the form of the haptics:
* OnEnter - Starts on Collision/Trigger enter
* OnExit – Starts on Collision/Trigger exit
* DuringCollision – disregards duration and hapticStyle, plays haptic feedback for duration of the collison. 

hapticStyle [HapticStyle]

* Default: Default
* Enum for style of haptics:
* Default - Feedback for x duration at y strength.
* Crescendo - Feedback for x duration, changing linearly from 0 to y strength.
* Diminuendo - Feedback for x duration, changing linearly from y to 0 strength. 

hapticEvent [ControllerEvent]

* Default: Both
* Enum for type of collision event:
* Both
* Collision
* Trigger

overwrite [bool]

* Default: true
* Should object overwrite current haptics.

## Collision Check ##

Can be used to verify is two objects will collide and what methods will be triggered. Verifies collision of object it is placed on and object passed in in the inspector.