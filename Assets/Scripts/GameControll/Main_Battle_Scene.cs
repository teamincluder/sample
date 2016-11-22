using UnityEngine;
using System;

public class Main_Battle_Scene : Scene_Interface{
	public Main_Battle_Scene (Scene_Controll_Interface state):base(state){
	}
	public override void start (){
		Battle_UI_Controller.get_Instance.mainBattleScene ();
		Controll_InterFace.get_Instance.isMain (true);
	}

	public override void update ()
	{
		if (End_Battle_Checker.get_Instance.isEnd) {
			End_Battle_Checker.get_Instance.exit ();
			nextScene ();
		}
	}


	public override void nextScene (){
		this.state.changeState (new End_Battle_Scene(this.state));
		/*
			End_Battle_Checkerに持たせてる
		*/
	}

	public override void onClick (){
	}
		
}

