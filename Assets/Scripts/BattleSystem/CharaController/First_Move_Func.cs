using UnityEngine;
using System.Collections;
/*
	キャラコントローラーAPI部
	1P専用
	Animや剛体拾って動きを付ける部分
	実装部はKey_Controller
*/
public class First_Move_Func :Move_Func_InterFace {
	Rigidbody2D	rb;
	Guard_Controller gc;
	Trigger_Interface triggers;
	private bool isground	=	false;
	private void Awake(){
		rb 			=	this.GetComponent<Rigidbody2D>();
		gc			=	this.gameObject.transform
							.FindChild (GUARD_PATH).gameObject
							.AddComponent<Guard_Controller> ();
		gc.init (true);
		triggers 	=	this.GetComponent<Trigger_Interface> (); 
		
	}

	public override void rightMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = SPEED;				
		this.transform.localScale = FIRST_RIGHT_MOVE;	
		vec += this.transform.position;
		this.transform.position = vec;
		Animation_Manager.get_Instance.first.run ();
	}

	public override void leftMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = -SPEED;				
		this.transform.localScale = FIRST_LEFT_MOVE;
		vec += this.transform.position;
		this.transform.position = vec;
		Animation_Manager.get_Instance.first.run ();
	}


	public override void stopLeftMove ()
	{
		Animation_Manager.get_Instance.first.stopRun ();
	}

	public override void stopRightMove ()
	{
		Animation_Manager.get_Instance.first.stopRun ();
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
		Animation_Manager.get_Instance.first.jab ();
		Audio_Manager.get_Instance.first_Audio.jab ();
		HP_Controller.getInstance.firstJab (triggers.jab_Guard);
	}

	public override void strongMove(){
		Animation_Manager.get_Instance.first.strong ();
		Audio_Manager.get_Instance.first_Audio.strong ();
		HP_Controller.getInstance.firstStrong (triggers.strong_Guard);
	}

	public override void deathBlowMove(){
		HP_Controller.getInstance.firstDeathBlow (triggers.deathblow_Guard);
	}

}

