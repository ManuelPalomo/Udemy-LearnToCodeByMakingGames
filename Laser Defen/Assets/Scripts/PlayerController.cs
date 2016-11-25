using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject projectile;
	public int speed;

	private float laserSpeed = 5f;
	private float firingRate = 0.2f;

	private float maximumXPosition;
	private float minimumXPosition;

	public int health = 250;

	void Start() {
		float spritePadding = 1f;
		float distanceBetweenCameraAndPlayer = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceBetweenCameraAndPlayer));
		Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceBetweenCameraAndPlayer));

		this.minimumXPosition = leftMostPosition.x + spritePadding;
		this.maximumXPosition = rightMostPosition.x - spritePadding;
	}


	void Update() {
		HandleMovement();
		HandleFire();	

	}

	private void HandleMovement() {
		if(Input.GetKey(KeyCode.RightArrow)) {
			MoveRight();

		} else if(Input.GetKey(KeyCode.LeftArrow)) {
			MoveLeft();
		}
		RestrictMovement();
	}

	private void HandleFire() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
	}

	private void Fire() {
		GameObject laserInstance = (GameObject)Instantiate(projectile, this.transform.position, Quaternion.identity);
		Rigidbody2D laserRigidbody = laserInstance.GetComponent<Rigidbody2D>();
		laserRigidbody.velocity = new Vector3(0, laserSpeed, 0);
		
	}

	private void MoveRight() {
		this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
	}

	private void MoveLeft() {
		this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
	}

	private void RestrictMovement() {
		float newX = Mathf.Clamp(this.transform.position.x, minimumXPosition, maximumXPosition);
		this.transform.position = new Vector2(newX, this.transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		if(projectile) {
			health -= projectile.GetDamage();
			if(health <= 0) {
				Destroy(this.gameObject);
			}
			projectile.Hit();

		}
	}

}
