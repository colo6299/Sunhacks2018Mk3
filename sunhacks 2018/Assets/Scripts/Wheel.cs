using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {


    public Transform wheel;
    private float angle;
    private float startAngle;
    private float wheelStart;

    public void WheelBreaker(Vector3 position, bool firstRun)
    {
        if (firstRun) { startAngle = angle; wheelStart = wheel.localEulerAngles.z; }

        Vector3 wheelAngle = wheel.localEulerAngles;

        Vector3 localVec = wheel.InverseTransformPoint(position);
        float localAngle = Mathf.Atan2(localVec.y, localVec.x);

        wheelAngle.z = (angle - startAngle) + wheelStart;
        wheel.localEulerAngles = wheelAngle;

    }







}
