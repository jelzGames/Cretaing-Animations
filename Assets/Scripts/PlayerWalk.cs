using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour {

    public float rotationSpeed = 3f;
    private float rotateY;
    public float h, v;

    PLayerAnimation playerAnimation;

	// Use this for initialization
	void Awake () {
        playerAnimation = GetComponent<PLayerAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckMovement();
        AnimatePlauer();
        CheckForAttack();

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
