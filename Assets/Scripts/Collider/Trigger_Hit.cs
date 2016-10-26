using UnityEngine;
using System.Collections;

public class Trigger_Hit : MonoBehaviour {
	private bool ishit = false;
	public bool is_Hit{
		get{
			return ishit;
		}
	}
	void OnTriggerStay2D(Collider2D collider){
		if (collider.tag == "Player")
			ishit = true;
	}
	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player")
			ishit = false;
	}
}
