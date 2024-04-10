using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFeedback : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        // Gérer le game over ici
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // Mettre à jour le texte
    }
}
