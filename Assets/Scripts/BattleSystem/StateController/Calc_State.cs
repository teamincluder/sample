using UnityEngine;

public class Calc_State : State_Interface {
	public Calc_State(State_Manager manager):base(manager){
	}

	public override void start ()
	{
	}

	public override void update ()
	{
		Debug.Log ("計算処理");
		nextState ();
	}

	public override void nextState ()
	{
		bool lifezero = false;
		if (lifezero)
			this.manager.nextState (new End_State(this.manager));
		else
			this.manager.nextState (new Main_State(this.manager));
	}
	public override void onClick ()
	{
	}

}
