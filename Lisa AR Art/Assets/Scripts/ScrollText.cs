using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** ScrollText
 * Auto scrolls the gameobject holding the text gameobject. 
 * stops scrolling if the user taps on the text box or scroll bar reached the end
 * resets the scroll bar at the top when the observation is played again
 */
public class ScrollText : MonoBehaviour
{
    public Scrollbar scrollbar;
    private bool isScrolling;
    private float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isScrolling = false;
        scrollSpeed = 0.001f;
        scrollbar.onValueChanged.AddListener(ListenerMethod); //listen for the scroll values changing
    }

    // Update is called once per frame
    void Update()
    {
        if (isScrolling) //auto scroll the text
        {
            float currScrollBarValue = scrollbar.value;
            scrollbar.value = (currScrollBarValue - scrollSpeed); //adjust the scrollbar value to make text scroll

        }
    }

    /** setIsScrolling
     * sets the scroll value
     */
    public void setIsScrolling(bool scrolling)
    {
        isScrolling = scrolling;
    }

    /** ListenerMethod
     * listens to the scroll bar value and stops the auto scrolling when scroll bar reached the end
     */
    public void ListenerMethod(float sliderValue)
    {
        if (sliderValue <= 0.0f)
        {
            isScrolling = false;
        }
    }

    /** textTouchedEventTrigger
     * called by event trigger on object to stop auto scrolling
     */
    public void textTouchedEventTrigger()
    {
        isScrolling = false;
    }

    /** resetScrollBarPosition
     * reset the scroll bar 
     */
    public void resetScrollBarPosition()
    {
        scrollbar.value = 1;
    }
}
