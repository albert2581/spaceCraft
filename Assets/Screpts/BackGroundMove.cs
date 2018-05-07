using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour {

	public float BackGroundMoveSpeed = 4f;
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.down * BackGroundMoveSpeed * Time.deltaTime);//往下移動背景
		Vector3 position = this.transform.position;//取得當前座標
		if (position.y <= -8.52f) {
			this.transform.position = new Vector3 (position.x,position.y+8.52f*2,position.z);//背景反覆跳回原位
		}
	}
}
