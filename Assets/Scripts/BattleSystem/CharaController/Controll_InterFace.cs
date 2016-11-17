using UnityEngine;
using System.Collections;

public class Controll_InterFace : MonoBehaviour {
	
	private static Controll_InterFace instance;

	private const string FIRST_KEY_CONTROLLER	=	"1P";
	private const string SECOND_KEY_CONTROLLER	=	"2P";


	private Key_Controll 	first;
	private Key_Controll 	second;
	private AI_Controller	ai;

	private bool pvp	=	false;

	public static Controll_InterFace get_Instance{
		get{
			return instance;
		}
	}

	void Awake () {

		if (instance == null)
			instance	=	this;
		else
			Destroy (this.gameObject);
		GameObject 	firstObj	= 	GameObject.Find (FIRST_KEY_CONTROLLER);
		firstObj.tag 			=	TagList.getInstance.firstTag;
		first					=	firstObj.GetComponent<Key_Controll> ();
		GameObject	secondObj	=	GameObject.Find (SECOND_KEY_CONTROLLER);
		secondObj.tag 			=	TagList.getInstance.secondTag;
		if (pvp) {
			second	=	secondObj.AddComponent<Key_Controll> ();
			second.set_user (false);
		} 
		else {
			ai 		=	secondObj.AddComponent<AI_Controller> ();
		}
	}

	public void isMain(bool ismain){
		first.set_IsMain		=	ismain;
		if (pvp)
			second.set_IsMain	= 	ismain;
		else
			ai.set_isMain		=	ismain;
	}

}
