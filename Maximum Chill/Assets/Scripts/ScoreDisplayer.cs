using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreDisplayer : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
}
