using UnityEngine;
using System.Collections;

public class Guard_State : AI_State_Interface {
	public Guard_State(AI_Controller manager):base(manager){
		
	}
	
	public override void start (){
		if (dist_X > near)
			changeState ();
		else
			guard ();
	}

	public override void update (){
	}

	public override void changeState (){
		this.manager.changeState (this.manager.tekitoudeii());
	}

	void guard(){
		this.manager.move_Func.guardMove ();
	}


}
