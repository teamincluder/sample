using UnityEngine;
using System.Collections;

public class End_Battle_Scene : Scene_Interface {
	public End_Battle_Scene (Scene_Controll_Interface state):base(state){
	}
	private string 	result 	= 	null;
	private bool count		=	false;


	public override void start (){
		Battle_UI_Controller.get_Instance.endBattleScene (result);
		Controll_InterFace.get_Instance.isMain (false);
	}

	public override void update (){
	}

	public override void nextScene (){
		this.state.changeState (new Menu_Scene(this.state),"Menu");
	}

	public override void onClick (){
		if (count)
			nextScene ();
		else
			count=true;
	}
}
