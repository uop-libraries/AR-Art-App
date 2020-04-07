using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservationHandler : MonoBehaviour
{
    public AudioClip buttonClick;
    private int currentPlayingObservation; //used to keep track of current playing observation index
    private List<GameObject> listOfObservations = new List<GameObject>();
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayingObservation = 0;
        source = GetComponent<AudioSource>();
        setUp();
    }

    /**setUp
     *  finds all observations in the unity scene
     */
    public void setUp()
    {
        foreach (GameObject foundObservation in GameObject.FindGameObjectsWithTag("observation"))
        {
            listOfObservations.Add(foundObservation);
        }
        Debug.Log("size of observations list " + listOfObservations.Count);
    }

    /**returnListOfObservations
     *  returns the list of found observations 
     */
    public List<GameObject> returnListOfObservations()
    {
        return listOfObservations;
    }

    /**
     * called once in the startup of observations when the painting is detected (called from GM)
     */
    public void startObservations()
    {
        listOfObservations[currentPlayingObservation].gameObject.SetActive(true);
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().playObservation();
    }
    /**playNextObservation
     * called by button event
     * pauses the current playing observation and plays the next observation
     */
    public void playNextObservation()
    {
        source.PlayOneShot(buttonClick, 1.0f);
        listOfObservations[currentPlayingObservation].GetComponent<Observation>().pauseObservation(); //pause the current observation
        currentPlayingObservation++;
        if (!(currentPlayingObservation >= 0 && currentPlayingObservation <= listOfObservations.Count - 1)) //lists in unity start at 0 and count starts with 1 if there is an element
        {
            currentPlayingObservation = 0; //cycle back to the start of the list
        }
        this.setObservationActiveAndPlay(currentPlayingObservation);
    }

    /**playPrevObservation
     * called by button event
     * pauses the current playing observation and plays the previous observation
     */
    public void playPrevObservation()
    {
        source.PlayOneShot(buttonClick, 1.0f);

        listOfObservations[currentPlayingObservation].GetComponent<Observation>().pauseObservation(); //pause the current observation
        currentPlayingObservation--;
        if (!(currentPlayingObservation >= 0 && currentPlayingObservation < listOfObservations.Count-1)) //lists in unity start at 0 and count starts with 1 if there is an element
        {
            currentPlayingObservation = listOfObservations.Count - 1; //cycle to the end 
        }
        this.setObservationActiveAndPlay(currentPlayingObservation);        
    }

    /**setObservationActiveAndPlay
     * set the observation active and play observation
     */
    private void setObservationActiveAndPlay(int index)
    {
        listOfObservations[index].gameObject.SetActive(true);
        listOfObservations[index].GetComponent<Observation>().playObservation();
    }

    /**printAllObservations
     * used for debug purposes
     */
    public void printAllObservations()
    {
        for (int i =0; i < listOfObservations.Count; i++)
        {
            Debug.Log(listOfObservations[i].GetComponent<Observation>().printInfo());
        }
    }


    /**activate
     * activates or deativates all of the observations
     */
    public void activate(bool isActive)
    {
        for (int i = 0; i < listOfObservations.Count; i++)
        {
            listOfObservations[i].SetActive(isActive);
        }
    }
}
