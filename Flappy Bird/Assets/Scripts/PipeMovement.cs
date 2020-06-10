using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = transform.right * -speed;
    }

    private void Update()
    {
        if (transform.position.x < -(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 5))
            Destroy(this.gameObject);
        if (!Player.GetComponent<PlayerMovement>().isAlive)
            rb.velocity = Vector2.zero;
    }
}
