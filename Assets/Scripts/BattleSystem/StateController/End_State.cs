using UnityEngine;
//終了処理
public class End_State : State_Interface {
	public End_State(State_Manager manager):base(manager){
	}

	public override void start ()
	{
		UI_Controller.getInstance.endBattleScene ();
	}
	public override void update ()
	{
	}
	public override void nextState ()
	{
		App_Controller.getInstance.nextScene (new Menu_Scene(App_Controller.getInstance),"Menu");
	}

	public override void onClick ()
	{
		nextState ();
	}
}
