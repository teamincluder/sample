using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (AnimController))]
public class Move_Func : MonoBehaviour {

	bool isground = false;
	AnimController anim;
	Rigidbody2D rb;

	public void init(){
		anim	=	this.GetComponent<AnimController> ();
		rb 		=	this.GetComponent<Rigidbody2D>();
	}

	public void rightMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = 0.02f;				
		this.transform.localScale = new Vector3 (0.3f, 0.3f, 1);	
		vec += this.transform.position;
		this.transform.position = vec;
	}

	public void leftMove(){
		Vector3	vec	= Vector3.zero;
		vec.x = -0.02f;				
		this.transform.localScale = new Vector3 (-0.3f, 0.3f, 1);
		vec += this.transform.position;
		this.transform.position = vec;
	}

	public void downMove(){
		Debug.Log ("しゃがむ");
	}

	public void jumpMove(){
		return;
		if (!isground)
			return;
		rb.AddForce (new Vector2 (0, 3f), ForceMode2D.Impulse);
		isground=false;
	}

	public void guardMove(){
		Debug.Log ("ガード！");
	}

	public void deathBlowMove(){
		Debug.Log ("必殺技！！！！！");
	}

	public void jabMove(){
		Debug.Log ("弱攻撃！");
	}

	public void strongMove(){
		Debug.Log ("強攻撃！");
	}
		
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Ground") {
			isground = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground") {
			isground = false;
		}
	}
}
