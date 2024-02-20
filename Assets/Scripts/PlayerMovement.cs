using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D characterBody;
    public float baseSpeed;
    bool canJump = true;

    private ScoreManager scoreManager;
    void Start()
    {
        characterBody = gameObject.GetComponent<Rigidbody2D>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        WASD();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            characterBody.AddForce(Vector2.up * 1.1f, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    void WASD()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Rigidbody2D playerBody = gameObject.GetComponent<Rigidbody2D>();

        Vector2 force = new Vector2(horizontal * baseSpeed * Time.deltaTime, 0);
        playerBody.AddForce(force);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == "Weakspot")
        {
            scoreManager.score += 1;
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
