using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveDistance = 1.25f;
    public float jumpForce = 4f;
    private Animator anim;

    private Rigidbody rb;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    public void MoveLeft()
    {
        if (transform.position.x == 0 || transform.position.x == 1.25f)
        {
            transform.position += Vector3.left * moveDistance;
        }
    }
    public void MoveRight()
    {
        if (transform.position.x == 0 || transform.position.x == -1.25f)
        {
            transform.position += Vector3.right * moveDistance;
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            anim.SetTrigger("jump");
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
    }
    public void Slide()
    {
        anim.SetTrigger("roll");
    }
}
