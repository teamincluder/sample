﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Battle_Font))]
[RequireComponent(typeof(Battle_Timer))]
public class Battle_UI_Controller : MonoBehaviour {

	/*テキストメッセージ*/
	private	const	string	START_MESSAGE 	=	"Click Start!";

	/*バトル時間*/
	private int	BATTLE_TIME = 60;

	private Battle_Font		battlefont;
	private Battle_Timer	battletimer;

	private static Battle_UI_Controller instance;
	public static Battle_UI_Controller get_Instance{
		get{
			return instance;
		}
	}

	private void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
		if(battlefont	== null)	battlefont	=	this.GetComponent<Battle_Font> ();
		if(battletimer	== null)	battletimer	=	this.GetComponent<Battle_Timer> ();
	}

	public void startBattleScene(){
		battlefont.isVisible (false);
		battletimer.setTime (BATTLE_TIME);
		battletimer.isMain (false);
		Battle_Win.get_Instance.init ();
	}
	public void mainBattleScene(){
		battletimer.isMain (true);
	}
	public void endBattleScene(bool result){
		battlefont.isVisible (true);
		battlefont.setMessage (result);
		battletimer.isMain (false);
	}
}
