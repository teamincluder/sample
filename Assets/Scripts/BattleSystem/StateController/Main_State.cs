using UnityEngine;

public class Main_State : State_Interface {

	public Main_State(State_Manager manager):base(manager){
	}
	public override void start ()
	{
		UI_Controller.getInstance.mainBattleScene ();
	}

	public override void update ()
	{
		Debug.Log ("計算処理");
	}

	public override void nextState ()
	{
		this.manager.nextState (new End_State(this.manager));
	}

	public override void onClick ()
	{
		nextState ();
	}

}
