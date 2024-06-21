/*
Author: KangHao
Date: 21 june 2024
Description: This script handles player movement in Unity.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Requires the GameObject to have a CharacterController component.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The camera attached to the player.
    /// </summary>
    public Camera playerCamera;

    /// <summary>
    /// Walking speed of the player.
    /// </summary>
    public float walkSpeed = 6f;

    /// <summary>
    /// Running speed of the player.
    /// </summary>
    public float runSpeed = 12f;

    /// <summary>
    /// Jump power of the player.
    /// </summary>
    public float jumpPower = 7f;

    /// <summary>
    /// Gravity applied to the player.
    /// </summary>
    public float gravity = 10f;

    /// <summary>
    /// Speed at which the player looks around.
    /// </summary>
    public float lookSpeed = 2f;

    /// <summary>
    /// Maximum angle the player can look up or down.
    /// </summary>
    public float lookXLimit = 45f;

    /// <summary>
    /// Default height of the player.
    /// </summary>
    public float defaultHeight = 2f;

    /// <summary>
    /// Height of the player when crouching.
    /// </summary>
    public float crouchHeight = 1f;

    /// <summary>
    /// Speed of the player when crouching.
    /// </summary>
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    /// <summary>
    /// Initializes the CharacterController and locks the cursor.
    /// </summary>
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Handles the movement and rotation of the player.
    /// </summary>
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.R) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
