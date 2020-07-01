using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float accelerationFactor;
    public float initSpeed = 0.5f;
    private float gameSpeed;
    private bool gameOver;
    public float initDelay = 2;
    public float pointsPerSecond;
    public float[] birdSpawnHeights;
    public Transform spawnPoint;
    public Text ScoreText;
    public GameObject GameOverPanel;
    public GameObject[] obstacles;
    public AudioClip scoreBeep;
    public AudioClip GameOverClip;
    public Text ScoreFlasher;
    private float score;
    private GameObject[] birds;
    private AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        gameSpeed = initSpeed;
        gameOver = false;
        score = 0;
        StartCoroutine(GenerateObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed *= accelerationFactor;
        score += pointsPerSecond * gameSpeed * Time.deltaTime;
        ScoreText.text = ((int)score).ToString("D5");
        if(Int32.Parse(ScoreText.text) % 100 == 0 && !audioPlayer.isPlaying && Int32.Parse(ScoreText.text) != 0 && !gameOver)
        {
            int currScore = Int32.Parse(ScoreText.text);
            audioPlayer.clip = scoreBeep;
            audioPlayer.Play();
            StartCoroutine(FlashScore(currScore));
        }
    }

    IEnumerator FlashScore(int currScore)
    {
        ScoreText.enabled = false;
        ScoreFlasher.text = currScore.ToString("D5");
        yield return new WaitForSeconds(2);
        ScoreFlasher.text = "";
        ScoreText.enabled = true;
    }

    public float GetGameSpeed() => gameSpeed;

    IEnumerator GenerateObstacles()
    {
        yield return new WaitForSeconds(initDelay);
        while(!gameOver)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(durationGenerator());
        }
    }

    private void SpawnObstacle()
    {
        int obstacleIndex = UnityEngine.Random.Range(0, score <= 500 ? obstacles.Length - 1 : obstacles.Length + 2);
        if (obstacleIndex >= obstacles.Length)
            obstacleIndex = 6;
        GameObject obstacle = Instantiate(obstacles[obstacleIndex]) as GameObject;
        obstacle.transform.position = spawnPoint.position;
        if(obstacleIndex == 6)
            obstacle.transform.position = new Vector3(obstacle.transform.position.x, birdSpawnHeights[UnityEngine.Random.Range(0, 3)], obstacle.transform.position.z);
    }

    public void setGameOver()
    {
        audioPlayer.Stop();
        audioPlayer.clip = GameOverClip;
        audioPlayer.Play();

        birds = GameObject.FindGameObjectsWithTag("Bird");
        for(int i = 0; i < birds.Length; i++)
            birds[i].GetComponent<Animator>().SetBool("gameOver", true);

        gameSpeed = 0;
        gameOver = true;
        GameOverPanel.SetActive(true);
    }

    public void reloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public bool playerAlive() => !gameOver;

    private float durationGenerator()
    {
        int prob = UnityEngine.Random.Range(0, 101);
        float spawnDelay = 0;
        if(score < 500)
        {
            if (prob < 30)
                spawnDelay = 1;
            else if (prob < 50)
                spawnDelay = 2;
            else if (prob < 70)
                spawnDelay = 3;
            else if (prob < 85)
                spawnDelay = 4;
            else if (prob < 95)
                spawnDelay = 5;
            else if (prob < 99)
                spawnDelay = 6;
            else
                spawnDelay = 7;
        }
        else
        {
            if (prob < 5)
                spawnDelay = 0.25f;
            if (prob < 25)
                spawnDelay = 0.5f;
            else if (prob < 50)
                spawnDelay = 1f;
            else if (prob < 70)
                spawnDelay = 2f;
            else if (prob < 85)
                spawnDelay = 3f;
            else if (prob < 95)
                spawnDelay = 4f;
            else
                spawnDelay = 5f;
        }

        return spawnDelay;
    }
}
