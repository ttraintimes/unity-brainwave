using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutoEscape : MonoBehaviour
{
    public float timeoutDuration = 30f; // Timeout duration in seconds
    private float elapsedTime = 0f;
    private bool playerInputDetected = false;
    public GameObject escMenu;
    public UnityEvent onMenuAppear;
    public UnityEvent onMenuDisppear;

    void Update()
    {
        // Check if any player input is detected
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            playerInputDetected = true;
        }

        // Increment elapsed time if no player input detected
        if (!playerInputDetected)
        {
            elapsedTime += Time.deltaTime;

            // If timeout duration reached, simulate ESC button press
            if (elapsedTime >= timeoutDuration)
            {
                // Call a function to simulate ESC button press
                 escMenu.SetActive(false);
            Time.timeScale = 1;

            onMenuDisppear.Invoke();
            }
             else
        {
            escMenu.SetActive(true);
            Time.timeScale = 0;
            onMenuAppear.Invoke();
        }
        }
    }
    
}
