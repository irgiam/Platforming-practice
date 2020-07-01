using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumController : MonoBehaviour {
    [SerializeField] float walkSpeed = 1.5f;
    Rigidbody2D opossumRigidbody;
    Animator opossumAnimator;
    public Transform turningObject1;
    public Transform turningObject2;
    public LayerMask objectLayer;
    bool facingRight = false;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        opossumRigidbody = GetComponent<Rigidbody2D>();
        opossumAnimator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vector3 targetVelocityOpo = new Vector2(walkSpeed, opossumRigidbody.velocity.y);
        opossumRigidbody.velocity = Vector3.SmoothDamp(opossumRigidbody.velocity, targetVelocityOpo, ref velocity, 0.05f);

        //this.transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

        if (walkSpeed >= 0 && facingRight == false)
        {
            Flip();
        }
        else if (walkSpeed < 0 && facingRight == true)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }

    void TurnAway()
    {
        walkSpeed *= -1;
    }

    private void OnTriggerEnter2D(Collider2D otherCollision)
    {
        if (otherCollision.tag == "Turn Object")
        {
            TurnAway();
        }
    }
}
