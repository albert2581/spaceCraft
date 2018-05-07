using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState{
	Running,
	Pause
}
public class GameManager : MonoBehaviour {
	public GameState gameState =GameState.Running;

	public static GameManager _instance;
	public int PlayerScore = 0;
	public Text ScoreUI;
	void Awake(){
		_instance = this;
	}

	// Update is called once per frame
	void Update () {
		ScoreUI.text = "Score:" +PlayerScore;
	}
	public void transformGameState(){
		if (gameState == GameState.Running) {
			GamePause ();
		}else if(gameState == GameState.Pause){
			continueGame ();
		}
	}

	public void GamePause(){
		Time.timeScale = 0;
		gameState = GameState.Pause;
	}
	public void continueGame(){
		Time.timeScale = 1;
		gameState = GameState.Running;
	}

}
