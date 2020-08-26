using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = gameSession.GetLevel().ToString();
    }
}
