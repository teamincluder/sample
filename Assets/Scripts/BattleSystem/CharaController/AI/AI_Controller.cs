using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Second_Move_Func))]
public class AI_Controller: MonoBehaviour {

	private const string FIRST_PLAYER_PATH = "1P";
	private Transform target;
	public Transform get_Target{
		get{
			return target;
		}
	}

	private bool ismain = false;
	public bool set_isMain{
		set{
			ismain	=	value;
		}
	}

	private Second_Move_Func movefunc;
	public Second_Move_Func move_Func{
		get{
			return movefunc;
		}
	}

	private AI_State_Interface ai;
	void Awake(){
		target = GameObject.Find (FIRST_PLAYER_PATH).transform;
		ai = new Move_State (this);
		movefunc = this.GetComponent<Second_Move_Func> ();
	}

	void Start(){
		ai.start ();
	}

	void Update(){
		if(ismain)
			ai.update ();
	}

	public void changeState(AI_State_Interface next){
		ai = next;
		ai.start ();
	}
}
