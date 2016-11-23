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
		this.transform.localScale = RIGHT_MOVE;	
		vec += this.transform.position;
		this.transform.position = vec;
	}

	public override void leftMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = -SPEED;				
		this.transform.localScale = LEFT_MOVE;
		vec += this.transform.position;
		this.transform.position = vec;
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
		Audio_Controller.get_Instance.firstJab ();
		HP_Controller.getInstance.firstJab (triggers.jab_Guard);
	}

	public override void strongMove(){
		Audio_Controller.get_Instance.firstStrong ();
		HP_Controller.getInstance.firstStrong (triggers.strong_Guard);
	}

	public override void deathBlowMove(){
		HP_Controller.getInstance.firstDeathBlow (triggers.deathblow_Guard);
	}

}

