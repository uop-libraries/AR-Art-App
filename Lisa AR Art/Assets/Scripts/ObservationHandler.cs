using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservationHandler : MonoBehaviour
{
    private int currentPlayingObservation;
    private List<GameObject> listOfObservations;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> listOfObservations = new List<GameObject>();
        currentPlayingObservation = 0;
        setUp();
    }

    void setUp()
    {
        foreach (GameObject foundObservation in GameObject.FindGameObjectsWithTag("observation"))
        {

            listOfObservations.Add(foundObservation);
        }
    }

    public void playNextObservation()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
