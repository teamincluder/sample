using UnityEngine;
public class Attack_State : AI_State_Interface {
	public Attack_State(AI_Controller manager):base(manager){
		
	}

	public override void start (){
	}

	public override void update ()
	{
		if (dist_X >= near)
			changeState ();
		else if (timer <= 0) {
			attack ();
			int result = Random.Range (0,2);
			if (result == 0)
				changeState ();
		}
		else
			timeCount ();
	}

	public override void changeState ()
	{
		this.manager.changeState (this.manager.tekitoudeii());
	}

	public void attack(){
		if (ismainfunc)
			return;
		ismainfunc = true;
		Second_Move_Func attack = this.manager.move_Func;
		int result = Random.Range (0,2);
		if (result == 0 && this.manager.get_Triggers.jab_Hit)
			attack.jabMove ();
		else if (this.manager.get_Triggers.strong_Hit)
			attack.strongMove ();
		timer 		= Random.Range (0.2f,1.2f);
		ismainfunc	= false;
	}
}
