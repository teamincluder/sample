using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	[SerializeField]
	KeyCode LeftKey 	= new KeyCode();
	[SerializeField]
	KeyCode UpKey		= new KeyCode();
	[SerializeField]
	KeyCode DownKey 	= new KeyCode();
	[SerializeField]
	KeyCode RightKey	= new KeyCode();
	[SerializeField]
	KeyCode JabKey 		= new KeyCode();
	[SerializeField]
	KeyCode GuardKey	= new KeyCode();
	[SerializeField]
	KeyCode JumpKey 	= new KeyCode();
	[SerializeField]
	KeyCode StrongKey	= new KeyCode();
	[SerializeField]
	Rigidbody2D rb		= new Rigidbody2D();
	bool	isGround	= false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			move_Func ();
			jab_Func();
			strong_Func();
			jump_Func();
			guard_Func();
		}
	}

	void move_Func(){
		Vector3	vec	=	new Vector3();
		if(Input.GetKey(RightKey)){
			vec.x=0.02f;				
			this.transform.localScale=new Vector3(1,1,1);
		}
		if(Input.GetKey(LeftKey)){
			vec.x=-0.02f;
			this.transform.localScale=new Vector3(-1,1,1);
		}
		vec += this.transform.position;
		this.transform.position = vec;
	}
	void jab_Func(){
		if (Input.GetKeyDown (JabKey))
			Debug.Log ("弱攻撃！");
	}
	void strong_Func(){
		if (Input.GetKeyDown (StrongKey))
			Debug.Log ("強攻撃！");
	}
	void jump_Func(){
		if(Input.GetKeyDown(JumpKey))
			rb.AddForce (new Vector2(0,5f),ForceMode2D.Impulse);
	}
	void guard_Func(){
		if (Input.GetKeyDown (GuardKey))
			Debug.Log ("ガード！");
	}


}
