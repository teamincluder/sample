using UnityEngine;
//終了処理
public class End_State : State_Interface {
	private string result;
	private float timer;
	public End_State(State_Manager manager,string result):base(manager){
		this.result = result;
	}

	public override void start ()
	{
		Battle_UI_Controller.getInstance.endBattleScene (result);
		this.manager.first_Manager.set_isMain	= false;
		this.manager.second_Manager.set_isMain	= false;
	}
	public override void update ()
	{
		timer += Time.deltaTime;
	}
	public override void nextState ()
	{
		App_Controller.getInstance.nextScene (new Menu_Scene(App_Controller.getInstance),"Menu");
	}

	public override void onClick ()
	{
		if(timer >= 0.5f)
			nextState ();
	}
}
