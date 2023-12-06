using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public Transform orientation;
    public Transform cam;
    Animator animator;
    Rigidbody rb;

    public float speed = 5f;
    public float runSpeed = 10f;
    public float currentSpeed;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelosity;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public float groundDrag;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        SpeedControl();


        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelosity, turnSmoothTime);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentSpeed = runSpeed;
                animator.SetBool("Running", true);
                if (!grounded)
                {
                    animator.SetBool("Running", false);
                }
            }
            else
            {
                currentSpeed = speed;
                animator.SetBool("Running", false);
      
            }
            if (grounded)
            {
                
                rb.AddForce(moveDir.normalized * currentSpeed * 10f, ForceMode.Force);
                animator.SetBool("Walking", true);
            }
            else if (!grounded)
            {
                rb.AddForce(moveDir.normalized * currentSpeed * 10f, ForceMode.Force);
                animator.SetBool("Walking", false);
            }
        }
        else
        {
            animator.SetBool("Running", false);
            animator.SetBool("Walking", false);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > currentSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    }
