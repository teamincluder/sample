using UnityEngine;
using System.Collections;
public abstract class Move_Func_InterFace :MonoBehaviour{
	protected const float SPEED = 0.06f;
	protected Vector3 RIGHT_MOVE 	= new Vector3 (1f,1f,1f);
	protected Vector3 LEFT_MOVE	= new Vector3 (-1f,1f,1f);
	protected Vector2 JUMP_MOVE	= new Vector2 (0f,10f);
	public abstract void rightMove();
	public abstract void leftMove();
	public abstract void downMove();
	public abstract void jumpMove();
	public abstract void guardMove();
	public abstract void jabMove();
	public abstract void strongMove();
	public abstract void deathBlowMove();
}
