using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TextReader : MonoBehaviour
{
    public void readTextFile()
    {
        string filePath = "Assets/TextFile/test.txt";
        StreamReader reader = new StreamReader(filePath);
        string test = reader.ReadToEnd();
        Debug.Log(test); //print the text out
        reader.Close(); //close the reader

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
