using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float timeSpeed = 30f;
    public Vector2 movement;
    //Vector3 prevPos;
    public float rocketSpeed = 1f;
    bool rock = false;
    public TrailRenderer trail;
    public float timeRocket = 5f;
    //float timeRelax;
    bool endRocket;
    public Button rocketBut;
    public Slider slider;
    bool canRock = true;
    bool firstStart = false;

    //public GameObject[] transport;
    //public Animator animator;

    private void Start()
    {
        if (Buy.choiceBanan)
        {
            //animator.SetTrigger("ChoiceBanana");
            //StartCoroutine(UppSpeed());
            moveSpeed = 5f;
            //Debug.Log("Корутина банана");
        }
        else if (Buy.skate)
        {
            //transport[0].SetActive(true);
            //StartCoroutine(UppSpeedSkate());
            moveSpeed = 6f;
            //Debug.Log("Корутина скейт");
        }
        else if (Buy.samokat)
        {
            //transport[1].SetActive(true);
            //StartCoroutine(UppSpeedSamokat());
            moveSpeed = 8f;
            //Debug.Log("Корутина самокат");
        }
        else if (Buy.skuter)
        {
            //transport[2].SetActive(true);
            //StartCoroutine(UppSpeedSkuter());
            moveSpeed = 10f;
            //Debug.Log("Корутина скутер");
        }
        else
        {
            //animator.SetTrigger("ChoiceBanana");
            //StartCoroutine(UppSpeed());
            moveSpeed = 5f;
            //Debug.Log("Корутина банана");
        }

        firstStart = true;
        slider.maxValue = timeRocket;
        slider.value = slider.minValue;
        rocketBut.interactable = false;
        //UppSpeed();
    }

    void Update()
    {
        if (firstStart)
        {
            slider.value += Time.deltaTime * 0.1f;
            if (slider.value >= slider.maxValue)
            {
                slider.value = slider.maxValue;
                rocketBut.interactable = true;
                firstStart = false;
            }
        }


        if (rock && canRock)
        {
            timeRocket -= Time.deltaTime;
            slider.value = timeRocket;
            trail.enabled = true;
            rocketSpeed = 2f;
            if (timeRocket < 0)
            {
                canRock = false;
                timeRocket = slider.minValue;
                slider.value = slider.minValue;
                //timeRocket = 0f;
                rocketSpeed = 1f;
                trail.enabled = false;
                rocketBut.interactable = false;
            }
        }

        else
        {
            if (endRocket && !canRock)
            {
                timeRocket += Time.deltaTime * 0.1f;
                slider.value = timeRocket;
                if (timeRocket > slider.maxValue)
                {
                    timeRocket = slider.maxValue;
                    slider.value = slider.maxValue;
                    rocketBut.interactable = true;
                    canRock = true;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Нажата клавиша F");
            Rocket();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("Нажата клавиша F");
            StopRocket();
        }

        //var moving = prevPos != transform.position;

        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        //if (moving)
        //{
        //StartCoroutine(UppSpeed());
        // Debug.Log("Движемся");
        //}
        //else
        //{
        //Debug.Log("Стоим на месте");
        //}
        //prevPos = transform.position;
        //rb.MovePosition(rb.position + movement * moveSpeed * rocketSpeed * Time.fixedDeltaTime);

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * rocketSpeed * Time.deltaTime);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
        if(joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            if (Buy.choiceBanan)
            {
                if(moveSpeed < 10f)
                {
                    moveSpeed += .005f;
                    //Debug.Log($"Повышай скорость, скорость банана: {moveSpeed}");
                }
            }
            else if (Buy.skate)
            {
                if(moveSpeed < 11f)
                {
                    moveSpeed += .005f;
                }   
            }
            else if (Buy.samokat)
            {
                if(moveSpeed < 12f)
                {
                    moveSpeed += .005f;
                }
            }
            else if (Buy.skuter)
            {
                if(moveSpeed < 15f)
                {
                    moveSpeed += .005f;
                }
            }
            else
            {
                if (moveSpeed < 10f)
                {
                    moveSpeed += .005f;
                    //Debug.Log($"Повышай скорость, скорость банана: {moveSpeed}");
                }
            }
        }
        else
        {
            if (Buy.choiceBanan)
            {
                moveSpeed = 5f;
            }
            else if (Buy.skate)
            {
                moveSpeed = 6f;
            }
            else if (Buy.samokat)
            {
                moveSpeed = 8f;
            }
            else if (Buy.skuter)
            {
                moveSpeed = 10f;
            }
            else
            {
                moveSpeed = 5f;
            }
        }
    }
    //IEnumerator UppSpeed()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(timeSpeed);
    //        if(movement.x == 0)
    //        {
    //            moveSpeed = 5f;
    //        }
    //        else
    //        {
    //            if(moveSpeed < 10f)
    //            {
    //                moveSpeed += .1f;
    //                Debug.Log($"Повышай скорость, скорость банана: {moveSpeed}");
    //            }
    //        }
    //    }
    //}
    //IEnumerator UppSpeedSkate()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(timeSpeed);
    //        if (movement.x == 0)
    //        {
    //            moveSpeed = 6f;
    //        }
    //        else
    //        {
    //            if (moveSpeed < 11f)
    //            {
    //                moveSpeed += .1f;
    //                Debug.Log($"Повышай скорость, скорость банана: {moveSpeed}");
    //            }
    //        }
    //    }
    //}
    //IEnumerator UppSpeedSamokat()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(timeSpeed);
    //        if (movement.x == 0)
    //        {
    //            moveSpeed = 8f;
    //        }
    //        else
    //        {
    //            if (moveSpeed < 12f)
    //            {
    //                moveSpeed += .1f;
    //                Debug.Log($"Повышай скорость, скорость банана: {moveSpeed}");
    //            }
    //        }
    //    }
    //}
    //IEnumerator UppSpeedSkuter()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(timeSpeed);
    //        if (movement.x == 0)
    //        {
    //            moveSpeed = 10f;
    //        }
    //        else
    //        {
    //            if (moveSpeed < 15f)
    //            {
    //                moveSpeed += .1f;
    //                Debug.Log($"Повышай скорость, скорость банана: {moveSpeed}");
    //            }
    //        }
    //    }
    //}
    public void Rocket()
    {
        if (!firstStart)
        {
            rock = true;
            endRocket = false;
        }
        
    }
    public void StopRocket()
    {
        if (!firstStart)
        {
            rock = false;
            endRocket = true;
            trail.enabled = false;
            rocketSpeed = 1f;
        }
        
    }
    //void UppSpeed()
    //{
       //while (moveSpeed < 10f)
        //{
            //moveSpeed += .1f;
        //}
    //}
}
