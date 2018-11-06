using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour {

	protected Rigidbody2D rb2d;
	protected bool grounded;

	public float speed = 0.1f;
	public float jump = 5.0f;
	public Rigidbody2D ball;
	public GameObject hand;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 move = Vector2.zero;

		if (rb2d.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			grounded = true;
		} else {
			grounded = false;
		}
		
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			rb2d.velocity = new Vector2(0.0f,jump);
		}

		if (Input.GetKey(KeyCode.E) && rb2d.IsTouchingLayers(LayerMask.GetMask("Take"))) {
			ball.transform.position = new Vector2(hand.transform.position.x, hand.transform.position.y + 0.5f);
			ball.angularVelocity = 0.0f;
		}

		if (Input.GetKeyUp(KeyCode.E) && rb2d.IsTouchingLayers(LayerMask.GetMask("Take"))) {
			ball.velocity = new Vector2(0.0f, 0.0f);
			ball.AddForce((transform.up + transform.right) * 300.0f);
		}
		
		move.x = Input.GetAxis ("Horizontal");
		rb2d.position = rb2d.position + move * speed;
	}

}
