using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private GameManager gameManager;
    public float speedVariation = 0f;

    private float speedOffset;
    // Start is called before the first frame update
    void Start()
    {
        if (speedVariation != 0)
            speedOffset = Random.Range(-speedVariation, speedVariation);
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.playerAlive())
            transform.Translate(Vector2.left * (gameManager.GetGameSpeed() + speedOffset) *Time.deltaTime);
        if (transform.position.x < -15)
            Destroy(this.gameObject);
    }

}
