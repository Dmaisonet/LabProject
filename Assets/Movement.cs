using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] int speed = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {   
        if(!inBounds()) {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        
        if(movement > 0  && !isFacingRight || movement < 0 && isFacingRight)
        {
            Flip();
        }

        if(jumpPressed && isGrounded)
        {
            Jump();
        }
    }

    void Flip()
    {
        transform.Rotate(0,180,0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private bool inBounds()
    {   
        return (transform.position.x <= 10 && transform.position.x >= -10)? true:false;
    }
}
