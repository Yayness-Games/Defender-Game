﻿using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int level = 1;


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

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void NextLevel()
    {
        level += 1;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetNextLevel()
    {
        return level + 1;
    }
}
