using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;
    float xMin, xMax, yMin, yMax;
    float stock = 4f;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0f);
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - stock;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + stock;
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - stock;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + stock;
    }

    void Update()
    {
        if(transform.position.x < xMin || transform.position.x > xMax || transform.position.y < yMin || transform.position.y > yMax)
        {
            Destroy(this.gameObject);
        }
    }
}
