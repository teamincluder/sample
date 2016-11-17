using UnityEngine;
public class Menu_Scene : Scene_Interface {

	public Menu_Scene(App_Controller manager):base(manager){
	}

	public override void start (){
		Menu_UI_Controller.getInstance.menuScene ();
	}
	
	public override void nextScene (){
		/*
		 	分岐だるかったのでとりあえずMenu_Buttonに持たせてます
		*/
	}

	public override void onClick (){
		/*
			同上
		*/
	}
}