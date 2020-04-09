using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observation : MonoBehaviour
{
    public GameObject visuals;
    public bool waitForVoiceToBeDone; //TRUE if you want the visuals to appear AFTER the narrating voice is done
    public List<AudioClip> bgAudioClips = new List<AudioClip>();
    public AudioClip voiceClip; //voice narrating the text
    private Text [] observationTextReference;
    private string classYear;
    private string observationID;
    private string observationText;
    private AudioSource audioSpeakerForBGSounds;
    private AudioSource audioSpeakerForVoice;
    private int bgSongIndex = 0;
    void Awake()
    {
        audioSpeakerForBGSounds = this.GetComponent<AudioSource>();
        audioSpeakerForVoice = this.gameObject.AddComponent<AudioSource>(); //audio source for the voice
        audioSpeakerForVoice.clip = voiceClip;
        observationTextReference = this.GetComponentsInChildren<Text>(true); //include inactives
        visuals.SetActive(false);
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
        if (!waitForVoiceToBeDone)
        {
            bgSongIndex = 0;
            //Debug.Log("set the object active!");
            this.gameObject.SetActive(true);
            visuals.SetActive(true);
            observationTextReference[0].transform.parent.gameObject.GetComponent<ScrollText>().resetScrollBarPosition(); //reset the scroll bar
            observationTextReference[0].transform.parent.gameObject.GetComponent<ScrollText>().setIsScrolling(true); //get the parent of text to start auto scroll
        }
        this.playSounds();

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

    /**playSounds
     * Handles playing of music/sounds
     * if waitForVoiceToBeDone is true, then wait for the voice to be done to start the BG sounds and activates the visuals
     */
    private void playSounds()
    {
        audioSpeakerForVoice.Play();
        if (!(waitForVoiceToBeDone)) //waitForVoiceToBeDone
        {
            visuals.SetActive(true); //activate the visuals
            this.playNextTrack(); //play BG sounds
        }
        else
        {
            waitForVoiceToBeDone = false;
            Invoke("playSounds", audioSpeakerForVoice.clip.length + 0.5f); //call method again when voice is done to start the other BG sounds
        }

    }

    /**playNextTrack
     * plays audio and invokes this method again if there is another audio clip to play
     */
    private void playNextTrack()
    {
        Debug.Log("bgSongIndex = " + bgSongIndex);
        audioSpeakerForBGSounds.clip = bgAudioClips[bgSongIndex];
        audioSpeakerForBGSounds.Stop(); // just in case
        audioSpeakerForBGSounds.Play(); //play the song
        bgSongIndex++;
        if (bgSongIndex < bgAudioClips.Count)
        {
            Invoke("playNextTrack", audioSpeakerForBGSounds.clip.length + 0.5f); //call method again when sound is done
        }
    }

}
