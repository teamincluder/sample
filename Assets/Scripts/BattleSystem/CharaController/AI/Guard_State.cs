using UnityEngine;
using System.Collections;

public class Guard_State : AI_State_Interface {
	public Guard_State(AI_Controller manager):base(manager){
		
	}
	
	public override void start (){
		
	}

	public override void update (){
		if (dist_X > near) {
			changeState ();
		} 
		else if (timer <= 0) {
			guard ();
			int result = Random.Range (0, 10);
			if (result == 0)
				changeState ();
		} 
		else
			timeCount ();
	}

	public override void changeState (){
		this.manager.move_Func.noguardMove ();
		this.manager.changeState (this.manager.tekitoudeii());
	}

	void guard(){
		this.manager.move_Func.guardMove ();
	}


}
