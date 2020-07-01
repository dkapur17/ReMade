using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoonMovement : MonoBehaviour
{
    public float speed = 0.5f;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager)
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (gameManager.playerAlive())
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x < -10f)
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
    }
}
