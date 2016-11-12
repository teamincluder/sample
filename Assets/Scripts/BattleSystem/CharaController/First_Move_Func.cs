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
	private bool isground	=	false;
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
		Debug.Log ("ガード！");
	}

	public override void jabMove(){
		Debug.Log ("jab");
		HP_Controller.getInstance.firstJab ();
	}

	public override void strongMove(){
		Debug.Log ("strong");
		HP_Controller.getInstance.firstStrong ();
	}

	public override void deathBlowMove(){
		Debug.Log ("death");
		HP_Controller.getInstance.firstDeathBlow ();
	}

}

