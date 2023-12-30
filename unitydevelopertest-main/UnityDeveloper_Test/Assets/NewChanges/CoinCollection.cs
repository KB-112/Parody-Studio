using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour,IGameOver, IGameStart
{
    public int Maxtarget;
    public int Score;
    public TextMeshProUGUI scoretext;

    [Tooltip("Score,Timer,GameoverText,Task Complete Text")]
    public GameObject[] miniGameObj;
  

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Collectible"))
        {
            Debug.Log("Coin collect");
            Destroy(collision.gameObject);
            Score++;
            if(Score == Maxtarget)
            {
               
                StartCoroutine(GameoverElements());
            }
        }
    }

    public void GameOver()
    {
        miniGameObj[0].SetActive(false);
        miniGameObj[1].SetActive(false);
        miniGameObj[2].SetActive(true);
        miniGameObj[4].SetActive(true);

    }

    public void GameStart()
    {
            miniGameObj[0].SetActive(true);
            miniGameObj[1].SetActive(true);
            miniGameObj[2].SetActive(false);
            miniGameObj[3].SetActive(false);
        miniGameObj[4].SetActive(false);

    }

    IEnumerator GameoverElements()
    {
        miniGameObj[0].SetActive(false);
        miniGameObj[1].SetActive(false);
       
        miniGameObj[3].SetActive(true);
        miniGameObj[4].SetActive(true);

        yield return new WaitForSeconds(1);
        miniGameObj[3].SetActive(false);
    }
}
