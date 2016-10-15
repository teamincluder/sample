using UnityEngine;
public class Start_State : State_Interface {
	public Start_State(State_Manager manager):base(manager){
	}

	public override void start ()
	{

		Debug.Log (this);
		
	}
	public override void update ()
	{
		//条件クリックしたら
		nextState ();
	}
	public override void nextState ()
	{
		this.manager.nextState (new Main_State(this.manager));
	}
}