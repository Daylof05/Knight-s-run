using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Coin"))
            {
                other.GetComponent<PlayerFeedback>().AddScore(1);
                Destroy(gameObject); // D�truit la pi�ce
            }
            else if (gameObject.CompareTag("Obstacle"))
            {
                other.GetComponent<Animator>().SetBool("IsDead", true);
                
                int currentScore = other.GetComponent<PlayerFeedback>().score;
                PlayerPrefs.SetInt("PlayerScore", currentScore);
                PlayerPrefs.Save();

                SceneManager.LoadScene("EndMenu"); // Remplacez "GameOverSceneName" par le nom de votre sc�ne de game over
            }
        }
    }
}
