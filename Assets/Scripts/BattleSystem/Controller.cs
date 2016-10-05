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
			Move_Func ();
			Jab_Func();
			Strong_Func();
			Jump_Func();
			Guard_Func();
		}
	}

	void Move_Func(){
		Vector3	vec	= Vector3.zero;
		if (Input.GetKey (RightKey) && Input.GetKey (LeftKey) && isGround)
			return;
		if(Input.GetKey(RightKey)){
			vec.x = 0.02f;				
			this.transform.localScale = new Vector3(1,1,1);
		}
		if(Input.GetKey(LeftKey)){
			vec.x = -0.02f;
			this.transform.localScale = new Vector3(-1,1,1);
		}
		vec += this.transform.position;
		this.transform.position = vec;
	}
	void Jab_Func(){
		if (Input.GetKeyDown (JabKey))
			Debug.Log ("弱攻撃！");
	}
	void Strong_Func(){
		if (Input.GetKeyDown (StrongKey))
			Debug.Log ("強攻撃！");
	}
	void Jump_Func(){
		if (Input.GetKeyDown (JumpKey) && isGround) {
			rb.AddForce (new Vector2 (0, 5f), ForceMode2D.Impulse);
			isGround=false;
		}
	}
	void Guard_Func(){
		if (Input.GetKeyDown (GuardKey))
			Debug.Log ("ガード！");
	}
	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Ground") {
			isGround = true;
		}
	}
}
