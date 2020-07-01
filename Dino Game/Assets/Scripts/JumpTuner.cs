using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTuner : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float inverseJumpMultiplier = 2f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if(rb.velocity.y > 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (inverseJumpMultiplier - 1) * Time.deltaTime;

    }
}
