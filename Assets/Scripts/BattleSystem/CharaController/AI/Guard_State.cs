using UnityEngine;
using System.Collections;

public class Guard_State : AI_State_Interface {
	public Guard_State(AI_Controller manager):base(manager){
		
	}
	
	public override void start (){
		Debug.Log ("GUARD");
		changeState ();
	}

	public override void update (){
		
	}

	public override void changeState (){
		this.manager.changeState (this.manager.tekitoudeii());
	}



}
