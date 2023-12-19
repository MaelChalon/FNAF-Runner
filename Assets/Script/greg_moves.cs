using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByStick : MonoBehaviour
{
    public Joystick js;
    public float speed = 10.0f;
    public Rigidbody rb;
    public Animator animator;
    public GroundCheck groundcheck;

    // Update is called once per frame
    void Update()
    {
        Vector2 inputMovement = js.Direction;
        rb.velocity = new Vector3(inputMovement.x * speed, rb.velocity.y, inputMovement.y * speed);
        animator.SetFloat("Speed", inputMovement.magnitude * speed);
        animator.SetBool("isGrounded", groundcheck.isGroundTouched);
    }
}