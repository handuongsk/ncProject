using UnityEngine;
/* This class handles the controlling of the player.
 */
public class PlayerController : MonoBehaviour {
	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	} // void Start () {
	
	// Update is called once per frame
	void Update () {
		HandleMovement ();
		EnforceBounds ();
	} // void Update () {

	private void EnforceBounds (){
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;
		Vector3 currentPosition = transform.position;
		Vector3 newPosition = transform.position; 

		float xMax = cameraPosition.x + Constant.screenWidthHalf - renderer.bounds.size.x / 2;
		float xMin = cameraPosition.x - Constant.screenWidthHalf + renderer.bounds.size.x / 2;
		float yMax = cameraPosition.y + Constant.screenHeightHalf - renderer.bounds.size.y / 2;
		float yMin = cameraPosition.y - Constant.screenHeightHalf + renderer.bounds.size.y / 2;

		// Detects if the user is out of bounds for each coordinate.
		// If so, it moves the user to the nearest boundary.
		if (currentPosition.x < xMin || currentPosition.x > xMax) {
			newPosition.x = Mathf.Clamp(currentPosition.x, xMin, xMax );
		} // if (currentPosition.x < xMin || currentPosition.x > xMax)
		if (currentPosition.y < yMin || currentPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( currentPosition.y, yMin, yMax );
		} // if (currentPosition.y < yMin || currentPosition.y > yMax)
		
		transform.position = newPosition;
	}// private void EnforceBounds (){

	private void HandleMovement(){
		Vector3 moveDirection = Vector3.zero;

		if (Input.GetKey (KeyCode.D)) {
			moveDirection += Vector3.right;
		}
		if (Input.GetKey (KeyCode.A)) {
			moveDirection += Vector3.left;
		}
		if (Input.GetKey (KeyCode.S)) {
			moveDirection += Vector3.down;
		} 
		if (Input.GetKey (KeyCode.W)) {
			moveDirection += Vector3.up;
		}// else if (Input.GetKey (KeyCode.UpArrow)) 
		
		if (moveDirection != Vector3.zero) {
			Vector3 target = moveDirection.normalized * moveSpeed;
			float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

			// If the new velocity is different from the current velocity,
			// than update it. Otherwise, do not do anything.
			if (rigidbody2D.velocity.x != moveDirection.x 
			    || rigidbody2D.velocity.y != moveDirection.y) {
				rigidbody2D.velocity = new Vector2 (target.x, target.y);
				transform.rotation = Quaternion.Euler (0, 0, targetAngle);
			}
		} else {
			rigidbody2D.velocity = Vector2.zero;
		} // } else {
	} // private void handleMovement(){
} // public class PlayerController : MonoBehaviour {
