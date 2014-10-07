using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	// Private fields
	private bool isActive;
	private float moveSpeed;

	protected void Start () {
		isActive = false;
		renderer.enabled = false;
	} // void Start () {
	
	void Update () {
	}// void Update ()

	public void ActivateBullet(Vector3 startingPosition, Vector3 targetPosition) {
		transform.position = startingPosition;
		Vector3 target = moveSpeed * (targetPosition - startingPosition).normalized;
		rigidbody2D.velocity = new Vector2 (target.x, target.y);

		float targetAngle = Mathf.Atan2 (targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, targetAngle);

		isActive = true;
		renderer.enabled = true;
	}// public void ActivateBullet(Vector3 startingPosition, Vector3 targetPosition)

	public void OnBecameInvisible() {
		//Debug.Log ("I am disabled!");
		DeactivateBullet ();
	}// public void OnBecameInvisible()

	public void DeactivateBullet() {
		isActive = false;
		renderer.enabled = false;
		rigidbody2D.velocity = Vector2.zero;
	}// public DeactivateBullet(

	public bool IsActive { 
		get {return isActive;}
	}// public bool IsActive{

	public void SetSpeed(float speed) {
		moveSpeed = speed;
	}// public void SetSpeed(float speed)
} //public class BulletController : MonoBehaviour {
