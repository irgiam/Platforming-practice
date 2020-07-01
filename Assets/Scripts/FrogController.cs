using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour {
    [SerializeField] float speed = 3f;
    private Rigidbody2D frogRigidbody;
    Animator frogAnimator;
    public Transform headCheck;
    bool facingRight = true;
    public LayerMask groundCheck;

    private void Awake()
    {
        frogRigidbody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
