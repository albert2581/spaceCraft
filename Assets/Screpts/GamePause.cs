using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void clickButton(){
		GameManager._instance.transformGameState ();
	}
	public void quitGame(){
		Application.Quit();
	}
}
