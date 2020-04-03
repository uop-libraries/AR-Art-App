using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

/**
 * reads in text file and splits text by newline into array lists
 * each string is added to a dictionary to store the text observations
 */
public class TextReader : MonoBehaviour
{
    private IDictionary<int, string> dict;

    void Awake()
    {
        dict = new Dictionary<int, string>();
    }
    public void readTextFile()
    {
        string filePath = "Assets/TextFile/test.txt";
        StreamReader reader = new StreamReader(filePath);
        string text = reader.ReadToEnd();
        reader.Close(); //close the reader
        this.addStringToDictionary(text);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**addStringToDictionary
     * add each line to a dictionary and remove extra white spaces
     */
    void addStringToDictionary(string text)
    {
        var lines = text.Split("\n"[0]);
        for(int i = 0; i < lines.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                Debug.Log(lines[i]);
                dict.Add(i, lines[i]);
            }
        }
        
    }

    public IDictionary<int, string> getDict()
    {
        return dict;
    }
}
