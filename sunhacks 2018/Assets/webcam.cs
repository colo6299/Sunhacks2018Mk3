using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webcam : MonoBehaviour
{

    public int pointer = 0;

    void Start()
    {

        StopStartCam_Clicked();


        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log(devices.Length);
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }


    }

    int currentCamIndex = 0;

    WebCamTexture tex;

    public Renderer display;

    public void SwapCam_Clicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
        }

    }


    public void StopStartCam_Clicked()
    {
        if (tex != null)
        {
            display.material.mainTexture = null;
            tex.Stop();
            tex = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[pointer];
            tex = new WebCamTexture(device.name);
            display.material.mainTexture = tex;
            tex.Play();
        }

    }
}
