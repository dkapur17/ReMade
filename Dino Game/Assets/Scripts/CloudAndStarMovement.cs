using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAndStarMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public bool item2 = false;
    private GameManager gameManager;

    // Update is called once per frame
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        transform.position = new Vector3(transform.position.x, item2 ? Random.Range(-0.75f, 1f) : Random.Range(1f, 2.75f), transform.position.z) ;
    }
    void Update()
    {
        if(!gameManager)
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (gameManager.playerAlive())
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < -10)
            transform.position = new Vector3(9.5f, Random.Range(-0.75f, 2.75f), transform.position.z);
    }
}
