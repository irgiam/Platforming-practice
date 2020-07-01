using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float runSpeed = 0.5f;
    private Rigidbody2D myRigidBody;
    float horizontalMove;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        HanddleMovement(horizontalMove);
    }

    private void HanddleMovement(float horizontal)
    {
        myRigidBody.velocity = new Vector2(horizontal * runSpeed, myRigidBody.velocity.y);
    }
}
