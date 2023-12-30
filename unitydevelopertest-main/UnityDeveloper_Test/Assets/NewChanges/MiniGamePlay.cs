using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGamePlay : MonoBehaviour
{
    [SerializeField] private float initialCountdownTime = 120.0f; // 2 minutes in seconds
    private float countdownTime;
    private bool timerRunning = false;
    public Button PlayBtn;
    public TMP_Text timerText;
    public GameObject[] Coin;

    IGameOver gameOver;
    IGameStart gameStart;

    void Start()
    {
        gameOver = GetComponent<IGameOver>();
        gameStart = GetComponent<IGameStart>();
      
        countdownTime = initialCountdownTime;
        StartRace();
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
                gameOver.GameOver();
                timerRunning = false;
                timerText.text = "00:00";
                Coin[0].SetActive(false);
                ResetTimer();
            }
        }
    }

    void StartRace()
    {
        PlayBtn.onClick.AddListener(StartRaceIndication);
    }

    public void StartRaceIndication()
    {
        timerRunning = true;
        Coin[0].SetActive(true);
        gameStart.GameStart();
        StartCoroutine(Countdown());
    }

    
    void ResetTimer()
    {
        countdownTime = initialCountdownTime;
    }
}
