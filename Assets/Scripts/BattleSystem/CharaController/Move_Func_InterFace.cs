using UnityEngine;
using System.Collections;
public abstract class Move_Func_InterFace :MonoBehaviour{
	protected const float	SPEED 		= 0.06f;
	protected const string	GUARD_PATH	= "Triggers/Guard";
	protected Vector3 		FIRST_RIGHT_MOVE 	= new Vector3 (1f,1f,1f);
	protected Vector3 		FIRST_LEFT_MOVE		= new Vector3 (-1f,1f,1f);
	protected Vector3 		SECOND_RIGHT_MOVE	= new Vector3 (-1f, 1f, 1f);
	protected Vector3 		SECOND_LEFT_MOVE 	= new Vector3 (1f,1f,1f);
	protected Vector2 		JUMP_MOVE			= new Vector2 (0f,10f);

	public abstract void rightMove();
	public abstract void leftMove();
	public abstract void downMove();
	public abstract void jumpMove();
	public abstract void guardMove();
	public abstract void noguardMove ();
	public abstract void jabMove();
	public abstract void strongMove();
	public abstract void deathBlowMove();
}
