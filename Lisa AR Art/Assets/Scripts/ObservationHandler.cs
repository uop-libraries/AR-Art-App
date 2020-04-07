using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservationHandler : MonoBehaviour
{
    public AudioClip buttonClick;
    private int currentPlayingObservation;
    private List<GameObject> listOfObservations = new List<GameObject>();
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayingObservation = 0;
        source = GetComponent<AudioSource>();
        setUp();
    }

    public void setUp()
    {
        foreach (GameObject foundObservation in GameObject.FindGameObjectsWithTag("observation"))
        {

            listOfObservations.Add(foundObservation);
        }
        Debug.Log("size of observations list " + listOfObservations.Count);
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
        listOfObservations[currentPlayingObservation].gameObject.SetActive(true);
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
    }
    public void playNextObservation()
    {
        source.PlayOneShot(buttonClick, 1.0f);

        // Debug.Log("playNextObservation " + currentPlayingObservation);
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().pauseObservation(); //pause the current observation
        currentPlayingObservation++;
        //Debug.Log("playNextObservation incremented " + currentPlayingObservation);
        if (!(currentPlayingObservation >= 0 && currentPlayingObservation <= listOfObservations.Count - 1)) //lists in unity start at 0 and count starts with 1 if there is an element
        {
            currentPlayingObservation = 0;
        }
        this.setObservationActiveAndPlay(currentPlayingObservation);
        //Debug.Log("playNextObservation end function " + currentPlayingObservation);
    }

    public void playPrevObservation()
    {
        source.PlayOneShot(buttonClick, 1.0f);

        //Debug.Log("playPrevObservation " + currentPlayingObservation);
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().pauseObservation(); //pause the current observation
        currentPlayingObservation--;
        //Debug.Log("playPrevObservation decrement " + currentPlayingObservation);
        if (!(currentPlayingObservation >= 0 && currentPlayingObservation < listOfObservations.Count-1)) //lists in unity start at 0 and count starts with 1 if there is an element
        {
            currentPlayingObservation = listOfObservations.Count - 1;
        }
        this.setObservationActiveAndPlay(currentPlayingObservation);        
        //Debug.Log("playPrevObservation  end function " + currentPlayingObservation);

    }

    private void setObservationActiveAndPlay(int index)
    {
        listOfObservations[index].gameObject.SetActive(true);
        listOfObservations[index].GetComponent<Observation>().playObservation();
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
