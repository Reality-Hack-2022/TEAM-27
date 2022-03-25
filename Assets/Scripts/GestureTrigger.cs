using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTrigger : MonoBehaviour
{

    public float triggerSpeed;

    Vector3 previousPosition;
    Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity = (transform.position - previousPosition) * Time.deltaTime;
        previousPosition = transform.position;
        //Debug.Log("Current speed is: " + currentVelocity.magnitude);

        if(currentVelocity.magnitude > triggerSpeed && !CalibrateGesture.Instance.isCalibrating)
        {
            Debug.Log("Trigger threshold surpassed!");
            Team27GestureAudio.Instance.GestureReceived(transform.position, currentVelocity);
        }
    }
}
