using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour {

	public void OnStartGame(string ScnenceName)
	{
		SceneManager.LoadScene(ScnenceName); //讀取場景,場景名稱
	}
}
