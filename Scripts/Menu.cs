using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Text difficultyText;
    public Text roundsText;
    public GameObject settings;

    public void Awake()
    {
        if (!GameObject.Find("Settings"))
        {
            GameObject newSettings = Instantiate(settings);
            newSettings.name = "Settings";
            DontDestroyOnLoad(newSettings);
        }
    }

    public void ButtonRounds(bool more)
    {
        if (more && Settings.rounds < 20)
            Settings.rounds++;
        else if (!more && Settings.rounds > 3)
            Settings.rounds--;

        roundsText.text = Settings.rounds.ToString();
    }



    public void ButtonAI()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonVS()
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonDifficulty(bool right)
    {
        if (right)
        {
            switch (Settings.difficulty)
            {
                case Difficulty.easy:
                    Settings.difficulty = Difficulty.normal;
                    break;
                case Difficulty.normal:
                    Settings.difficulty = Difficulty.hard;
                    break;
                case Difficulty.hard:
                    Settings.difficulty = Difficulty.easy;
                    break;
            }
        }
        else
        {
            switch (Settings.difficulty)
            {
                case Difficulty.easy:
                    Settings.difficulty = Difficulty.hard;
                    break;
                case Difficulty.normal:
                    Settings.difficulty = Difficulty.easy;
                    break;
                case Difficulty.hard:
                    Settings.difficulty = Difficulty.normal;
                    break;
            }
        }

        if (Settings.difficulty == Difficulty.easy)
            difficultyText.text = "Easy";
        else if (Settings.difficulty == Difficulty.normal)
            difficultyText.text = "Normal";
        else
            difficultyText.text = "Hard";
    }
}
