using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

[RequireComponent (typeof (Rigidbody2D))]
public class Key_Controll: MonoBehaviour {
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

	/*どっちのコントローラか判別用*/
	private enum user{first,second};
	[SerializeField]
	private user playing = user.first;
	[SerializeField]
	private bool ismain = false;
	public bool set_IsMain{
		set{
			ismain = value;
		}
	}

	/*切り替えできるようにインターフェイスを変数にしとく*/
	private Key_Interface keylist;
	private Move_Func_InterFace move;

	public void set_user(bool isfirst){
		if (isfirst)
			playing	=	user.first;
		else
			playing	=	user.second;
	}

	void Awake(){
		guardfunc 		=	getTriggerHit (GUARD_PATH);
		jabfunc 		=	getTriggerHit (JAB_PATH);
		strongfunc		=	getTriggerHit (STRONG_PATH);
		deathblowfunc	=	getTriggerHit (DEATH_BLOW_PATH);

		if (playing == user.first) {
			move = this.gameObject.AddComponent<First_Move_Func> ();
			keylist = new First_Key_List (true);
			triggerInit (1);
		} else {
			move = this.gameObject.AddComponent<Second_Move_Func> ();
			keylist = new Second_Key_List ();
			triggerInit (2);
		}
	}

	void Start () {
		
		/*ガード処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKey(keylist.guard_Key))
			.Where (_ => guardfunc.is_Hit)
			.Subscribe (_ => 
				{
					move.guardMove();
				});

		/*弱攻撃処理*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => !(Input.GetKey(keylist.strong_Key)))
			.Where (_ => Input.GetKeyDown(keylist.jab_Key))
			.Where (_ => jabfunc.is_Hit)
			.Subscribe(_ =>
				{
					move.jabMove();
				});

		/*強攻撃処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => !(Input.GetKey(keylist.jab_Key)))
			.Where (_ => Input.GetKeyDown(keylist.strong_Key))
			.Where (_ => strongfunc.is_Hit)
			.Subscribe (_ => 
				{
					move.strongMove();
				});
		
		/*必殺技処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.jab_Key))
			.Where (_ => Input.GetKeyDown(keylist.strong_Key))
			.Where (_ => deathblowfunc.is_Hit)
			.Subscribe (_=>
				{
					move.deathBlowMove();
				});
		
		/*左移動*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKey(keylist.left_Key))
			.Subscribe (_=>
				{
					move.leftMove();
				});

		/*右移動*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKey(keylist.right_Key))
			.Subscribe (_=>
				{
					move.rightMove();
				});

		/*ジャンプ*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.up_Key))
			.Subscribe (_=>
				{
					move.jumpMove();
				});

		/*ジャンプ*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.jump_Key))
			.Subscribe (_=>
				{
					move.jumpMove();
				});

		/*しゃがみ*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.down_Key))
			.Subscribe (_=>
				{
					move.downMove();
				});

	}
		
	/*コンポーネント取得*/
	private Trigger_Hit getTriggerHit(string path){
		GameObject target = this.gameObject.transform.FindChild (path).gameObject;
		Trigger_Hit value = target.GetComponent<Trigger_Hit> ();
		return value;
	}

	private void triggerInit(int num){
		guardfunc.user_Number		= num;
		jabfunc.user_Number 		= num;
		strongfunc.user_Number		= num;
		deathblowfunc.user_Number	= num;
	}
}
