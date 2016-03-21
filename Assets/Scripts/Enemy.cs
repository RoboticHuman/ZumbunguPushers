using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {
	
	protected override void Move () {
		
	}
	
	protected override void Jump () {
		
	}
	
	protected override void Drop () {
		
	}
	
	public override bool Push (Vector2 force) {
		rigidBody.AddForce (force);
		return true;
	}

}
