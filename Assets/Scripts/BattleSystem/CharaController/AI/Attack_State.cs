using UnityEngine;
using System.Collections;

public class Attack_State : AI_State_Interface {
	public Attack_State(AI_Controller manager):base(manager){
		
	}

	public override void start ()
	{
	}

	public override void update ()
	{
		float dist = Vector3.Distance (target.position, mine.position);
		if (dist >= 2f)
			changeState ();
		else if (timer <= 0)
			attack ();
		else
			timer -= Time.deltaTime;
			
	}

	public override void changeState ()
	{
		this.manager.changeState (new Move_State(this.manager));
	}

	public void attack(){
		if (ismainfunc)
			return;
		ismainfunc = true;
		Second_Move_Func attack = this.manager.move_Func;
		int result = Random.Range (0,10);
		if (result <= 5)
			attack.jabMove ();
		else if (result != 9)
			attack.strongMove ();
		else
			attack.deathBlowMove ();
		timer 		= Random.Range (0.2f,1.2f);
		ismainfunc	= false;
	}

}
