using UnityEngine;
using System.Collections;

public class Start_Battle_Scene : Scene_Interface {

	public Start_Battle_Scene(App_Controller manager):base(manager){
	}

	public override void start (){
		Battle_UI_Controller.getInstance.startBattleScene ();
		Controll_InterFace.get_Instance.isMain (false);
	}

	public override void nextScene (){
		this.manager.nextScene (new Main_Battle_Scene(this.manager));
	}

	public override void onClick (){
		nextScene ();
	}

}
