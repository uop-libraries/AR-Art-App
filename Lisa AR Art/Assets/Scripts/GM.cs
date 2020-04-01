using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject detectedImage;
    float tempCountDownValue;
    public AudioClip detectedSound;
    private AudioSource source;

    // Start is called before the first frame update
    private void Awake()
    {
        detectedImage.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        //ARImages.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * called when the image/painting is detected. only called once upon first detection
     */
    public void endTutorial()
    {
        if (tutorial.activeSelf) {
            tutorial.SetActive(false);
            detectedImage.SetActive(true);
            source.PlayOneShot(detectedSound, 1.0f);
            StartCoroutine(StartCountdown(3));
        }
    }

    /**
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
    }
}
