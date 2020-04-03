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
    private List<GameObject> listOfObservations;


    void Awake()
    {
    }
    public void readTextFile(List<GameObject> observations)
    {
        string filePath = "Assets/TextFile/test.txt";
        StreamReader reader = new StreamReader(filePath);
        string text = reader.ReadToEnd();
        reader.Close(); //close the reader
        listOfObservations = observations;
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
        int observationNum = 0; //used to keep track of observation
        int numberOfObservations = listOfObservations.Count;
        int i = 0;
        var lines = text.Split("\n"[0]);
        while(i < lines.Length -1)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) //next observation data
            {
                observationNum++;
            }
            {
                if (observationNum <= numberOfObservations)
                {
                    Debug.Log(lines.Length);
                    Debug.Log("i" + i);
                    listOfObservations[observationNum].GetComponent<Observation>().setObservationID(lines[i]);
                    i++;
                    listOfObservations[observationNum].GetComponent<Observation>().setObservationYear(lines[i]);
                    i++;
                    listOfObservations[observationNum].GetComponent<Observation>().setObservationText(lines[i]);
                }

            }
            i++;
        } //end while

    }


}
