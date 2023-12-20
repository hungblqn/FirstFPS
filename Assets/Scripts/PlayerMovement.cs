using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float jumpForce = 10f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;



    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (isRunning() == true)
        {
            speed = 24f;
        }
        else speed = 12f;

        if (Input.GetKey(KeyCode.Space) && isGrounded()==true)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }   
    }

    
    bool isRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return true;
        }
        else return false;
    }
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .4f, groundMask);
    }
}
