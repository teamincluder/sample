using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
public class Get_Hit : MonoBehaviour {
	private const string GUARD_PATH			=	"Unity/Guard";
	private const string JAB_PATH 			=	"Unity/Jab";
	private const string STRONG_PATH 		= 	"Unity/Strong";
	private const string DEATH_BLOW_PATH	= 	"Unity/DeathBlow";

	Trigger_Hit guardfunc;
	Trigger_Hit jabfunc;
	Trigger_Hit strongfunc;
	Trigger_Hit deathblowfunc;


	void Start () {
		First_Key_List player = new First_Key_List (true);

		guardfunc 		=	getTriggerHit (GUARD_PATH);
		jabfunc 		=	getTriggerHit (JAB_PATH);
		strongfunc		=	getTriggerHit (STRONG_PATH);
		deathblowfunc	=	getTriggerHit (DEATH_BLOW_PATH);

		/*Guard処理*/
		this.UpdateAsObservable ()
			.Where (_ => Input.GetKey(player.guard_Key))
			.Where (_ => guardfunc.is_Hit)
			.Subscribe (_ => 
				{
					Debug.Log("ガード");	
				});

		this.UpdateAsObservable()
			.Where (_ => Input.GetKeyDown(player.jab_Key))
			.Where (_ => jabfunc.is_Hit)
			.Subscribe(_ =>
				{
					Debug.Log("弱攻撃");
				});

	}

	private Trigger_Hit getTriggerHit(string path){
		Trigger_Hit value = GameObject.Find (path).GetComponent<Trigger_Hit> ();
		return value;
	}
}
