using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    [SerializeField]
    float duaration = 1;
    float timer = 0;

    [SerializeField]
    float Velocidad = 2;

    Rigidbody2D rb2DPlayer;

    enum Direction
    {
        RIGHT = 0,
        LEFT,
        UP,
        DOWN
    }

    [SerializeField]
    Direction direction;

    Vector2 moveDir = Vector2.right;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        CheckDir(ref moveDir);
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + moveDir * Time.deltaTime * Velocidad);
        timer += Time.deltaTime;
        if (rb2DPlayer)
        {
            rb2DPlayer.velocity = rb2DPlayer.velocity + rigidbody2D.velocity;
        }
        if (timer >= duaration)
        {
            timer = 0;

            if(direction == Direction.RIGHT)
            {
                direction = Direction.LEFT;
            } else if(direction == Direction.LEFT)
            {
                direction = Direction.RIGHT;
            }

            if(direction == Direction.UP)
            {
                direction = Direction.DOWN;
            } else if(direction == Direction.DOWN)
            {
                direction = Direction.UP;
            }

           // direction = direction == Direction.RIGHT ? Direction.LEFT : Direction.RIGHT;
            CheckDir(ref moveDir);
            if (rb2DPlayer)
            {
                rb2DPlayer.velocity = new Vector2(rigidbody2D.velocity.x, rb2DPlayer.velocity.y);
            }
        }
    }

    void CheckDir(ref Vector2 moveDir)
    {
        switch (direction)
        {
            case Direction.RIGHT:
                moveDir = Vector2.right;
                break;
            case Direction.LEFT:
                moveDir = Vector2.left;
                break;
            case Direction.UP:
                moveDir = Vector2.up;
                break;
            case Direction.DOWN:
                moveDir = Vector2.down;
                break;
        }
    }
}