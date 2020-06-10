using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Public Variables
    public float speed;
    public KeyCode space;
    public float downTurnThreshold;
    public BoxCollider2D ceiling;
    public BoxCollider2D floor;
    public Text scoreText;
    public GameObject GameOverPanel;
    [HideInInspector]public bool isAlive;
    [HideInInspector]public int score;
    // Private Variables
    private Rigidbody2D rb;
    private Animator animator;
    private bool upthrust;
    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        // Get the animator component
        animator = GetComponent<Animator>();
        // Initially there is no upthrust
        upthrust = false;
        // And we are alive
        isAlive = true;
        rb.freezeRotation = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player hits space, set upthrust to true
        if (Input.GetKeyDown(space))
            upthrust = true;
        // If the player is touching the floor, he's dead
        if (rb.IsTouching(floor))
        {
            isAlive = false;
            if (rb.rotation < -90)
                rb.rotation = -90;
            rb.freezeRotation = true;
        }
        // Rotating the player on thrust up
        else if (rb.velocity.y > 0)
            rb.rotation = 45;
        // Rotating the player on falling down
        else if (rb.velocity.y < downTurnThreshold)
            rb.MoveRotation(Mathf.Max(-90f, -90*(rb.velocity.y / (3*downTurnThreshold))));
        // If the player is somewhere in the middle of the screen and hasn't been rotated in this frame, rotate to 0 
        else if(!(rb.IsTouching(floor) || rb.IsTouching(ceiling)))
            rb.rotation = 0;
        // If player is dead, stop animation
        if (!isAlive && animator.enabled)
        {
            animator.enabled = false;
            scoreText.enabled = false;
            GameOverPanel.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        // If the player hit space and is alive, make it move upwards
        if(upthrust && isAlive)
        {
            rb.velocity = new Vector2(0, speed);
            // And set upthrust back to false
            upthrust = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            isAlive = false;
        }
    }
}
