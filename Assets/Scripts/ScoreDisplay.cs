using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

	[SerializeField] Text scoreText;
	[SerializeField] GameSession gameSession;

    // Use this for initialization
    void Start()
	{
		scoreText = GetComponent<Text>();
		gameSession = FindObjectOfType<GameSession>();
	}

	// Update is called once per frame
	void Update()
	{
		scoreText.text = FindObjectOfType<GameSession>().GetScore().ToString();
	}
}