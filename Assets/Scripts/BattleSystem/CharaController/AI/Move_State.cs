using UnityEngine;
public class Move_State : AI_State_Interface {
	public Move_State(AI_Controller manager):base(manager){
	}
	public override void start ()
	{
	}

	public override void update ()
	{
		float dist = Vector3.Distance (target.position, mine.position);
		if (dist <= 2f)
			changeState ();
		else if (target.position.x < mine.position.x && timer <= 0)
			move (false);
		else if (mine.position.x < target.position.x && timer <= 0)
			move (true);
		else
			timer -= Time.deltaTime;
			
	}

	public override void changeState ()
	{
		this.manager.changeState (new Attack_State(this.manager));
	}

	private void move(bool isRight){
		if (ismainfunc)
			return;
		ismainfunc = true;
		Second_Move_Func movefunc = this.manager.move_Func;
		if (isRight)
			movefunc.rightMove ();
		else
			movefunc.leftMove ();
		timer = Random.Range (0.01f,0.05f);
		ismainfunc = false;
	}
}

