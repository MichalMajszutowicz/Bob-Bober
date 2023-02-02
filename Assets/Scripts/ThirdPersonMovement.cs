using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject player;
    public GameObject respawnPoint;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isWatered;
    public LayerMask waterMask;

    Vector3 startPosition;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    Animator m_Animator;

    [SerializeField] public AudioSource m_AudioSource;
    [SerializeField] public AudioSource jumpAudioSource;
    [SerializeField] public AudioSource kickAudioSource;
    // Update is called once per frame




    void Start()
    {
        startPosition = transform.position;
        controller = GetComponent<CharacterController>();
        m_AudioSource = GetComponent<AudioSource>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            controller.slopeLimit = 45.0f;
            velocity.y = -2f;
        }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpAudioSource.Play();
            controller.slopeLimit = 100.0f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            m_Animator.SetBool("isJumping", true);
        }
        else
        {
            m_Animator.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            m_Animator.SetBool("isAttacking", true);
            kickAudioSource.Play();
        }
        else
        {
            m_Animator.SetBool("isAttacking", false);
        }
        if (Input.GetKeyDown("r"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            m_Animator.SetBool("isRunning", true);
        }
        else
        {
            m_Animator.SetBool("isRunning", false);
        }

        if ((horizontal != 0 || vertical != 0) && isGrounded)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


        isWatered = Physics.CheckSphere(groundCheck.position, groundDistance, waterMask);

        // if(isWatered)
        // {
        //     transform.position=startPosition;
        // }

    }


}