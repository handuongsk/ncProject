using UnityEngine;

public class Shooter : MonoBehaviour {
	// Public fields
	public GameObject bulletPrefab;
	public float bulletSpeed;
	public float repeatTime;
	public int maxNumberOfBullets;

	private BulletPool bulletPool;
	private float timeSinceLastAttack;

	void Start () {
		bulletPool = ScriptableObject.CreateInstance ("BulletPool") as BulletPool;
		bulletPool.Initialize(maxNumberOfBullets, bulletPrefab, bulletSpeed);
		timeSinceLastAttack = 0;
	} // void Start () {
	
	void Update () {
		timeSinceLastAttack += Time.deltaTime;
		if (Input.GetMouseButton(0) && timeSinceLastAttack > repeatTime) {
			//Debug.Log("Shoot a bullet!");
			bulletPool.ActivateBullet (transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			timeSinceLastAttack = 0;
		}// if (Input.GetMouseButtonDown() && timeSinceLastAttack > repeatTime) {
	}// void Update ()
} // public class Shooter : MonoBehaviour
