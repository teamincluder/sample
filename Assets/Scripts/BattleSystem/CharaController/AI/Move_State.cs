using UnityEngine;
public class Move_State : AI_State_Interface {
	private bool isleft 	= false;
	private bool isright	= false;
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
		if (isright)
			this.manager.move_Func.stopRightMove ();
		if (isleft)
			this.manager.move_Func.stopLeftMove ();
		this.manager.changeState (this.manager.tekitoudeii());
	}

	private void move(){
		if (ismainfunc)
			return;
		ismainfunc = true;
		if (enemyIsRight) {
			if (!isright) {
				this.manager.move_Func.startRightMove ();
				isright = true;
			}
			if (isleft)
				this.manager.move_Func.stopLeftMove ();

			this.manager.move_Func.rightMove ();
		}
		else {
			if (!isleft) {
				this.manager.move_Func.startLeftMove ();
				isleft = true;
			}
			if (isright)
				this.manager.move_Func.stopRightMove ();
			
			this.manager.move_Func.leftMove ();
		}
		timer = Random.Range (0.01f,0.05f);
		ismainfunc = false;
	}
}