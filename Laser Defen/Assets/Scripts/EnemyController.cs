using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int health = 150;

	public GameObject projectilePrefab;
	public float projectileSpeed = 10f;
	public float shotsPerSecond = 0.5f;

	public int score = 100;

	public AudioClip firingAudio;
	public AudioClip explodingAudio;

	void Update() {
		float probabilityOfFire = shotsPerSecond * Time.deltaTime;
		if(Random.value < probabilityOfFire) {
			Fire();
		}
	}

	private void Fire() {
		GameObject projectile = (GameObject)Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
		Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
		projectileRigidbody.velocity = new Vector3(0, -projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(firingAudio, transform.position);

	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		if(projectile) {
			health -= projectile.GetDamage();
			if(health <= 0) {
				Die();	
			}
			projectile.Hit();

		}
	}

	private void Die() {
		AudioSource.PlayClipAtPoint(explodingAudio, transform.position);
		ScoreKeeper scorekeeper = (ScoreKeeper)GameObject.Find("Score").GetComponent<ScoreKeeper>();
		scorekeeper.Score(this.score);
		Destroy(this.gameObject);
	}
}
