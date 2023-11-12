using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] int score = 0;

    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;


    private void Awake()
    {
        SetUpSingleton();

    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }

    }



    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}
