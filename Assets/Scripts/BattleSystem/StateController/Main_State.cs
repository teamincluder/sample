using UnityEngine;

public class Main_State : State_Interface {

	public Main_State(State_Manager manager):base(manager){
	}
	public override void start ()
	{
		Debug.Log (this);
	}

	public override void update ()
	{
		Debug.Log ("キー判定");
		nextState ();
	}

	public override void nextState ()
	{
		this.manager.nextState (new Calc_State(this.manager));
	}


}
