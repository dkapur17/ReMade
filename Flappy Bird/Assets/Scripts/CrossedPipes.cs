using UnityEngine;
using UnityEngine.UI;

public class CrossedPipes : MonoBehaviour
{
    public GameObject Player;
    public Text scoreText;
    public Text gameOverScore;
    private PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = Player.GetComponent<PlayerMovement>();
        scoreText.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gap") && pm.isAlive)
        {
            pm.score++;
            Destroy(other);
        }
        scoreText.text = pm.score.ToString();
        gameOverScore.text = pm.score.ToString();
    }
}
