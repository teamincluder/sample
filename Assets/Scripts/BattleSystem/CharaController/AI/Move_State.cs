using UnityEngine;
public class Move_State : AI_State_Interface {
	public Move_State(AI_Controller manager):base(manager){
	}
	public override void start ()
	{
	}

	public override void update ()
	{
		if (dist_X <= near)
			changeState ();
		else if (timer <= 0)
			move ();
		else
			timer -= Time.deltaTime;
			
	}

	public override void changeState ()
	{
		this.manager.changeState (this.manager.tekitoudeii());
	}

	private void move(){
		if (ismainfunc)
			return;
		ismainfunc = true;
		if (enemyIsRight)
			this.manager.move_Func.rightMove ();
		else
			this.manager.move_Func.leftMove ();
		timer = Random.Range (0.01f,0.05f);
		ismainfunc = false;
	}
}