//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;


public class moveBySwipe : MonoBehaviour
{
    public float speed = 10.0f;
    public int slideForce = 2;
    public int jumpForce = 2;
    public float animationSpeedRatio = 4;
    public Rigidbody rb;
    public Animator animator;
    public GroundCheck groundcheck;
    public float accelerationRate = 0.2f; // Rate at which speed increases per second
    public AudioSource movementSound;

    private float timer = 0.0f;
    private float speedIncreaseInterval = 5.0f;
    private Vector2 fingerDownV2 = Vector2.zero;
    private float elapsedTime = 0f;
    private bool hasStartASwipe = false;
    private int pos = 0;


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

        float yRatio = Mathf.Abs(inputMovement.x - fingerDownV2.x) / Screen.width;
        float xRatio = Mathf.Abs(inputMovement.y - fingerDownV2.y) / Screen.height;
        if (!GameManager.instance.isEnded)
        {
            if (yRatio > xRatio
                && yRatio > 0.1
                && Mathf.Abs(Time.deltaTime - elapsedTime) < 0.2
                && hasStartASwipe)
            {
                if (inputMovement.x - fingerDownV2.x < 0 && pos >= 0)
                {
                    movementSound.Play();
                    pos -= 1;
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                else if (inputMovement.x - fingerDownV2.x > 0 && pos <= 0)
                {
                    movementSound.Play();
                    pos += 1;
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }

            else if (xRatio > yRatio && xRatio > 0.1
                && Mathf.Abs(Time.deltaTime - elapsedTime) < 0.2
                && hasStartASwipe)
            {
                if (groundcheck.isGroundTouched)
                {
                    rb.velocity = new Vector3(rb.velocity.x, jumpForce, speed);
                    animator.SetBool("isGrounded", groundcheck.isGroundTouched);

                }
            }
            hasStartASwipe = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance.isEnded)
        {
            rb.velocity = new Vector3(0,0, 0);
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= speedIncreaseInterval)
            {
                GameManager.Instance.addScore();
            }

            // Increase speed gradually over time
            if (timer >= speedIncreaseInterval && speed < 5.6f)
            {
                speed += accelerationRate;
                timer = 0.0f; // Reset the timer after increasing speed
            }


            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
            animator.SetFloat("Speed", speed);
            animator.SetBool("isGrounded", groundcheck.isGroundTouched);
            animator.speed = speed / animationSpeedRatio;
        }
    }
}