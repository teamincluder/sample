using UnityEngine;
public class Menu_Scene : Scene_Interface {
	public Menu_Scene (Scene_Controll_Interface state):base(state){
	}

	public override void start (){
		Menu_UI_Controller.get_Instance.menuScene ();
	}


	public override void update ()
	{
		First_Key_List first = new First_Key_List ();
		if (Input.GetKeyDown (first.jab_Key)) {
			nextScene ();
		}
	}

	public override void nextScene (){
		Button_State buttonstate = Button_State.get_Instance;
		if (buttonstate.checkStory ()) {
			Debug.Log ("Story");
		} 
		else if (buttonstate.checkBattle ()) {
			this.state.changeState (new Start_Battle_Scene(this.state),"Battle");
		}
		else if (buttonstate.checkOption ()) {
			Debug.Log ("option");
		}
		buttonstate.exit ();
	}

	public override void onClick (){
	}
}