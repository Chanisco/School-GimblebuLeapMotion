﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class MouseMove : MonoBehaviour {
	public GameObject Player;

	public void Mouse(Controller ctrl) {
		float sideFieldMinX = 	-10f 	;//- Player.transform.position.x;
		float sideFieldMaxX = 	170f 	;//+ Player.transform.position.x;
		float sideFieldMinY = 	-15f 	;//- Player.transform.position.y;
		float sideFieldMaxY = 	15f 	;//+ Player.transform.position.y;
		
		
		float MovementY;
		float MovementX;

		
		Frame frame = ctrl.Frame();
		HandList h = frame.Hands;

		foreach(Hand hand in h){
			if(frame.Hands.Count > 1){
				Debug.Log("PLZ 1 hand");
			}
			MovementY = hand.PalmPosition.y;
			MovementX = hand.PalmPosition.x;
			
			if(hand.PalmPosition.z < 0 && !Global.fist){
				if(Global.turnWorld == 0){
					Vector3 MovPosition = new Vector3(MovementX / 50 ,MovementY / 150,0);
					transform.Translate(0,-1,0);
					transform.Translate(MovPosition);
				}
				
				if(Global.turnWorld == 1){
					Vector3 MovPosition = new Vector3(-MovementY / 150,MovementX / 50,0);
					transform.Translate(1,0,0);
					transform.Translate(MovPosition);
				}
				
				if(Global.turnWorld == 2){
					Vector3 MovPosition = new Vector3(-MovementX / 50,-MovementY / 150,0);
					transform.Translate(0,1,0);
					transform.Translate(MovPosition);
				}
				
				if(Global.turnWorld == 3){
					Vector3 MovPosition = new Vector3(MovementY / 150,-MovementX / 50,0);
					transform.Translate(-1,0,0);
					transform.Translate(MovPosition);
				}
				
			}
			
		}
		
		if(transform.position.x < sideFieldMinX){
			transform.position = new Vector3(sideFieldMinX,transform.position.y,0);
		}
		if(transform.position.x > sideFieldMaxX){
			transform.position = new Vector3(sideFieldMaxX,transform.position.y,0);
		}
		
		if(transform.position.y < sideFieldMinY){
			transform.position = new Vector3(transform.position.x,sideFieldMinY,0);
		}
		if(transform.position.y > sideFieldMaxY){
			transform.position = new Vector3(transform.position.x,sideFieldMaxY,0);
		}
	}
}
