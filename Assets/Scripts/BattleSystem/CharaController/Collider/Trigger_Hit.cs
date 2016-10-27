using UnityEngine;
using System.Collections;

public class Trigger_Hit : MonoBehaviour {
	private bool ishit = false;
	private const string FIRST_TAG_NAME		= "first";
	private const string SECOND_TAG_NAME	= "second";
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

	public string first_Tag{
		get{
			return FIRST_TAG_NAME;
		}
	}

	public string second_Tag{
		get{
			return SECOND_TAG_NAME;
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
			if (other == SECOND_TAG_NAME)
				result = true;
			break;
		case 2:
			if (other == FIRST_TAG_NAME)
				result =true;
			break;
		}
		return result;
	}
}
