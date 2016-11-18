using UnityEngine;
using System.Collections;

public class End_Battle_Scene : Scene_Interface {
	private string 	result 	= 	null;
	private bool count		=	false;
	public End_Battle_Scene(App_Controller manager):base(manager){
	}

	public override void start (){
		Battle_UI_Controller.getInstance.endBattleScene (result);
		Controll_InterFace.get_Instance.isMain (false);
	}

	public override void nextScene (){
		this.manager.nextScene (new Menu_Scene (this.manager), "Menu");
	}

	public override void onClick (){
		if (count)
			nextScene ();
		else
			count=true;
	}
}
