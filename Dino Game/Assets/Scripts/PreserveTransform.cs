using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveTransform : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("VisualElements").Length > 1)
        {
            Destroy(this.gameObject);
        }
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
