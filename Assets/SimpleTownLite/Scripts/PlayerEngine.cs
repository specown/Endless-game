using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEngine : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float turnSpeed = 6f;
    private float verticalVelocity = 0.0f;
    private float gravity = 10.0f;



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        moveVector.y = verticalVelocity;

        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

    }
}