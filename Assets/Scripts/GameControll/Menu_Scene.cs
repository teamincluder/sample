using UnityEngine;
public class Menu_Scene : Scene_Interface {

	public Menu_Scene(App_Controller manager):base(manager){
	}

	public override void start (){
		Menu_UI_Controller.getInstance.menuScene ();
	}
	
	public override void nextScene (){
		this.manager.nextScene (new Battle_Scene(this.manager),"Battle");
	}

	public override void onClick (){
	}
}