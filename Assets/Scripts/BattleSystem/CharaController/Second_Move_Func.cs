﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
/*
	キャラコントローラーAPI部
	Animや剛体拾って動きを付ける部分
	実装部はKey_Controller
*/
public class Second_Move_Func : Move_Func_InterFace {
	Unit unit = new Unit();
	Rigidbody2D rb;
	Guard_Controller gc;
	Trigger_Interface triggers;

	private void Awake(){
		rb 	=	this.GetComponent<Rigidbody2D>();
		gc	=	this.gameObject.transform
					.FindChild (GUARD_PATH).gameObject
					.AddComponent<Guard_Controller> ();
		gc.init (false);
		triggers = this.GetComponent<Trigger_Interface> ();
	}
	public override void rightMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = SPEED;				
		this.transform.localScale = SECOND_RIGHT_MOVE;	
		vec += this.transform.position;
		this.transform.position = vec;
	}

	public override void leftMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = -SPEED;				
		this.transform.localScale = SECOND_LEFT_MOVE;
		vec += this.transform.position;
		this.transform.position = vec;
	}


	public override void stopLeftMove ()
	{
	}

	public override void stopRightMove ()
	{
	}

	public override void downMove(){
		Debug.Log ("しゃがむ");
	}

	public override void jumpMove(){
		rb.AddForce (JUMP_MOVE, ForceMode2D.Impulse);
	}

	public override void guardMove(){
		gc.isVisible (true);
	}
	public override void noguardMove(){
		gc.isVisible (false);
	}

	public override void jabMove(){
		HP_Controller.getInstance.secondJab (triggers.jab_Guard);
	}

	public override void strongMove(){
		HP_Controller.getInstance.secondStrong (triggers.strong_Guard);
	}

	public override void deathBlowMove(){
		HP_Controller.getInstance.secondDeathBlow (triggers.deathblow_Guard);
	}
}
