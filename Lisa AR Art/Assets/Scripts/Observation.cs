using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observation : MonoBehaviour
{
    public GameObject visuals;
    public List<AudioClip> clips = new List<AudioClip>();
    private Text [] observationTextReference;
    private string classYear;
    private string observationID;
    private string observationText;
    private AudioSource audioSpeaker;

    void Awake()
    {
        audioSpeaker = this.GetComponent<AudioSource>();
        observationTextReference = this.GetComponentsInChildren<Text>(true); //include inactives
    }

    /** setObservationID
     * sets the observation id from the text file
     */
    public void setObservationID(string theID)
    {
        observationID = theID;
    }

    /** setObservationYear
     * sets the class term and year (ex. spring 2020)
     */
    public void setObservationYear(string theClassYear)
    {
        classYear = theClassYear;
    }

    /** playObservation
     * play/resets the observation, called when the observation is selected
     * sets the object active, resets the scrollbar, and start auto scroll
     */
    public void playObservation()
    {
        //this.setObservationText(observationText);
        this.gameObject.SetActive(true);
        visuals.SetActive(true);
        observationTextReference[0].transform.parent.gameObject.GetComponent<ScrollText>().resetScrollBarPosition(); //reset the scroll bar
        observationTextReference[0].transform.parent.gameObject.GetComponent<ScrollText>().setIsScrolling(true); //get the parent of text to start auto scroll

    }

    /**pauseObservation
     * hide the observation
     */
    public void pauseObservation()
    {
        this.gameObject.SetActive(false);
        visuals.SetActive(false);
    }

    /**setObservationText
     * sets the string value of the observation
     */
    public void setObservationText(string text)
    {
        observationText = text;
        //Debug.Log("observationText " + observationText);
        observationTextReference[0].text = observationText;
    }

    /**printInfo
     * used to debug the observation
     */
    public string printInfo()
    {
        return "observationID: " + observationID + " classYear: " + classYear + "observationText: " + observationText;
    }

 
}
