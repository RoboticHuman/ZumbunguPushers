using UnityEngine;
using System.Collections;

public class Player : MovingObject {
	
	protected override void Move () {
		if (!isLocalPlayer)
			return;
		int horizontal = (int) Input.GetAxisRaw ("Horizontal");
		int vertical = (int) Input.GetAxisRaw ("Vertical");
		Vector2 dir;
		
		if (!floor) {
			if (horizontal != 0) {
				dir = Vector2.right * horizontal;
				rigidBody.velocity += (float)0.5*dir;
			}
		} else {
			if (horizontal != 0) {
				dir = floor.transform.right * horizontal;
				rigidBody.velocity += dir;
			}
			if (vertical != 0) {
				dir = floor.transform.up * vertical;
				rigidBody.AddForce (100 * dir);
			}
		}
	}
	
	protected override void Jump () {
		
	}
	
	protected override void Drop () {
		
	}
	
	public override bool Push (Vector2 force) {
		return false;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (!isLocalPlayer)
			return;
		Enemy enemy = col.gameObject.GetComponent<Enemy>();
		if (enemy) {
			rigidBody.velocity = Vector2.zero;
			enemy.Push (rigidBody.velocity);
		}
	}

	void FixedUpdate () {
		Move ();

	}

}
