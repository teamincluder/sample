using UnityEngine;
public class Start_State : State_Interface {
	public Start_State(State_Manager manager):base(manager){
	}

	public override void start ()
	{
		UI_Controller.getInstance.startBattleScene ();
	}
	public override void update ()
	{
	}
	public override void nextState ()
	{
		this.manager.nextState (new Main_State(this.manager));
	}

	public override void onClick ()
	{
		nextState ();
	}
}