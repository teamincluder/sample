using UnityEngine;
using System.Collections;

public class Trigger_Interface : MonoBehaviour {
	/*Find用パス*/
	private const string JAB_PATH 			=	"Triggers/Jab";
	private const string STRONG_PATH 		= 	"Triggers/Strong";
	private const string DEATH_BLOW_PATH	= 	"Triggers/DeathBlow";

	/*Trigger取得クラス*/
	private Trigger_Hit jabfunc;
	private Trigger_Hit strongfunc;
	private Trigger_Hit deathblowfunc;

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

	public bool jab_Guard{
		get{
			return jabfunc.is_Guard;
		}
	}

	public bool strong_Guard{
		get{
			return strongfunc.is_Guard;
		}
	}

	public bool deathblow_Guard{
		get{
			return deathblowfunc.is_Guard;
		}
	}

	/*初期化処理*/
	public void init(int num){
		jabfunc 			=	this.setTriggerHit (JAB_PATH);
		strongfunc			=	this.setTriggerHit (STRONG_PATH);
		deathblowfunc		=	this.setTriggerHit (DEATH_BLOW_PATH);
		
		jabfunc.user_Number 		= num;
		strongfunc.user_Number		= num;
		deathblowfunc.user_Number	= num;
	}

	/*TriggerHitを付与する*/
	private Trigger_Hit setTriggerHit(string path){
		GameObject target = this.gameObject.transform.FindChild (path).gameObject;
		Trigger_Hit value = target.AddComponent<Trigger_Hit> ();
		return value;
	}
}
