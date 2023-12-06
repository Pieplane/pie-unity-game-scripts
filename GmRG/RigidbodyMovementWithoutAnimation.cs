using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovementWithoutAnimation : MonoBehaviour
{
    public Transform orientation;
    public Transform cam;
    Rigidbody rb;
    Animator anim;

    public float speed = 5f;
    public float runSpeed = 10f;
    public float currentSpeed;
    float turnSmoothVelosity;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public float groundDrag;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        SpeedControl();

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


        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentSpeed = runSpeed;
                anim.SetBool("isRunning", true);
            }
            else
            {
                currentSpeed = speed;
                anim.SetBool("isRunning", false);
            }
                rb.AddForce(moveDir.normalized * currentSpeed * 10f, ForceMode.Force);
                anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > currentSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            Debug.Log("Speed control");
        }
    }
    }
