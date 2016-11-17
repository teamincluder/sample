using UnityEngine;
using System;

public class Main_Battle_Scene : Scene_Interface{
	public Main_Battle_Scene (App_Controller manager):base(manager){
	}
	public override void start (){
		Battle_UI_Controller.getInstance.mainBattleScene ();
		Controll_InterFace.get_Instance.isMain (true);
	}

	public override void nextScene (){
		this.manager.nextScene (new Main_Battle_Scene (this.manager));
	}

	public override void onClick (){
	}
		
}

