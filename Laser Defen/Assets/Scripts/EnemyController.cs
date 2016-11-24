using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public int health = 150;

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
