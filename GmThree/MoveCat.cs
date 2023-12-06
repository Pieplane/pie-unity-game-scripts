using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCat : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed = 0f;
    public float timeSpeed;

    public void Start()
    {
        //timeSpeed = 4f;
        if (Buy.choiceBanan)
        {
            speed = 1550f;
            Debug.Log($"Скорость мобов: {speed}");
            StartCoroutine(UppSpeed());
        }
        else if (Buy.skate)
        {
            speed = 1900f;
            Debug.Log($"Скорость мобов: {speed}");
            StartCoroutine(UppSpeed());
        }
        else if (Buy.samokat)
        {
            speed = 2500f;
            Debug.Log($"Скорость мобов: {speed}");
            StartCoroutine(UppSpeed());
        }
        else if (Buy.skuter)
        {
            speed = 3000f;
            Debug.Log($"Скорость мобов: {speed}");
            StartCoroutine(UppSpeed());
        }
        else
        {
            speed = 1550f;
            Debug.Log($"Скорость мобов: {speed}");
            StartCoroutine(UppSpeed());
        }

    }
    private void Update()
    {
        if(Buy.choiceBanan)
        {
            if(speed > 2900f)
            {
                speed = 2980f;
                Debug.Log($"Скоровть мобов: {speed}");
            }
        }
        else if (Buy.skate)
        {
            if (speed > 3200f)
            {
                speed = 3200f;
                Debug.Log($"Скоровть мобов: {speed}");
            }
        }
        else if (Buy.samokat)
        {
            if (speed > 3500f)
            {
                speed = 3500f;
                Debug.Log($"Скоровть мобов: {speed}");
            }
        }
        else if (Buy.skuter)
        {
            if (speed > 3600f)
            {
                speed = 3600f;
                Debug.Log($"Скоровть мобов: {speed}");
            }
        }
        else
        {
            if (speed > 2900f)
            {
                speed = 2980f;
                Debug.Log($"Скоровть мобов: {speed}");
            }
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    IEnumerator UppSpeed()
    {
        if (speed < 3600f)
        {
            yield return new WaitForSeconds(timeSpeed);
            speed += 350f;
            Debug.Log($"Скоровть мобов: {speed}");
            Debug.Log($"Повышай скорость, скорость мобов: {speed}");
            StartCoroutine(UppSpeedTwo());
        }
    }
    IEnumerator UppSpeedTwo()
    {
        if (speed < 3600f)
        {
            yield return new WaitForSeconds(3f);
            speed += 420f;
            Debug.Log($"Скоровть мобов: {speed}");
            Debug.Log($"Повышай скорость, скорость мобов: {speed}");
            StartCoroutine(UppSpeedThree());
        }
    }
    IEnumerator UppSpeedThree()
    {
        if (speed < 3600f)
        {
            yield return new WaitForSeconds(4f);
            speed += 100f;
            Debug.Log($"Скоровть мобов: {speed}");
            Debug.Log($"Повышай скорость, скорость мобов: {speed}");
            StartCoroutine(UppSpeed());
        }
    }
    //public void Haha()
    //{
    //    while (speed < 2900f)
    //    {
    //        speed += 350f;
    //        Debug.Log($"Повышай скорость, скорость мобов: {speed}");
    //    }
    //}
}
