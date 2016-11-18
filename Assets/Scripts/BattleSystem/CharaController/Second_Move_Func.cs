using UnityEngine;
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

	private void Awake(){
		rb 	=	this.GetComponent<Rigidbody2D>();
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
		Debug.Log("ガード！");
		HP_Controller.getInstance.secondGuard ();
	}

	public override void jabMove(){
		HP_Controller.getInstance.secondJab ();
	}

	public override void strongMove(){
		HP_Controller.getInstance.secondStrong ();
	}

	public override void deathBlowMove(){
		HP_Controller.getInstance.secondDeathBlow ();
	}

}
