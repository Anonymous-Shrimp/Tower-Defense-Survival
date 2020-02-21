using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotSpeed = 10;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        //float h = Input.GetAxis("Mouse X")*rotSpeed;
        // float k = Input.GetAxis("Mouse Y")*rotSpeed;
        // Vector3 rot = new Vector3(0, h, 0);
        // transform.Rotate(rot);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v != 0 || h != 0)
        {
            Vector3 fwd = new Vector3(h, 0, v);
            fwd = Camera.main.transform.TransformDirection(fwd);
            fwd.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(fwd), rotSpeed * Time.deltaTime);
        }
    }
}
