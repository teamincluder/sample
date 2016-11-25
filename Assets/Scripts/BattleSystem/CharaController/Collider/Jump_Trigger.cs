using UnityEngine;
using System.Collections;

public class Jump_Trigger : MonoBehaviour {
	private const string GROUND_TAG	= "Ground";
	private bool isground = true;
	public bool is_Ground {
		get{
			return isground;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == GROUND_TAG)
			isground = true;
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == GROUND_TAG)
			isground = true;
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == GROUND_TAG)
			isground = false;
	}
}
