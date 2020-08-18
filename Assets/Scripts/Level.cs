using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int Enemies;
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
        StartCoroutine(WaitAndLoadGameOver());
    }

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over Menu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoadNextLevel()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadTestArea()
    {
        SceneManager.LoadScene("Test Area");
    }

    public void AddEnemies(int numberOfEnemies)
    {
        Enemies += numberOfEnemies;
    }

    public void SubtractEnemy()
    {
        Enemies -= 1;
        if (Enemies <= 0)
        {
            StartCoroutine(WaitAndLoadNextLevel());
        }
    }
}