using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject detectedImage;
    public GameObject arrows;
    public GameObject lostDetectionWindow;
    float tempCountDownValue;
    public AudioClip detectedSound;
    private AudioSource source;
     

    // Start is called before the first frame update
    void Start()
    {
        lostDetectionWindow.SetActive(false);
        detectedImage.SetActive(false);
        arrows.SetActive(false);
        source = GetComponent<AudioSource>();
        this.GetComponent<ObservationHandler>().setUp();
        this.GetComponent<ObservationHandler>().activate(false); //hide the observations until detection
        this.GetComponent<TextReader>().readTextFile(this.GetComponent<ObservationHandler>().returnListOfObservations()); 
        //this.GetComponent<ObservationHandler>().printAllObservations();
        //this.GetComponent<ObservationHandler>().activate(false);

    }

    /** endTutorial
     * called when the image/painting is detected. only called once upon first detection
     */
    public void endTutorial()
    {
        //lostDetectionWindow.SetActive(false);
        if (tutorial.activeSelf) {
            detectedImage.SetActive(true);
            Debug.Log("inside end tutorial if statement");
            tutorial.SetActive(false);
            source.PlayOneShot(detectedSound, 1.0f);
            StartCoroutine(StartCountdown(2));
        }

    }

    /** StartCountdown
     * timer for detection screen to go away.
     * paramter float represents the seconds
     */
    private IEnumerator StartCountdown(float countdownValue)
    {
        tempCountDownValue = countdownValue;
        while (tempCountDownValue > 0)
        {
            Debug.Log("Countdown: " + tempCountDownValue);
            yield return new WaitForSeconds(1.0f);
            tempCountDownValue--;
        }
        detectedImage.SetActive(false);
        arrows.SetActive(true);
        this.GetComponent<ObservationHandler>().startObservations();
    }

    /**exitApplication
     * quit the application
     */
    public void exitApplication()
    {
        Application.Quit();
    }

    /**onLost
     * if painting detection is lost, call this function
     */
    public void onLost()
    {
        lostDetectionWindow.SetActive(true);
    }


}
