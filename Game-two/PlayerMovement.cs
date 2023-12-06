using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D character;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    bool jump = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        //Движение персонажа
        character.Move(horizontalMove*Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
