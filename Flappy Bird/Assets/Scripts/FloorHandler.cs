using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHandler : MonoBehaviour
{
    public bool isFloor;
    private BoxCollider2D bound;
    // Start is called before the first frame update
    void Start()
    {
        bound = GetComponent<BoxCollider2D>();
        bound.size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x * 2f, 1f);
        bound.offset = isFloor ? new Vector2(0f, -Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y -0.5f)
            : new Vector2(0f, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + 0.5f);
    }
}
