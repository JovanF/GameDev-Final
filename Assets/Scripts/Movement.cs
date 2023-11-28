using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private float horizontalInput = 0;
    private bool grounded = false;
    private Rigidbody2D rb;
    public LayerMask groundlayer;
    public float customGravity = -9.8f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0f, customGravity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate the new position
        Vector2 newPosition = new Vector2(transform.position.x + horizontalInput * moveSpeed * Time.deltaTime, transform.position.y);
        // Move the character
        transform.position = newPosition;

        //Ground check
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        if (grounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }



        if (this.transform.position.y < -6)
        {
            Destroy(gameObject);
            //swap to scene /Or figure out how to bring up game over ui

        }


    }

    void Jump()
    {
        Debug.Log("jumping");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
