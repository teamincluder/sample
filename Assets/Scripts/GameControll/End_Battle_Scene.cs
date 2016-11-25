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
		if (this.state.countDown ()) {
			this.state.changeState (new Title_Scene (this.state), "Menu");
			Battle_Win.get_Instance.exit ();
		}
		else
			this.state.changeState (new Start_Battle_Scene(this.state),"Battle");
	}

	public override void onClick (){
		if (count)
			nextScene ();
		else
			count=true;
	}
}
