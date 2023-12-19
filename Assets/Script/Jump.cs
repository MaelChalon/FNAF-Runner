using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class Jump : MonoBehaviour
{
    public int jumpForce = 2;
    public Rigidbody rb;
    public Animator animator;
    public GroundCheck groundcheck;

    private Vector2 fingerDownV2 = Vector2.zero;
    private float elapsedTime = 0f;
    private bool hasStartASwipe = false;


    public void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
        EnhancedTouch.Touch.onFingerUp += OnFingerUp;
    }

    public void OnDisable()
    {
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouch.Touch.onFingerUp -= OnFingerUp;
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        fingerDownV2 = finger.screenPosition;
        elapsedTime = Time.deltaTime;
        hasStartASwipe = true;
    }

    private void OnFingerUp(EnhancedTouch.Finger finger)
    {
        Vector2 inputMovement = finger.screenPosition;
        //Debug.LogError("c1 :");
        //Debug.LogError(Mathf.Abs(inputMovement.x - fingerDownV2.x) / Screen.width > 0.1);
        //Debug.LogError("c2 :");
        //Debug.LogError(Mathf.Abs(Time.deltaTime - elapsedTime) < 0.2);

        if (Mathf.Abs(inputMovement.x - fingerDownV2.x) / Screen.width > 0.1
            && Mathf.Abs(Time.deltaTime - elapsedTime) < 0.2
            && hasStartASwipe)
        {
            if (groundcheck.isGroundTouched)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
            hasStartASwipe = false;
        }
    }

    void Update()
    {

    }
}
