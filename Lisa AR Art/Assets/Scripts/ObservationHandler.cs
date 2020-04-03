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

    public void playNextObservation()
    {
        Debug.Log("playNextObservation");
        if (currentPlayingObservation < listOfObservations.Count)
        {
            listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
        }
        else
        {
            currentPlayingObservation = 0;
            playNextObservation(); //start from the top
        }
    }

    public void playPrevObservation()
    {
        Debug.Log("playPrevObservation");
        if (currentPlayingObservation-1 > 0 && currentPlayingObservation < listOfObservations.Count)
        {
            listOfObservations[currentPlayingObservation-1].GetComponent<Observation>().playObservation();
        }
        else
        {
            currentPlayingObservation = listOfObservations.Count - 1;
            playPrevObservation(); //start from end
        }
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
