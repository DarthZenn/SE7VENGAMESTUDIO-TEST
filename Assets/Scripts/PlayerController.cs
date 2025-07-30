using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;

        if (moveDirection != Vector3.zero)
        {
            // Move player
            transform.Translate(moveDirection.normalized * playerSpeed * Time.deltaTime, Space.World);

            // Rotate player
            transform.rotation = Quaternion.LookRotation(moveDirection);

            // Run animation
            animator.SetFloat("Blend", 1.0f);
        }
        else
        {
            // Idle animation
            animator.SetFloat("Blend", 0);
        }
    }
}
