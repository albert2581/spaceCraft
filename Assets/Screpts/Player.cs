using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool IsAnimation = true;
	public int frameCountPerSec = 10;
	public float timer=0;
	public Sprite[] sprite;
	private SpriteRenderer SpriteRender;

	private bool isMouseDown = false;
	private Vector3 lastMousePosition = Vector3.zero;
	private Transform myPlayer;

	public float SpecialGunTime = 15f;
	private float ResetSpecialGun;
	private int gunCount = 1;
	public Gun GunTop;
	public Gun GunLeft;
	public Gun GunRight;
	// Update is called once per frame
	void Start(){
		SpriteRender = this.GetComponent<SpriteRenderer> ();
		myPlayer = GameObject.FindGameObjectWithTag ("Player").transform;
		ResetSpecialGun = SpecialGunTime;
		SpecialGunTime = 0;
		GunTop.openFire();
	}
	void Update () {
		if (IsAnimation) {
			timer += Time.deltaTime;
			int frameIndex = (int)(timer / (1f / frameCountPerSec));
			int frame = frameIndex % 2;
			SpriteRender.sprite = sprite [frame];
		}
		if(Input.GetMouseButtonDown(0)){
			isMouseDown = true;
		}
		if(Input.GetMouseButtonUp(0)){
			isMouseDown = false;
			lastMousePosition = Vector3.zero;
		}
		if (isMouseDown && GameManager._instance.gameState == GameState.Running) {
			if (lastMousePosition != Vector3.zero) {
				Vector3 offset = Camera.main.ScreenToWorldPoint (Input.mousePosition) - lastMousePosition;
				transform.position = transform.position + offset;
				CheckPlayerPosition ();
			}
			lastMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		}
		SpecialGunTime -= Time.deltaTime;
		if (SpecialGunTime > 0) {
			if (gunCount == 1) {
				transformToSpecialGun ();
			} 
		} else {
			if (gunCount == 2) {
				transformToNormalGun ();
			}
		}
	}

	private void transformToSpecialGun(){
		gunCount = 2;
		GunLeft.openFire();
		GunRight.openFire();
		GunTop.stopFire();
	}
	private void transformToNormalGun(){
		gunCount = 1;
		GunLeft.stopFire();
		GunRight.stopFire();
		GunTop.openFire();
	}

	private void CheckPlayerPosition(){
		Vector3 pos = transform.position;
		float x = pos.x;
		float y = pos.y;
		if (x < -2.3f) {
			x = -2.3f;
		}
		if (x > 2.35f) {
			x = 2.35f;
		}
		if (y < -3.9f) {
			y = -3.9f;
		}
		if (y > 3.5f) {
			y = 3.5f;
		}
		transform.position = new Vector3 (x,y,0);
	}
	public void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Award") {
			Award award = collider.GetComponent<Award> ();
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			if (award.type == 0) {
				SpecialGunTime = ResetSpecialGun;
				Destroy (collider.gameObject);
			} else if (award.type == 1) {
				BombManager._instance.AddBomb ();
				Destroy (collider.gameObject);
			}
		} else if (collider.tag == "Enemy") {
			Application.LoadLevel ("gameScreen");
			print ("ReloadScene");
		}
	}
}