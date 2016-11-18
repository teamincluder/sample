using UnityEngine;
using System.Collections;

public class Trigger_Interface : MonoBehaviour {
	/*Find用パス*/
	private const string GUARD_PATH			=	"Triggers/Guard";
	private const string JAB_PATH 			=	"Triggers/Jab";
	private const string STRONG_PATH 		= 	"Triggers/Strong";
	private const string DEATH_BLOW_PATH	= 	"Triggers/DeathBlow";

	/*Trigger取得クラス*/
	private Trigger_Hit guardfunc;
	private Trigger_Hit jabfunc;
	private Trigger_Hit strongfunc;
	private Trigger_Hit deathblowfunc;

	public bool guard_Hit{
		get{
			return guardfunc.is_Hit;
		}
	}
	public bool jab_Hit{
		get{
			return jabfunc.is_Hit;
		}
	}
	public bool strong_Hit{
		get{
			return strongfunc.is_Hit;
		}
	}
	public bool deathblow_Hit{
		get{
			return deathblowfunc.is_Hit;
		}
	}

	/*コンポーネント取得*/
	private Trigger_Hit getTriggerHit(string path){
		GameObject target = this.gameObject.transform.FindChild (path).gameObject;
		Trigger_Hit value = target.GetComponent<Trigger_Hit> ();
		return value;
	}

	public void init(int num){
		guardfunc 		=	getTriggerHit (GUARD_PATH);
		jabfunc 		=	getTriggerHit (JAB_PATH);
		strongfunc		=	getTriggerHit (STRONG_PATH);
		deathblowfunc	=	getTriggerHit (DEATH_BLOW_PATH);

		guardfunc.user_Number		= num;
		jabfunc.user_Number 		= num;
		strongfunc.user_Number		= num;
		deathblowfunc.user_Number	= num;
	}
}
