using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observation : MonoBehaviour
{
    public List<GameObject> visuals = new List<GameObject>();
    public List<AudioClip> clips = new List<AudioClip>();
    private string classYear;
    private string observationID;
    private string observationText;
    private AudioSource audioSpeaker;

    // Start is called before the first frame update
    void Awake()
    {
        audioSpeaker = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public  string printInfo()
    {
        return "observationID: " + observationID + " classYear: " + classYear + "observationText: " + observationText;
    }
}
