using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGamePlay : MonoBehaviour
{
    public TMP_Text timerText;
    public int maxItems = 5; 
    public float timeLimit = 120.0f; 

    private int collectedItems = 0;
    private float countdownTime;
    private bool timerRunning = false;
    public Button PlayBtn;
    void Start()
    {
        StartRace();
      
    }

    void StartRace()
    {
        PlayBtn.onClick.AddListener(StartRaceIndication);

    }


    public void StartRaceIndication()
    {
        countdownTime = timeLimit;
        timerRunning = true;
       

        StartCoroutine(Countdown());

        Debug.Log("Button clicked");
    }
    IEnumerator Countdown()
    {
        while (timerRunning)
        {
            int minutes = Mathf.FloorToInt(countdownTime / 60F);
            int seconds = Mathf.FloorToInt(countdownTime - minutes * 60);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

            timerText.text = timeString;

            yield return new WaitForSeconds(1f);

            countdownTime -= 1f;

            if (countdownTime <= 0)
            {
                timerRunning = false;
                timerText.text = "00:00";
              
                Debug.Log("Time's up! You did not collect all items in time.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            collectedItems++;
            Destroy(other.gameObject); 

            if (collectedItems >= maxItems)
            {
                timerRunning = false;
                countdownTime = 0;
                timerText.text = "00:00";
              
                Debug.Log("All items collected within the time limit!");
            }
        }
    }
}
