using UnityEngine;
public abstract class AI_State_Interface {
	protected AI_Controller manager;
	protected Transform target;
	protected Transform mine;
	protected bool 		ismainfunc 	= 	false;
	protected float 	timer 		= 	0f;

	public AI_State_Interface(AI_Controller manager){
		this.manager = manager;
		if (target == null)
			target 	= this.manager.get_Target;
		if (mine == null)
			mine	= this.manager.transform;
	}

	public abstract void start ();
	public abstract void update();
	public abstract void changeState();
}
