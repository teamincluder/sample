using UnityEngine;

public class Main_State : State_Interface {

	public Main_State(State_Manager manager):base(manager){
	}
	public override void start ()
	{
		Battle_UI_Controller.getInstance.mainBattleScene ();
		this.manager.first_Manager.set_isMain	= true;
		this.manager.second_Manager.set_isMain	= true;
	}

	public override void update ()
	{
		
	}

	public override void nextState ()
	{
	}

	public override void onClick ()
	{
	}

}
