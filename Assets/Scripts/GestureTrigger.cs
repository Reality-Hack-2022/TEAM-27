using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;

public class GestureTrigger : MonoBehaviour
{
    MixedRealityToolkit mrtk;
    public IMixedRealityHand mrtkHand;
    public Handedness whichHand;

    public Transform handColliderTransform;

    private IMixedRealityHandJointService handJointService;

    public float triggerSpeed;

    Vector3 previousPosition;
    public Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();
        previousPosition = handJointService.RequestJointTransform(TrackedHandJoint.Palm, whichHand).position;
        //previousPosition = mrtkHand.;
        //previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 handPosition = handJointService.RequestJointTransform(TrackedHandJoint.Palm, whichHand).position;
        Quaternion handRotation = handJointService.RequestJointTransform(TrackedHandJoint.Palm, whichHand).rotation;

        currentVelocity = (handPosition - previousPosition) * Time.deltaTime;
        previousPosition = handPosition;
        //Debug.Log("Current speed is: " + currentVelocity.magnitude);

        //teleport collider and model to hand position
        handColliderTransform.position = handPosition;
        handColliderTransform.rotation = handRotation;

        if(currentVelocity.magnitude > triggerSpeed && !CalibrateGesture.Instance.isCalibrating)
        {
            Debug.Log("Trigger threshold surpassed!");
            Team27GestureAudio.Instance.GestureReceived(transform.position, currentVelocity);
        }
    }
}
