using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThirdPersonMovement : MonoBehaviour
{
    public NavMeshAgent controller;
    public Transform cam;


    public float speed = 5f;
    public float runSpeed = 10f;
    public float currentSpeed;
    public float turnSmoothTime = 0.1f;


    float turnSmoothVelosity;


    Animator animator;
    public bool useCharacterForward = false;
    bool generalPressed = false;

    float maxStamina = 100f;
    float currentStamina;
    public EnergyBar energyBar;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentStamina = maxStamina;
        energyBar.SetMaxEnergy(currentStamina);
        
    }

    private void Update()
    {
            Movement();
        
    }
    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        generalPressed = direction.magnitude >= 0.1f;

        


        if (generalPressed)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = runSpeed;
                currentStamina -= maxStamina / 800f;
                energyBar.SetEnergy(currentStamina);
                animator.SetBool("isRunning", true);
                if(currentStamina < 0)
                {
                    currentSpeed = speed;
                    currentStamina = 0f;
                    animator.SetBool("isRunning", false);
                }
            }

            else
            {
                currentSpeed = speed;

                currentStamina += maxStamina / 300f;
                energyBar.SetEnergy(currentStamina);
                animator.SetBool("isRunning", false);
                if(currentStamina > maxStamina)
                {
                    currentStamina = 100f;
                }
           
            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelosity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            

        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);

            currentStamina += maxStamina / 400f;
            energyBar.SetEnergy(currentStamina);
            if (currentStamina > maxStamina)
            {
                currentStamina = 100f;
            }
        }
    }

}


