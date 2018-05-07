using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 2f;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * speed*Time.deltaTime);
		if (transform.position.y > 4.3f) {
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Enemy"){
			if (!other.GetComponent<Enemy> ().IsDeath) {
				other.gameObject.SendMessage ("BeHit");
				GameObject.Destroy (this.gameObject);
			}
		}
	}
}
