using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;

    Rigidbody rb;

    public float MoveSpeed => Mathf.Abs(rb.velocity.x);

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    public void Move(float moveSpeed)
    {
        if (input.IsMove)
        {
            transform.localScale = new Vector3(input.AxesX, 1f, 1f);
        }
        SetVelocityX(moveSpeed * input.AxesX);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        SetVelocity(new Vector3(velocityX, rb.velocity.y, rb.velocity.z));
    }
    
    public void SetVelocityY(float velocityY)
    {
        SetVelocity(new Vector3(rb.velocity.x, velocityY, rb.velocity.z));
    }
}
