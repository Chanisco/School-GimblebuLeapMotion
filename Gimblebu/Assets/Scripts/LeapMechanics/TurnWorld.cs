﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class TurnWorld : MonoBehaviour {
	Color green 		= new Color(0,10,0);
	Color blue 			= new Color(0,0,10);
	Color red 			= new Color(10,0,0);
	Color yellow 		= new Color(10,10,0);
	Color lightBlue		= new Color(0,10,10);
	Color origin;

	float canTurn 		= 0;
	float colorChoice 	= 0;

	int turnNr		= 0;

	bool nextTurn 		= false;
	bool routinStart 	= true;

	void Awake(){
		origin = renderer.material.color;
	}

	public void Turning (Controller ctrl) {
		Frame frame = ctrl.Frame();

		HandList h = frame.Hands;
		
		foreach(Hand hand in h)
		{
			Frame nowFrame = ctrl.Frame();
			float roll = nowFrame.Hands[0].PalmNormal.Roll;
			float rollRound = Mathf.Round(roll * 10);

			if(rollRound < -20){
				if(routinStart){
					routinStart = false;
					colorChoice = 2;
					StartCoroutine("CheckforTurns");
				}

			}else{
				StopCoroutine("CheckforTurns");
				routinStart = true;
				canTurn = 0;
				colorChoice = 1;
				if(nextTurn){
					if(Global.turnWorld != 3){
						Debug.Log("World is turning = " + Global.turnWorld + turnNr);
						Global.turnWorld += turnNr;
					}else if(Global.turnWorld == 3){
						Global.turnWorld = 0;
					}
					nextTurn = false;
				}
			}
		}
	}

	IEnumerator CheckforTurns(){
		int End 	= 3;
		int canTurn = 0;
		turnNr		= 0;
		while(canTurn != End && !routinStart){
			//Debug.Log("Nr turn = "+ canTurn);
			float isTurnPos = turnNr += Global.turnWorld;
			Debug.Log("kan ik turnen? = " + turnNr);

			canTurn += 1;
			yield return new WaitForSeconds(1);
			if(canTurn == End){
				if(isTurnPos != 3){
					nextTurn = true;
					turnNr += 1;
					End += 3;
					colorChoice += 1;
				}else{
					colorChoice = 2;
					//turnNr = 0;
					Debug.Log("back to one");
				}
			}
		}
	}

	void Update(){
		if(colorChoice == 1){
			renderer.material.color = blue;
		}
		if(colorChoice == 2){
			renderer.material.color = green;
		}
		if(colorChoice == 3){
			renderer.material.color = red;
		}
		if(colorChoice == 4){
			renderer.material.color = yellow;
		}
		if(colorChoice == 5){
			renderer.material.color = lightBlue;
		}
	}
}
