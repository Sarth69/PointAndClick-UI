using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetsList;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;

    public bool isGameActive;

    private int score;

    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
        titleScreen.gameObject.SetActive(false);
        spawnRate = 1.0f / difficulty;
        score = 0;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetsList.Count);
            Instantiate(targetsList[index]);
        }
    }
}
