using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observation : MonoBehaviour
{
    public List<GameObject> visuals = new List<GameObject>();
    public List<AudioClip> clips = new List<AudioClip>();
    public int classYear;
    private int observationID;
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

    public void setObservationID(int theID)
    {
        observationID = theID;
    }

    public void playObservation()
    {

    }

    public void pauseObservation()
    {

    }

    public void setObservation()
    {

    }
}
