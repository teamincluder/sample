using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Second_Move_Func))]
[RequireComponent(typeof(Trigger_Interface))]
public class AI_Controller: MonoBehaviour {
	private const string FIRST_PLAYER_PATH = "1P";

	//trigger判定
	private Trigger_Interface triggers;
	public Trigger_Interface get_Triggers{
		get{
			return triggers;
		}
	}

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

	private AI_State_Interface autobattle;
	void Awake(){
		triggers	= this.GetComponent<Trigger_Interface> ();
		triggers.init (2);
		target 		= GameObject.Find (FIRST_PLAYER_PATH).transform;
		autobattle 	= new Move_State (this);
		movefunc 	= this.GetComponent<Second_Move_Func> ();
	}

	void Start(){
		autobattle.start ();
	}

	void Update(){
		if(ismain)
			autobattle.update ();
		this.changeState ();
	}

	public void changeState(){
		int result = 1;
		switch(result){
		case 1:
			autobattle = new Attack_State (this);
			break;
		case 2:
			autobattle = new Move_State (this);
			break;
		case 3:
			autobattle = new Guard_State (this);
			break;
		case 4:
			autobattle = new Stay_State (this);
			break;
		}
		autobattle.start ();
	}
}