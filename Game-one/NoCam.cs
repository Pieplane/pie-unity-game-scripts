using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCam : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed;
    public float runSpeed;
    public float currentSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelosity;


    Animator animator;
    public bool useCharacterForward = false;
    bool standartWalk;

    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentSpeed = runSpeed;
                animator.SetBool("isRunning", true);
            }
            else
            {
                currentSpeed = speed;
                animator.SetBool("isRunning", false);
            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelosity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


        }

    }


