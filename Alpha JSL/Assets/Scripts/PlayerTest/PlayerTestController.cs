using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour {

	protected Rigidbody2D rb2d;
	protected bool grounded;

	public float speed = 0.1f;
	public float jump = 5.0f;

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
        move.x = Input.GetAxis ("Horizontal");
		Debug.Log(rb2d.position.y);
		rb2d.position = rb2d.position + move * speed;
	}

}
