using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public void SetRadius(float radius)
    {
        GetComponent<CircleCollider2D>().radius = radius;
    }

    public void Explode()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }
}
