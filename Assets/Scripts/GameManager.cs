using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval;
    public Vector2 obstacleOffsetY;
    [HideInInspector] public int score;
    private bool isGameOver;

    public float obstacleSpeed;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
            Instance = this;
    }

    public void UpdateScore()
    {
        if (score != 0 && score % 5 == 0)
        {
            obstacleSpeed += 0.5f;
            obstacleInterval -= .1f;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameActive()
    {
        return !isGameOver;
    }
   
    public void EndGame()
    {
        isGameOver = true;

        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {

        yield return new WaitForSeconds(delay);
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

}
