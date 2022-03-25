using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalibrateGesture : MonoBehaviour
{
    public static CalibrateGesture Instance;

    public GameObject countdownPanel;
    public TextMeshProUGUI countdownText;
    public Transform leftHandTransform, rightHandTransform;
    public GestureTrigger leftHandTrigger, rightHandTrigger;
    Vector3 rightHandPrevPos, leftHandPrevPos;
    public bool isCalibrating;
    public float maxCalibratedVelocity;
    public float percentOfMaxTrigger = .9f;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        countdownPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCalibrating)
        {
            float rightSpeed = rightHandTrigger.currentVelocity.magnitude;
            float leftSpeed = leftHandTrigger.currentVelocity.magnitude;

            //Debug.Log("right speed is: " + rightSpeed);

            if(rightSpeed > leftSpeed)
            {
                maxCalibratedVelocity = Mathf.Max(rightSpeed, maxCalibratedVelocity);
            }
            else
            {
                maxCalibratedVelocity = Mathf.Max(leftSpeed, maxCalibratedVelocity);
            }

            rightHandPrevPos = rightHandTransform.position;
            leftHandPrevPos = leftHandTransform.position;
        }
    }

    public void BeginCalibration()
    {
        isCalibrating = true;
        maxCalibratedVelocity = 0f;
        leftHandPrevPos = leftHandTransform.position;
        rightHandPrevPos = rightHandTransform.position;
        StartCoroutine(CountdownTheText());
    }

    IEnumerator CountdownTheText()
    {
        countdownPanel?.SetActive(true);
        for(int i = 5; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        countdownPanel?.SetActive(false);
        isCalibrating = false;

        rightHandTrigger.triggerSpeed = maxCalibratedVelocity * percentOfMaxTrigger;
        leftHandTrigger.triggerSpeed = maxCalibratedVelocity * percentOfMaxTrigger;
    }
}
