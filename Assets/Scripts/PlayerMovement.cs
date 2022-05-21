using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;
    public Timer timer;
    public GameObject startLine;

    [SerializeField] Transform orientation;

    [Header("Movement")]
    [SerializeField] public float moveSpeed = 6f;
    [SerializeField] float airMultiplier = 0.2f;
    float movementMultiplier = 10f;

    [Header("Sprinting")]
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] public float sprintSpeed = 6f;
    [SerializeField] float acceleration = 10f;

    [Header("Jumping")]
    public float jumpForce = 5f;

    [SerializeField] private float checkOffset = 1f;
    [SerializeField] private float checkRadius = 2f;


    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.W;

    [Header("Drag")]
    [SerializeField] float groundDrag = 7f;
    [SerializeField] float airDrag = 1f;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground Detection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.2f;

    public PlayerLook look;
    public Slide sliding;
    public bool isGrounded { get; private set; }

    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    Animator anim;

    Rigidbody rb;

    RaycastHit slopeHit;

    public AudioSource jumping;

    public GameObject nextlevelUI;

    public bool isPaused = false;

    private bool hasStarted;
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        nextlevelUI.SetActive(false);
        Time.timeScale = 1f;
        look = GetComponent<PlayerLook>();
        sliding = GetComponent<Slide>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        MyInput();
        ControlDrag();
        ControlSpeed();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {

            Jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);

        
            if (Input.GetKeyDown(KeyCode.Tab) && Time.timeScale == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    void Jump()
    {
        if (isGrounded && Time.timeScale == 1)
        {
         
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            jumping.Play();

        }
    }

    void ControlSpeed()
    {
        if (Input.GetKey(sprintKey) && isGrounded && !PauseMenu.isPaused)
        {

            if (isGrounded)
            {
                anim.SetBool("sprint", true);

            }

            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);

        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
            if (isGrounded)
            {
                anim.SetBool("sprint", false);
            }

        }
    }


    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(moveDirection);
    }

    public void MovePlayer(Vector3 direction)
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection * moveSpeed * movementMultiplier, ForceMode.Acceleration);

        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }

    void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.CompareTag("Finish Line"))
            StopWatch();

        if (col.gameObject.CompareTag("Start Line") && hasStarted == false)
        {
            hasStarted = true;
            StartStopWatch();
            Destroy(startLine, .1f);
        }
    }


    void StopWatch()
    {
        timer.StopCoroutine("StopWatch");
        this.enabled = false;
        sliding.enabled = false;
        look.enabled = false;
        

    }
    void StartStopWatch()
    {
        timer.StartCoroutine("StopWatch");
    }


}