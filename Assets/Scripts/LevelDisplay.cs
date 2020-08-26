using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{

	[SerializeField] Text LevelText;
	[SerializeField] GameSession gameSession;

	// Use this for initialization
	void Start()
	{
		LevelText = GetComponent<Text>();
		gameSession = FindObjectOfType<GameSession>();
	}

	// Update is called once per frame
	void Update()
	{
		LevelText.text = FindObjectOfType<GameSession>().GetLevel().ToString();
	}
}