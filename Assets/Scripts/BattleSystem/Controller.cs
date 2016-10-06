using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	/*Key Settings*/
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
	/* Charactor RigidBody */
	[SerializeField]
	Rigidbody2D rb		= new Rigidbody2D();
	/* is Ground */
	bool isGround	= false;
	[SerializeField]
	AnimController Anim;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (RightKey)) {
			Right_Move_Func();
		}
		if (Input.GetKey (LeftKey)) {
			Left_Move_Func();
		}
		if (Input.GetKeyDown (UpKey)) {
			Jump_Func();
		}
		if (Input.GetKey (DownKey)) {
		}
		if (Input.GetKeyDown (JabKey)) {
			Jab_Func();
		}
		if (Input.GetKeyDown (StrongKey)) {
			Strong_Func();
		}
		if (Input.GetKeyDown (GuardKey)) {
			Guard_Func();
		}
		if (Input.GetKeyDown (JumpKey)) {
			Jump_Func();
		}
	}
	void Right_Move_Func(){
		Vector3	vec	= Vector3.zero;
		vec.x = 0.02f;				
		this.transform.localScale = new Vector3 (0.3f, 0.3f, 1);
		vec += this.transform.position;
		this.transform.position = vec;
		if(isGround)
			StartCoroutine(Anim.Move ());
	}
	void Left_Move_Func(){
		Vector3	vec	= Vector3.zero;
		vec.x = -0.02f;				
		this.transform.localScale = new Vector3 (-0.3f, 0.3f, 1);
		vec += this.transform.position;
		this.transform.position = vec;
		if(isGround)
			StartCoroutine(Anim.Move ());
	}
	void Down_Move_Func(){
	}
	void Jab_Func(){
		Debug.Log ("弱攻撃！");
	}
	void Strong_Func(){
		Debug.Log ("強攻撃！");
	}
	void Jump_Func(){
		if (!isGround)
			return;
		rb.AddForce (new Vector2 (0, 3f), ForceMode2D.Impulse);
		isGround=false;
	}
	void Guard_Func(){
		Debug.Log ("ガード！");
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
