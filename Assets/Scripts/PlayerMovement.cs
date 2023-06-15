//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private float horizontalAxis;
    private bool jump;
    private float jumpSpeed = 5;
    //private bool grounded;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Animator animator;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // controlls
        horizontalAxis = Input.GetAxisRaw("Horizontal");  // GetAxisRaw
        jump = Input.GetKey(KeyCode.Space);
        if(horizontalAxis < 0) transform.localScale =new Vector3(1,1,1);
        else if (horizontalAxis > 0) transform.localScale = new Vector3(-1, 1, 1);
        animator.SetBool("running", horizontalAxis != 0 && IsGrounded());
        animator.SetBool("jumping", jump);
        animator.SetBool("falling", !IsGrounded());



    }

    void FixedUpdate()
    {
        // left/right movement
        body.velocity = new Vector2(horizontalAxis * speed, body.velocity.y);
        //body.AddForce(transform.right * horizontalAxis * speed);

        // jump
        if (jump && IsGrounded())
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }*/

    bool IsGrounded()
    {
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, groundLayerMask);
        return (raycastHit.collider != null);
    }
}
