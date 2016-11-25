using UnityEngine;
public abstract class AI_State_Interface {
	protected AI_Controller manager;
	protected Transform target;
	protected Transform mine;
	protected bool 		ismainfunc 	= 	false;
	protected float 	timer 		= 	0f;
	protected float		near		=	2f;

	public AI_State_Interface(AI_Controller manager){
		this.manager = manager;
		if (target == null)
			target 	= this.manager.get_Target;
		if (mine == null)
			mine	= this.manager.transform;
	}
	public float dist_X{
		get{
			float distx = target.position.x - mine.position.x;
			if (distx < 0)
				distx = -distx;
			return distx;
		}
	}
	public bool pos_Ene_Y{
		get{
			bool enemyonmine = false;
			float poseney	= target.position.y - mine.position.y;
			if (poseney > 0)
				enemyonmine = true;
			return enemyonmine;
		}
	}
	public bool enemyIsRight{
		get{
			return target.position.x > mine.position.x;
		}
	}
	public void timeCount(){
		timer -= Time.deltaTime;
	}
	public abstract void start ();
	public abstract void update();
	public abstract void changeState();
}
