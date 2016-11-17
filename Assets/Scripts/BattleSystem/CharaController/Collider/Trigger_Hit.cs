using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class Trigger_Hit : MonoBehaviour {
	private bool ishit = false;
	private int usernumber = 0;
	public int user_Number{
		set{
			usernumber = value;
		}
	}

	public bool is_Hit{
		get{
			return ishit;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other){
		if (checkTag(other.tag))
			ishit = true;
	}
	void OnTriggerStay2D(Collider2D other){
		if (checkTag(other.tag))
			ishit = true;
	}
	void OnTriggerExit2D(Collider2D other){
		if (checkTag(other.tag))
			ishit = false;
	}

	private bool checkTag(string other){
		bool result = false;
		switch (usernumber) 
		{
		case 1:
			if (other == TagList.getInstance.secondTag)
				result = true;
			break;
		case 2:
			if (other == TagList.getInstance.firstTag)
				result =true;
			break;
		}
		return result;
	}
}
