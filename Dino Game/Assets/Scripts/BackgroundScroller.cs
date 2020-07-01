using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 initPosition;
    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.playerAlive())
            transform.Translate(Vector2.left * gameManager.GetGameSpeed() * Time.deltaTime);
        if (transform.position.x < -18)
            transform.position = initPosition;
    }
}
