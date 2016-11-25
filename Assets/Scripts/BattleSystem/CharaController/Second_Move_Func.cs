using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
/*
	キャラコントローラーAPI部
	Animや剛体拾って動きを付ける部分
	実装部はKey_Controller
*/
public class Second_Move_Func : Move_Func_InterFace {
	Rigidbody2D rb;
	Guard_Controller gc;
	Jump_Trigger	 jt;
	Trigger_Interface triggers;

	private void Awake(){
		rb 	=	this.GetComponent<Rigidbody2D>();
		gc	=	this.gameObject.transform
					.FindChild (GUARD_PATH).gameObject
					.AddComponent<Guard_Controller> ();
		gc.init (false);
		jt			=	this.gameObject.transform
							.FindChild (JUMP_PATH).gameObject
							.AddComponent<Jump_Trigger> ();
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

	public override void startLeftMove ()
	{
		Animation_Manager.get_Instance.second.run ();
	}
	public override void startRightMove ()
	{
		Animation_Manager.get_Instance.second.run ();
	}

	public override void stopLeftMove ()
	{
		Animation_Manager.get_Instance.second.stopRun();
	}

	public override void stopRightMove ()
	{
		Animation_Manager.get_Instance.second.stopRun();
	}

	public override void downMove(){
		Debug.Log ("しゃがむ");
	}

	public override void jumpMove(){
		if(jt.is_Ground)
			rb.AddForce (JUMP_MOVE, ForceMode2D.Impulse);
	}

	public override void guardMove(){
		gc.isVisible (true);
		Animation_Manager.get_Instance.second.guard ();
	}
	public override void noguardMove(){
		gc.isVisible (false);
		Animation_Manager.get_Instance.second.stopGuard ();
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
