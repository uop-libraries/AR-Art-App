using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observation : MonoBehaviour
{
    public List<GameObject> visuals = new List<GameObject>();
    public List<AudioClip> clips = new List<AudioClip>();
    private Text [] observationTextReference;
    //public GameObject panelRectTransform;
    private string classYear;
    private string observationID;
    private string observationText;
    private AudioSource audioSpeaker;

    void Awake()
    {
        audioSpeaker = this.GetComponent<AudioSource>();
        observationTextReference = this.GetComponentsInChildren<Text>(true); //include inactives
    }


    public void setObservationID(string theID)
    {
        observationID = theID;
    }

    public void setObservationYear(string theClassYear)
    {
        classYear = theClassYear;
    }

    public void playObservation()
    {
        //this.setObservationText(observationText);
        this.gameObject.SetActive(true);
        //Debug.Log("observationTextReference = " + observationTextReference.Length);
        observationTextReference[0].transform.parent.gameObject.GetComponent<ScrollText>().resetScrollBarPosition(); //reset the scroll bar
        observationTextReference[0].transform.parent.gameObject.GetComponent<ScrollText>().setIsScrolling(true); //get the parent of text to start auto scroll

    }

    public void pauseObservation()
    {
        this.gameObject.SetActive(false);

    }

    public void setObservationText(string text)
    {
        observationText = text;
        //Debug.Log("observationText " + observationText);
        this.setTextValue();
    }

    private void setTextValue()
    {
        //observationTextReference = this.GetComponentsInChildren<Text>(true); //include inactives
        //Debug.Log("observationTextReference = " + observationTextReference.Length);
        observationTextReference[0].text = observationText;
    }

    public  string printInfo()
    {
        return "observationID: " + observationID + " classYear: " + classYear + "observationText: " + observationText;
    }
}
