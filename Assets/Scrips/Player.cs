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

    SpriteRenderer sp;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
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
        sp.flipX = FlipSpriteX;
    }

    //lo mismo que update pero se ejecuta despues de este
    void LateUpdate()
    {
        anim.SetFloat("move", Mathf.Abs(Axis.x));
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
            rb2D.AddForce(JumpDir, ForceMode2D.Impulse);
        }
    }

    Vector2 DirectionX => Vector2.right * Axis.x * moveSpeed;

    Vector2 JumpDir => Vector2.up * jumpForce;

    Vector2 Axis => gameInputs.Land.Move.ReadValue<Vector2>();

    bool IsGrounding => rb2D.IsTouching(groundFilter);

    bool FlipSpriteX => Axis.x > 0 ? false : Axis.x < 0 ? true : sp.flipX;
}