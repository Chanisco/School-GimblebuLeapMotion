﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(-5 * Time.deltaTime	,0,0);
		}else if(Input.GetKey(KeyCode.D)){
			transform.Translate(5  * Time.deltaTime,0,0);
		}
	}
}
