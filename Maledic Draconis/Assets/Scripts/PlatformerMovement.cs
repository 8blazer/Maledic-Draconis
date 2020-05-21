using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    bool grounded = false;
    void Start()
    {

    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (moveX > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
        }
        if (moveX < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0));
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            NotGrounded();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Grounded();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        Grounded();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        NotGrounded();
    }
    public void Grounded()
    {
        grounded = true;
    }

    public void NotGrounded()
    {
        grounded = false;
    }
}



