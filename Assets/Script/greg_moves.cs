using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;


public class moveByStick : MonoBehaviour
{
    public float speed = 10.0f;
    public int slideForce = 5;
    public float animationSpeedRatio = 4;
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
        elapsedTime += Time.deltaTime;
        hasStartASwipe = true;
    }

    private void OnFingerUp(EnhancedTouch.Finger finger)
    {
        Vector2 inputMovement = finger.screenPosition;
        if (Mathf.Abs(inputMovement.x - fingerDownV2.x)/Screen.width > 0.1 
            && Mathf.Abs(Time.deltaTime - elapsedTime) < 0.2 
            && hasStartASwipe)
        {
            rb.velocity = new Vector3(((inputMovement.x - fingerDownV2.x) / Mathf.Abs(inputMovement.x - fingerDownV2.x)) * slideForce, rb.velocity.y, rb.velocity.z);
            hasStartASwipe = false;
        }
    }

    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,speed);
        animator.SetFloat("Speed", speed);
        animator.SetBool("isGrounded", groundcheck.isGroundTouched);
        animator.speed = speed/animationSpeedRatio;
    }
}