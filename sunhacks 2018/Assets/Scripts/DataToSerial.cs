using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class DataToSerial : MonoBehaviour {

    SerialPort sp;
    public Transform hmd;
    public Transform screen;
    public Transform wheelBox;

    
    string comPort = "COM3";
    float clkTime = 0;

	// Use this for initialization
	void Start () {


        sp = new SerialPort(comPort, 9600);
        sp.ReadTimeout = 50;
        sp.Open();

	}
	
	// Update is called once per frame
	void Update ()
    {

        RotScreen();
        if (Time.time > clkTime)
        {
            SerialWrite(AngleFormat());
            clkTime = Time.time + 0.05f;
            Debug.Log("d");
        }
	}

    public void RotScreen()
    {
        screen.eulerAngles = new Vector3(hmd.rotation.eulerAngles.x, hmd.rotation.eulerAngles.y, 0);
        
        
    } 

    public void SerialWrite(string message)
    {
        sp.WriteLine(message);
        sp.BaseStream.Flush();        
        
        sp.BaseStream.Flush();
    }

    string AngleFormat()
    {
        int azimuth = (int)hmd.rotation.eulerAngles.y;
        azimuth = azimuth % 360;
        int elevation = (int)hmd.rotation.eulerAngles.x + 90;
        elevation = elevation % 360;
        int wheelAngle = (int)wheelBox.rotation.eulerAngles.z;
        

        string msg = "E" + (9000 + azimuth) + (9000 + elevation) + (9000 + wheelAngle) + "F";
        Debug.Log(msg);
        return msg;
    }



   
}
