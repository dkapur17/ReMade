using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator animator;
    public GameObject SceneCanvas;

    private bool PositionReached;

    private void Start()
    {
        PositionReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("PlayerReady", true);
            SceneCanvas.SetActive(false);
        }
        if (transform.position.x == -5f && !PositionReached)
            LoadGameScene();
    }

    void LoadGameScene()
    {
        PositionReached = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
