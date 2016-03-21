using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

	public LayerMask blockingLayer;			//Layer on which collision will be checked.
	public float checkFloorDist;
	public float stoppingTime;
	protected RaycastHit2D floor;
	protected float rotationTime;
	protected float pushStopTime;
	protected bool bIsPushing;
	protected Rigidbody2D rigidBody;

	
	protected virtual void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		bIsPushing = false;
	}

	protected virtual void Move () {
		
	}

	protected virtual void Jump () {
		
	}

	protected virtual void Drop () {
		
	}


	protected void Update () {
		floor = checkFloor();
		if (floor) {
			rotationTime += Time.deltaTime;
			transform.rotation = Quaternion.Lerp(transform.rotation, floor.transform.rotation, (float)(rotationTime/0.5) ) ;
		} else
			rotationTime = 0;

		if (bIsPushing) {
			pushStopTime += Time.deltaTime;
			rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero, pushStopTime/stoppingTime);
		}

		if (bIsPushing && rigidBody.velocity.magnitude <= float.Epsilon) {
			bIsPushing = false;
			pushStopTime = 0;
		}
	}

	protected RaycastHit2D checkFloor() {
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (0, -checkFloorDist);
		RaycastHit2D hit;
		GetComponent<BoxCollider2D>().enabled = false;
		hit = Physics2D.Linecast (start, end, blockingLayer);
		Debug.DrawLine (start, end);
		GetComponent<BoxCollider2D>().enabled = true;
		return hit;
	}
	
	public abstract bool Push (Vector2 force);
}






