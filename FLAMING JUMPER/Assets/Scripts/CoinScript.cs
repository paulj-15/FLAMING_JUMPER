using UnityEngine;
using TMPro;



public class CoinScript : MonoBehaviour
{
    public TMP_Text Myscoretext;
    private int Score = 0;


    private void Start()
    {
        //if (GameObject.FindObjectOfType<TMP_Text>())
        //{
        //    Myscoretext = GameObject.FindObjectOfType<TMP_Text>();
        //}
        Score = 0;
        Myscoretext.text = "Score : " + Score;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Debug.Log("Triggered");
            Score++;
            Destroy(other.gameObject);
            Myscoretext.text = "Score : " + Score;
            //highscore = highscore + Score;
            //Score = Score + 10;
            //Debug.Log("Score = " + Score);
            //ScoreManager.instance.ChangeScore(coinValue);
        }


    }
}
