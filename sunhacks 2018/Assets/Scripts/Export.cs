using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Export : MonoBehaviour {

    public TextAsset text;
    public Transform hmd;
    public Transform wheel;

    void Start()
    {
        //var file = File.Open("File_Name", FileMode.Create, FileAccess.ReadWrite);
        File.WriteAllText("C:\\Users\\Wyatt\\Documents\\New folder\\sunhacks 2018\\Assets\\Scripts\\Text.txt", " ");
    }
    void WriteString()
    {
        string path = "Assets/Scripts/Text.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(Time.time + "," + wheel.localEulerAngles.z);
        writer.Close();

        
    }

    void FixedUpdate()
    {
        WriteString();
    }
}
