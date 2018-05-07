using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public float rate = 0.2f;
	public GameObject bullet;
	// Use this for initialization

	public void fire(){
		GameObject.Instantiate (bullet, transform.position, Quaternion.identity);
	}
	public void openFire(){
		InvokeRepeating ("fire", 0.5f, rate);
	}
	public void stopFire(){
		CancelInvoke("fire");
	}
}
