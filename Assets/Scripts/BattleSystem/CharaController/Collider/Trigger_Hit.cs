using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider2D))]
public class Trigger_Hit : MonoBehaviour {
	private bool ishit 		= 	false;
	private bool ishitguard	=	false;
	private int usernumber	= 	0;
	public 	int user_Number{
		set{
			usernumber = value;
		}
	}

	public bool is_Hit{
		get{
			return ishit;
		}
	}

	public bool is_Guard{
		get{
			return ishitguard;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other){
		if (checkHitTag(other.tag))
			ishit = true;
		if (checkHitGuardTag (other.tag))
			ishitguard = true;
	}
	void OnTriggerStay2D(Collider2D other){
		if (checkHitTag(other.tag))
			ishit = true;
		if (checkHitGuardTag (other.tag))
			ishitguard = true;
		else
			ishitguard = false;
	}
	void OnTriggerExit2D(Collider2D other){
		if (checkHitTag(other.tag))
			ishit = false;
		if (checkHitGuardTag (other.tag))
			ishitguard = false;
	}

	private bool checkHitTag(string other){
		bool result = false;
		switch (usernumber) 
		{
		case 1:
			if (other == TagList.getInstance.secondTag)
				result = true;
			break;
		case 2:
			if (other == TagList.getInstance.firstTag)
				result = true;
			break;
		}
		return result;
	}

	private bool checkHitGuardTag(string other){
		bool result = false;
		switch (usernumber) 
		{
		case 1:
			if (other == TagList.getInstance.secondGuardTag)
				result = true;
			break;
		case 2:
			if (other == TagList.getInstance.firstGuardTag)
				result = true;
			break;
		}
		return result;
	}
}
