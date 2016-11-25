using UnityEngine;
using System.Collections;
/*
	キャラコントローラーAPI部
	1P専用
	Animや剛体拾って動きを付ける部分
	実装部はKey_Controller
*/
public class First_Move_Func :Move_Func_InterFace {
	Rigidbody2D			rb;
	Guard_Controller	gc;
	Jump_Trigger		jt;
	Trigger_Interface triggers;
	private void Awake(){
		rb 			=	this.GetComponent<Rigidbody2D>();
		gc			=	this.gameObject.transform
							.FindChild (GUARD_PATH).gameObject
							.AddComponent<Guard_Controller> ();
		gc.init (true);
		jt			=	this.gameObject.transform
							.FindChild (JUMP_PATH).gameObject
							.AddComponent<Jump_Trigger> ();
		triggers 	=	this.GetComponent<Trigger_Interface> (); 
	}

	public override void rightMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = SPEED;				
		this.transform.localScale = FIRST_RIGHT_MOVE;	
		vec += this.transform.position;
		this.transform.position = vec;
	}

	public override void leftMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = -SPEED;				
		this.transform.localScale = FIRST_LEFT_MOVE;
		vec += this.transform.position;
		this.transform.position = vec;
	}

	public override void startLeftMove ()
	{
		Animation_Manager.get_Instance.first.run ();
	}
	public override void startRightMove ()
	{
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
		if(jt.is_Ground)
			rb.AddForce (JUMP_MOVE, ForceMode2D.Impulse);
	}

	public override void guardMove(){
		gc.isVisible (true);
		Animation_Manager.get_Instance.first.guard ();
	}

	public override void noguardMove(){
		gc.isVisible (false);
		Animation_Manager.get_Instance.first.stopGuard ();
	}

	public override void jabMove(){
		if (triggers.jab_Hit)
			HP_Controller.getInstance.firstJab (triggers.jab_Guard);
		Animation_Manager.get_Instance.first.jab ();
		Audio_Manager.get_Instance.first_Audio.jab ();
	}

	public override void strongMove(){
		if(triggers.strong_Hit)
			HP_Controller.getInstance.firstStrong (triggers.strong_Guard);
		Animation_Manager.get_Instance.first.strong ();
		Audio_Manager.get_Instance.first_Audio.strong ();
	}

	public override void deathBlowMove(){
		HP_Controller.getInstance.firstDeathBlow (triggers.deathblow_Guard);
	}
}

