using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 2f;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}