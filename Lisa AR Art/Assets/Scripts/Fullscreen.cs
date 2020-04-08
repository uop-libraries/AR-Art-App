using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** Fullscreen
 * attach this script to the fullscreen button
 */
public class Fullscreen : MonoBehaviour
{
    public Sprite expand;
    public Sprite shrink;
    public GameObject[] objectsToHide; //hide the objects in full screen
    private bool isFullscreen;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().sprite = expand;
        isFullscreen = false;
    }

    public void onButtonClick()
    {
        isFullscreen = !isFullscreen;
        if (isFullscreen)
        {

            this.GetComponent<Image>().sprite = shrink; //change icon
        }
        else
        {
            this.GetComponent<Image>().sprite = expand;
        }
        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(!isFullscreen);
        }
    }
}
