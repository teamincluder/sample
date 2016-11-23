using UnityEngine;
using System.Collections;

public class Stay_State : AI_State_Interface {
	public Stay_State(AI_Controller manager):base(manager){
		
	}

	public override void start (){
		Debug.Log ("stay");
		changeState ();
	}

	public override void update (){
		
	}

	public override void changeState (){
		this.manager.changeState (this.manager.tekitoudeii());
	}
}