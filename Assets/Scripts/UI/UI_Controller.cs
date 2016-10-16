using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BackGround_Controller))]

public class UI_Controller : MonoBehaviour {
	BackGround_Controller bg;

	void Start () {
		bg = this.GetComponent<BackGround_Controller> ();
	}

	public void init(){
		titleScene ();
	}

	void titleScene(){
		bg.changeBg ("BG_01");
	}

	void menuScene(){
		bg.changeBg ("BG_02");
	}

	void battleScene(){
	}

}