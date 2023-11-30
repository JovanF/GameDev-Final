using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Movement : MonoBehaviour
{


    private float horizontalInput = 0;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool canJump = true;
    private Rigidbody2D rb;

    public TMP_Text scoreText;
    private int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate the new position
        Vector2 newPosition = new Vector2(transform.position.x + horizontalInput * moveSpeed * Time.deltaTime, transform.position.y);
        // Move the character
        transform.position = newPosition;

        //destroys object when it gets off screen.

        if (this.transform.position.y < -6)
        {
            Destroy(gameObject);
            //swap to scene /Or figure out how to bring up game over ui

        }

        if (canJump && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        canJump = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("branch"))
        {
            canJump = true;
            score++;
            UpdateScoreText();

        }

        if (collision.gameObject.CompareTag("collider"))
        {
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EndScene");
        }
    }

    void UpdateScoreText()
    {

        scoreText.text = "Score: " + score.ToString();

    }

}
