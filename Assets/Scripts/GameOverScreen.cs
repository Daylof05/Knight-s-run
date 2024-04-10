using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    //public Text bestScoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("PlayerScore", 0); // Récupère le score actuel
        //int bestScore = PlayerPrefs.GetInt("BestScore", 0); // Récupère le meilleur score

        scoreText.text = "Votre Score est : " + score.ToString();
        //bestScoreText.text = "Meilleur Score : " + bestScore.ToString();
    }
}
