using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBlack : MonoBehaviour
{
    [SerializeField] private GameObject blackCat;
    float xMin, xMax, yMin, yMax;
    public float speed = 0f;
    private void Start()
    {
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            Debug.Log("Скоро врежишься");
            Vector3 temp = blackCat.transform.position;
            temp.y += CheckPosition();
            blackCat.transform.position = temp;
        }
    }
    public void GetAround()
    {
            Debug.Log("Обойди игрока");
            Vector3 temp = blackCat.transform.position;
            temp.y += CheckPosition();
            blackCat.transform.position = temp;
    }
    float CheckPosition()
    {
        if(transform.position.y > yMin && transform.position.y < yMax - 6)
        {
            float offset = 4;
            return offset;
        }
        else if (transform.position.y > yMin + 6 && transform.position.y < yMax)
        {
            float offset = -4;
            return offset;
        }
        else
        {
            float offset = -4;
            return offset;
        }
    }
}
