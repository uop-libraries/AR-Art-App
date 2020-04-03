using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservationHandler : MonoBehaviour
{
    private int currentPlayingObservation;
    private List<GameObject> listOfObservations = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        currentPlayingObservation = 0;
        setUp();
    }

    public void setUp()
    {
        foreach (GameObject foundObservation in GameObject.FindGameObjectsWithTag("observation"))
        {

            listOfObservations.Add(foundObservation);
        }
    }
    public List<GameObject> returnListOfObservations()
    {
        return listOfObservations;
    }

    /**
     * called once in the startup of observations
     */
    public void startObservations()
    {
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
    }
    public void playNextObservation()
    {
        Debug.Log("playNextObservation");
        Debug.Log("currentPlayingObservation " + currentPlayingObservation);
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().pauseObservation();
        currentPlayingObservation++;
        if (currentPlayingObservation < listOfObservations.Count && currentPlayingObservation >= 0)
        {
            listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
        }
        else if(currentPlayingObservation >= 0)
        {
            currentPlayingObservation = 0;
            listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
        }
    }

    public void playPrevObservation()
    {
        Debug.Log("playPrevObservation");
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().pauseObservation();
        currentPlayingObservation--;
        Debug.Log("currentPlayingObservation " + currentPlayingObservation);
        if (currentPlayingObservation >= 0 && currentPlayingObservation < listOfObservations.Count)
        {
            listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
        }
        else 
        {
            currentPlayingObservation = listOfObservations.Count - 1;
            listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
        }
        Debug.Log("currentPlayingObservation after" + currentPlayingObservation);

    }

    public void printAllObservations()
    {
        for (int i =0; i < listOfObservations.Count; i++)
        {
            Debug.Log(listOfObservations[i].GetComponent<Observation>().printInfo());
        }
    }

    public void activate(bool isActive)
    {
        for (int i = 0; i < listOfObservations.Count; i++)
        {
            listOfObservations[i].SetActive(isActive);
        }
    }
}
