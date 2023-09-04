using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    
    public static bool simulateMouseWithTouches = true;
    void Update()
    {
        Input.simulateMouseWithTouches = true;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Update the Text on the screen depending on current position of the touch each frame
            Debug.Log("Touch Position : " + touch.position);
        }
        else
        {
            Debug.Log("no");
        }
    }
}
