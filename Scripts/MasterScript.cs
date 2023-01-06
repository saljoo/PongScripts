using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    static public bool gameEnded;
    private int player1Score;
    private int player2Score;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text winnerText;
    public GameObject winnerPanel;

    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        gameEnded = false;
        winnerPanel.SetActive(false);
    }

    public void AddScore(bool p1)
    {
        if (p1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
        else
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }

        if(player1Score >= Settings.rounds)
        {
            winnerPanel.SetActive(true);
            winnerText.text = "Player 1";
            gameEnded = true;
            Settings.rounds = 10;
            Settings.difficulty = Difficulty.normal;
        }
        else if(player2Score >= Settings.rounds)
        {
            winnerPanel.SetActive(true);
            if (GameObject.Find("Player1").CompareTag("SP"))
                winnerText.text = "Player AI";
            else
                winnerText.text = "Player 2";
            gameEnded = true;
            Settings.rounds = 10;
            Settings.difficulty = Difficulty.normal;
        }
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
