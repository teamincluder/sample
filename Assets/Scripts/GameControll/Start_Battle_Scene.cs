using UnityEngine;
using System.Collections;

public class Start_Battle_Scene : Scene_Interface {
	public Start_Battle_Scene(Scene_Controll_Interface state):base(state){
	}
	private bool count = false;
	public override void start (){
		Battle_UI_Controller.get_Instance.startBattleScene ();
		Controll_InterFace.get_Instance.isMain (false);
	}

	public override void update(){
	}

	public override void nextScene (){
		this.state.changeState (new Main_Battle_Scene(this.state));
	}

	public override void onClick (){
		if (count)
			nextScene ();
		else
			count=true;
	}

}
