using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCat : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    public float speed = 0f;
    private void FixedUpdate()
    {
        if(LinesDrawer.alreadyDraw)
        AddMove();
    }
    private void AddMove()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
