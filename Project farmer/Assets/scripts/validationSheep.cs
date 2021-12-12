using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class validationSheep : MonoBehaviour
{
    public TextMeshProUGUI scorePlayerText;
    public int score;
    private void Start()
    {
        score = 0;
        UpdateScore(0);
        //scoreText.text = "Score: " + score;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            Destroy(collision.gameObject);
            UpdateScore(5);
        }
    }
    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scorePlayerText.text = "Player: " + score;
    }
}

