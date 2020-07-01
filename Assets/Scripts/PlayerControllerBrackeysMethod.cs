using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBrackeysMethod : MonoBehaviour {

    float horizontalMove;
    [SerializeField] float runSpeed = 3f;
    private Vector3 velocity = Vector3.zero;
    private float movementSmoothing = 0.005f;
    public float jumpForce = 6f;
    private Rigidbody2D myRigidBody;
    public LayerMask groundLayer;
    public Transform groundCheck;
    Animator myAnimator;
    bool facingRight = true;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMove);
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove * runSpeed));
        if (horizontalMove < 0 && facingRight == true)
        {
            Flip();
        }
        else if(horizontalMove > 0 && facingRight == false)
        {
            Flip();
        }
        myAnimator.SetBool("IsJumping", !IsGrounded());
        //transform.Translate(horizontalMove, 0, 0);
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = Vector3.SmoothDamp(myRigidBody.velocity, targetVelocity,ref velocity, movementSmoothing, Mathf.Infinity, Time.deltaTime);
        IsGrounded();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (IsGrounded())
        {
            myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        //if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.6f, groundLayer.value))
        //if (Physics2D.OverlapArea(new Vector2(groundCheck.position.x - 0.1f, groundCheck.position.y), new Vector2(groundCheck.position.x + 0.1f, groundCheck.position.y) , groundLayer))
        if (Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }
}
