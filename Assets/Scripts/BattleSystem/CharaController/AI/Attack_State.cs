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
		else if (timer <= 0)
			attack ();
		else
			timeCount ();
	}

	public override void changeState ()
	{
		//this.manager.changeState (new Move_State(this.manager));
	}

	public void attack(){
		if (ismainfunc)
			return;
		ismainfunc = true;
		Second_Move_Func attack = this.manager.move_Func;
		int result = Random.Range (0,10);
		if (result <= 5 && this.manager.get_Triggers.jab_Hit)
			attack.jabMove ();
		else if (result != 9 && this.manager.get_Triggers.strong_Hit)
			attack.strongMove ();
		else if (this.manager.get_Triggers.deathblow_Hit) {
			attack.deathBlowMove ();
		}
		timer 		= Random.Range (0.2f,1.2f);
		ismainfunc	= false;
	}
}
