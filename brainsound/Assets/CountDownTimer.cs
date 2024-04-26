using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float totalTime = 15f; // Total time for countdown in seconds
    private float timeRemaining;
    public Text countdownText;
    public GameObject newUIInterface; // Reference to the new UI interface GameObject
    public AudioSource audioSource;
    public AudioClip countdownFinishedClip;

    void Start()
    {
        timeRemaining = totalTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            // Play audio clip
            if (audioSource != null && countdownFinishedClip != null)
            {
                audioSource.PlayOneShot(countdownFinishedClip);
            }
            // Activate new UI interface
            if (newUIInterface != null)
            {
                newUIInterface.SetActive(true);
            }
            // You can add code here for what happens when the countdown reaches zero
        }
    }

    void UpdateTimerDisplay()
    {
        // Update the text to display the time remaining
        countdownText.text = Mathf.RoundToInt(timeRemaining).ToString();
    }
}
