using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType{
	SmallEnemy,
	MiddleEnemy,
	BigEnemy
}
public class Enemy : MonoBehaviour {
	public int hp = 1;
	public float speed = 2;
	public int score = 0;
	public EnemyType type = EnemyType.SmallEnemy;

	public bool IsDeath = false;
	public Sprite[] explosionSprite;
	private float timer = 0;
	public int ExplosionAnimationFrame = 10;
	private SpriteRenderer render;

	public float HitTimer = 0.2f;
	private float ResetHitTimer;
	public Sprite[] HitSprites;
	private BoxCollider2D boxRender;
	// Use this for initialization
	void Start () {
		render = this.GetComponent<SpriteRenderer> ();
		boxRender = this.GetComponent<BoxCollider2D> ();
		ResetHitTimer = HitTimer;
		HitTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.down * speed * Time.deltaTime);
		if (this.transform.position.y <= -5.3f) {
			Destroy (this.gameObject);
		}
		if (IsDeath) {
			boxRender.enabled = false;
			timer += Time.deltaTime;
			int frameIndex = (int)(timer / (1f / ExplosionAnimationFrame));
			if (frameIndex >= explosionSprite.Length) {
				Destroy (this.gameObject);
			} else {
				render.sprite = explosionSprite [frameIndex];
			}
		} else {
			if ((type == EnemyType.BigEnemy) ||(type == EnemyType.MiddleEnemy)) {
				if (HitTimer >= 0) {
					HitTimer -= Time.deltaTime;
					int frameIndex = (int)((ResetHitTimer-HitTimer) / (1f / ExplosionAnimationFrame));
					frameIndex %= 2;
					render.sprite = HitSprites [frameIndex];
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)  || Input.touchCount >= 2) {
			if (BombManager._instance.BombCount > 0) {
				BeforeDie();
			}
		}
	}
	public void BeHit(){
		hp -= 1;
		if (hp <= 0) {
			BeforeDie ();
		} else {
			HitTimer = ResetHitTimer;
		}
	}
	public void BeforeDie(){
		IsDeath = true;
		GameManager._instance.PlayerScore += score;
	}
}
