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

    // Start is called before the first frame update
    void Awake()
    {
        audioSpeaker = this.GetComponent<AudioSource>();

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
        this.gameObject.SetActive(true);
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
        observationTextReference = this.GetComponentsInChildren<Text>(true); //include inactives
        //Debug.Log("observationTextReference = " + observationTextReference.Length);
        observationTextReference[0].text = observationText;
        //observationTextReference[0].GetComponent<RectTransform>().pivot = new Vector2(.5f, .5f);
        //panelRectTransform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
        //panelRectTransform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
    }

    public  string printInfo()
    {
        return "observationID: " + observationID + " classYear: " + classYear + "observationText: " + observationText;
    }
}
