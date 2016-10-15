using UnityEngine;
//終了処理
public class End_State : State_Interface {
	public End_State(State_Manager manager):base(manager){
	}

	public override void start ()
	{
		Debug.Log (this);
	}
	public override void update ()
	{
	}
	public override void nextState ()
	{
	}
}
