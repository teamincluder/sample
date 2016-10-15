using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (AnimController))]

public class KeyController : MonoBehaviour {
	KeyList PlayerKey = new KeyList();
	bool isGround	= false;
	AnimController Anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		PlayerKey.Init (true);
		Anim			=	this.GetComponent<AnimController> ();
		rb 				=	this.GetComponent<Rigidbody2D>();

		var Jab			=	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(PlayerKey.JabKey))
								.Subscribe (_=>Jab_Func());
	
		var DeathBlow 	= 	this.UpdateAsObservable ()
								.Where (_ => Input.GetKey (PlayerKey.JabKey))
								.Sample(System.TimeSpan.FromSeconds(0.5f))
								.Where (_ => Input.GetKeyDown (PlayerKey.StrongKey))
								.Subscribe (_=>Death_Blow_Func());

		var DeathBomber	= 	this.UpdateAsObservable ()
								.Where (_ => Input.GetKey (PlayerKey.StrongKey))
								.Sample(System.TimeSpan.FromSeconds(0.5f))
								.Where (_ => Input.GetKeyDown (PlayerKey.JabKey))
								.Subscribe (_=>Death_Blow_Func());

		var Strong	 	= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(PlayerKey.StrongKey))
								.Subscribe (_=>Strong_Func());

		var Jump		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(PlayerKey.JumpKey))
								.Subscribe (_=>Jump_Func());

		var Guard 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(PlayerKey.GuardKey))
								.Subscribe (_=>Guard_Func());

		var Left 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKey(PlayerKey.LeftKey))
								.Subscribe (_=>Left_Move_Func());

		var Right		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKey(PlayerKey.RightKey))
								.Subscribe (_=>Right_Move_Func());

		var Up			= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(PlayerKey.UpKey))
								.Subscribe (_=>Jump_Func());

		var Down 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(PlayerKey.DownKey))
								.Subscribe (_=>Down_Move_Func());
	}

	void Right_Move_Func(){
		Vector3	vec	= Vector3.zero;
		vec.x = 0.02f;				
		this.transform.localScale = new Vector3 (0.3f, 0.3f, 1);	
		vec += this.transform.position;
		this.transform.position = vec;
		Anim.Move ();
	}

	void Left_Move_Func(){
		Vector3	vec	= Vector3.zero;
		vec.x = -0.02f;				
		this.transform.localScale = new Vector3 (-0.3f, 0.3f, 1);
		vec += this.transform.position;
		this.transform.position = vec;
		Anim.Move ();
	}

	void Down_Move_Func(){
	}
	
	void Jump_Func(){
		return;
		if (!isGround)
			return;
		rb.AddForce (new Vector2 (0, 3f), ForceMode2D.Impulse);
		isGround=false;
	}

	void Guard_Func(){
		Debug.Log ("ガード！");
	}

	void Death_Blow_Func(){
		Debug.Log ("必殺技！！！！！");
	}

	void Jab_Func(){
		Debug.Log ("弱攻撃！");
	}

	void Strong_Func(){
		Debug.Log ("強攻撃！");
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Ground") {
			isGround = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground") {
			isGround = false;
		}
	}
}
