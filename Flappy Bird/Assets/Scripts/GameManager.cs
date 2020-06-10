using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PipePairPrefab;
    public GameObject Player;
    public float generationDelay;
    public float generationVarience;
    public float initialDelay;
    public float pipeYLoc;
    
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        StartCoroutine(GeneratePipePairs());
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = !Player.GetComponent<PlayerMovement>().isAlive;
    }

    private void SpawnPipePair()
    {
        GameObject newPipePair = Instantiate(PipePairPrefab) as GameObject;
        newPipePair.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 2f, Random.Range(-pipeYLoc - 1, pipeYLoc + 1));
    }

    IEnumerator GeneratePipePairs()
    {
        yield return new WaitForSeconds(initialDelay);
        while(!gameOver)
        {
            SpawnPipePair();
            yield return new WaitForSeconds(Random.Range(generationDelay, generationDelay + generationVarience));
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
