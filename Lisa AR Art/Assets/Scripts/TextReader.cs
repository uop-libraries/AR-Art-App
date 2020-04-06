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

    /**readTextFile
     * called in GM start
     * receives the list of observations
     * reads in the text file data and converts the data into String format
     * calls function addStringToObservation to store the text data into the appropriate observation
     */
    public void readTextFile(List<GameObject> observations)
    {
        string filePath = "Assets/TextFile/data.txt";
        StreamReader reader = new StreamReader(filePath);
        string text = reader.ReadToEnd();
        reader.Close(); //close the reader
        listOfObservations = observations;
        this.addStringToObservation(text);

    }

    /**addStringToDictionary
     * add the text file data to each observation in the list
     * the text file needs to be in the below format:
     * [ID]
     * [Term year]
     * [Text observation]
     * *whitespace*
     * [ID]
     * [Term year]
     * [Text observation]
     */
    void addStringToObservation(string text)
    {
        int observationNum = 0; //used to keep track of observation
        int numberOfObservations = listOfObservations.Count;
        int lineNum = 0;
        var lines = text.Split("\n"[0]);
        Debug.Log("number of lines in text file " + lines.Length);
        while (lineNum < lines.Length -1)
        {
            if (string.IsNullOrWhiteSpace(lines[lineNum])) //next observation data
            {
                observationNum++;
            }
            else {
                    if (observationNum <= numberOfObservations)
                    {
                        Debug.Log("line number " + lineNum);
                        listOfObservations[observationNum].GetComponent<Observation>().setObservationID(lines[lineNum]);
                        lineNum++;
                        listOfObservations[observationNum].GetComponent<Observation>().setObservationYear(lines[lineNum]);
                        lineNum++;
                        listOfObservations[observationNum].GetComponent<Observation>().setObservationText(lines[lineNum]);
                    }
                }
            lineNum++;
        } //end while

    }


}
