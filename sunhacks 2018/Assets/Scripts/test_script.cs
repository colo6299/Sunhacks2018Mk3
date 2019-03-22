using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_script : MonoBehaviour {

    //for grabbing
    //public bool isGrabbing = false;
    //public Transform v1;
    //public Transform v2;
    //public Transform v3;
    //public Transform v4;
    //public float average = 0;
    //public float threshold = 0.1f;
    public float dist = 0;

    //for wheel touch detection
    public Transform palm;
    public Transform wheel;

    // for movement
    public float angle;
    public float prevAngle = 0;
    public bool hasStarted = false;
    public float startAngle;
    private float wheelStart;
    private float taxicab = 0.1f;
    public float momentum = 0.0f;
    public float eta = 0.01f;
    
    private void OnTriggerStay(Collider other) //if the hand is touching the collider of the wheel 
    { //updates while the hand is touching the wheel
        SteamVR_TrackedController ctrlr = GetComponent<SteamVR_TrackedController>();
        if (ctrlr.triggerPressed) //if isgrabbing is true 
        {
            dist = Vector3.Distance(palm.position, wheel.position); //calculate distance from the palm to the wheel's center
            //if (dist <= taxicab) //makes it so that you can only grab the outside of the wheel
            //{
            //    return; //no grabbing
            //}


            if (hasStarted) //if we touching
            {
                WheelBreaker(palm.position, false); //calculates the wheel position 
            }
            else //if we not touching 
            {
                WheelBreaker(palm.position, true); //takes position of palm, 
                hasStarted = true; //touched
            }
        }else { hasStarted = false; }
    }

    public void WheelBreaker(Vector3 position, bool firstRun) //takes argument position of the palm, and sets the angle of the wheel accordingly
    {
        Vector3 localVec = wheel.InverseTransformPoint(position).normalized;
        angle = Mathf.Atan2(localVec.y, localVec.x) * 180 / Mathf.PI;// + Mathf.Sign(momentum) * eta;
        Debug.Log(Mathf.Sign(momentum));
        momentum += (angle - prevAngle);

        if (firstRun)
        {
            startAngle = angle;
            wheelStart = wheel.localEulerAngles.z;
            firstRun = false;
            momentum = 0.0f;
        }

        Vector3 wheelAngle = wheel.localEulerAngles;

        wheelAngle.z = (angle - startAngle) + wheelStart;
        wheel.localEulerAngles = wheelAngle;
        prevAngle = angle;
    }


    // Update is called once per frame

    // for grabbing the thingy
    /*void Update () {
        float a = 0;
        a += Vector3.Distance(v1.position, palm.position);
        a += Vector3.Distance(v2.position, palm.position);
        a += Vector3.Distance(v3.position, palm.position);
        a += Vector3.Distance(v4.position, palm.position); //average distance and shit
        average = a / 4;
        if (average <= threshold) //if the average distance of the fingertips is lower than a preset value
        {
            isGrabbing = true; 
            Debug.Log("grabbing!!!!"); //lmk
        }
        else //if youre not grabbing, isgrabbing false and hasnt started
        {
            isGrabbing = false; 
            hasStarted = false; 
        }*/

    //}
}
