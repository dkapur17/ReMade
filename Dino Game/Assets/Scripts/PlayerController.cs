using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private GameManager gameManager;
    private AudioSource jumpAudioPlayer;

    public float jumpVelocity;
    public float acceleratedFall;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpAudioPlayer = GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        // Handling Animation based on Action
        if (isGrounded())
        {
            animator.SetBool("isGrounded", true);
            if (Input.GetKey(KeyCode.DownArrow))
                animator.SetBool("isDucking", true);
            else
                animator.SetBool("isDucking", false);
        }
        else
        // Making the player fall faster if the down arrow is pressed
        {
            animator.SetBool("isGrounded", false);
            if (Input.GetKey(KeyCode.DownArrow))
                rb.velocity = Vector2.down * acceleratedFall;
        }


        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && isGrounded() && !Input.GetKey(KeyCode.DownArrow) && gameManager.playerAlive())
        {
            animator.SetBool("isDucking", false);
            rb.velocity = Vector2.up * jumpVelocity;
            if(!jumpAudioPlayer.isPlaying)
                jumpAudioPlayer.Play();
        }
    }

    bool isGrounded()
    {
        return rb.IsTouchingLayers(groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Bird"))
        {
            if (animator.GetBool("isDucking"))
                transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            gameManager.setGameOver();
            animator.SetBool("isAlive", false);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
