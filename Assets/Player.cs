using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //CharacterController characterController;

    //public float speed = 6.0f;
    //public float jumpSpeed = 8.0f;
    //public float gravity = 20.0f;

    //private Vector3 moveDirection = Vector3.zero;

    //void Start()
    //{
    //    characterController = GetComponent<CharacterController>();
    //}

    //void Update()
    //{
    //if (characterController.isGrounded)
    //{
    //    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    //    moveDirection *= speed;

    //    if (Input.GetButton("Jump"))
    //    {
    //        moveDirection.y = jumpSpeed;
    //    }
    //}

    //    moveDirection.y -= gravity * Time.deltaTime;

    //    characterController.Move(moveDirection * Time.deltaTime);
    //}

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 3.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Rotate Player
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

    }
}