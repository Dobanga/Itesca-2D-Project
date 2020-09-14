using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;
    Rigidbody2D rb2D;

    Inputs gameInputs;

    [SerializeField]
    ContactFilter2D groundFilter;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        gameInputs = new Inputs();
    }

    void Start()
    {
        gameInputs.Land.Jump.performed += _ => Jump();
    }

    void OnEnable()
    {
        gameInputs.Enable();
    }

    void OnDisable()
    {
        gameInputs.Disable();
    }

    //cosas normales
    void Update()
    {
        if(IsMoving)
            if(Axis.x > 0)
                transform.localRotation = Quaternion.Euler(0,136,0);
            
            if(Axis.x < 0)
                transform.localRotation = Quaternion.Euler(0, -136,0);
            
    }

    //lo mismo que update pero se ejecuta despues de este
    void LateUpdate()
    {
        anim.SetFloat("move", Mathf.Abs(Axis.x));
        anim.SetBool("Ground", IsGrounding);
    }

    //cosas de física
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        rb2D.position += DirectionX * Time.deltaTime;
    }

    void Jump()
    {
        if (IsGrounding)
        {
            anim.SetTrigger("Jump");
            rb2D.AddForce(JumpDir, ForceMode2D.Impulse);
        }
    }

    Vector2 DirectionX => Vector2.right * Axis.x * moveSpeed;

    Vector2 JumpDir => Vector2.up * jumpForce;

    Vector2 Axis => gameInputs.Land.Move.ReadValue<Vector2>();

    /// <summary>
    /// Check if player is moving with inputs H and V.
    /// </summary>
    bool IsMoving => AxisMagnitudeAbs > 0;

    /// <summary>
    /// Returns the magnitude of the Axis with inputs H and V.
    /// </summary>
    /// <returns></returns>
    float AxisMagnitudeAbs => Mathf.Abs(Axis.magnitude);

    bool IsGrounding => rb2D.IsTouching(groundFilter);
}