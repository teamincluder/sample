using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3	vec	=	new Vector3();
		if(Input.GetKey("right")){
				vec.x=0.01f;				
				this.transform.localScale=new Vector3(1,1,1);
		}
		if(Input.GetKey("left")){
				vec.x=-0.01f;
				this.transform.localScale=new Vector3(-1,1,1);
		}
		if(Input.GetKey("up"))
				vec.y=0.05f;
		this.transform.position	+=vec;
	}
}
