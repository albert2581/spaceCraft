using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public GameObject Enemy0Prefab;
	public float Enemy0Rate =0.5f;
	public GameObject Enemy1Prefab;
	public float Enemy1Rate =0.5f;
	public GameObject Enemy2Prefab;
	public float Enemy2Rate =0.5f;

	public GameObject Award0Prefab;
	public float Award0Rate =0.5f;
	public GameObject Award1Prefab;
	public float Award1Rate =0.5f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("createEnemy0",1,Enemy0Rate);
		InvokeRepeating ("createEnemy1",5,Enemy1Rate);
		InvokeRepeating ("createEnemy2",10,Enemy2Rate);
		InvokeRepeating ("createAward0",10,Award0Rate);
		InvokeRepeating ("createAward1",20,Award1Rate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void createEnemy0(){
		float x = Random.Range(-2.0f,2.0f);
		GameObject.Instantiate (Enemy0Prefab,new Vector3( x,transform.position.y,0),Quaternion.identity);
	}
	public void createEnemy1(){
		float x = Random.Range(-1.88f,1.9f);
		GameObject.Instantiate (Enemy1Prefab,new Vector3( x,transform.position.y,0),Quaternion.identity);
	}
	public void createEnemy2(){
		float x = Random.Range(-1.3f,1.35f);
		GameObject.Instantiate (Enemy2Prefab,new Vector3( x,transform.position.y,0),Quaternion.identity);
	}
	public void createAward0(){
		float x = Random.Range(-2.15f,2.15f);
		GameObject.Instantiate (Award0Prefab,new Vector3( x,transform.position.y,0),Quaternion.identity);
	}
	public void createAward1(){
		float x = Random.Range(-2.15f,2.15f);
		GameObject.Instantiate (Award1Prefab,new Vector3( x,transform.position.y,0),Quaternion.identity);
	}
}
