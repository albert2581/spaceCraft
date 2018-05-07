using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BombManager : MonoBehaviour {
	public Text BombText;
	public int BombCount;
	public static BombManager _instance;
	public GameObject BombSound;
	// Use this for initialization
	void Start () {
		_instance = this;
		BombCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.touchCount >= 2) {
			if (BombCount > 0) {
				UseABomb ();
				BombSound.GetComponent<AudioSource> ().Play ();
			}
		}
	}
	public void AddBomb(){
		BombCount++;
		BombText.text = "" + BombCount;
	}
	public void UseABomb(){
		BombCount--;
		BombText.text = "" + BombCount;
	}
}
