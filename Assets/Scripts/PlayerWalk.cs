using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {

    public float rotationSpeed = 3f;
    private float rotateY;
    public float h, v;

    PLayerAnimation playerAnimation;

    public Transform groundCheckPosition;
    public float jumpPower = 200f;
    public float radius = 0.3f;
    public LayerMask groundLayer;
    private Rigidbody myBody;
    private bool isGrounded, hasJumped;

	// Use this for initialization
	void Awake () {
        myBody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PLayerAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckMovement();
        AnimatePlauer();
        CheckForAttack();
        CheckGroundCollisionAndJump();


    }

    void CheckGroundCollisionAndJump()
    {
        isGrounded = Physics.OverlapSphere(groundCheckPosition.position, radius, groundLayer).Length > 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                myBody.AddForce(new Vector3(0,jumpPower, 0));
                hasJumped = true;
                playerAnimation.Jump(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (hasJumped)
            {
                hasJumped = false;
                playerAnimation.Jump(false);
            }
        }
    }

    void CheckForAttack()
	{
        if (Input.GetMouseButtonDown(0))
		{
            playerAnimation.Attack1();
		}
		if (Input.GetMouseButtonDown(1))
		{
            playerAnimation.Attack2();
		}

	}

	void CheckMovement()
	{
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        rotateY -= h * rotationSpeed;

        transform.localRotation = Quaternion.AngleAxis(rotateY, Vector3.up);
	}

	void AnimatePlauer()
	{
        if (v != 0 )
		{
            playerAnimation.PlayerWalk(true);

	    }
		else
		{
			playerAnimation.PlayerWalk(false);

		}
	}
}
