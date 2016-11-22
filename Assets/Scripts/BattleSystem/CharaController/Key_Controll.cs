using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(Trigger_Interface))]
public class Key_Controll: MonoBehaviour {
	/*どっちのコントローラか判別用*/
	private enum user{first,second};
	[SerializeField]
	private user playing = user.first;
	private bool ismain = false;
	public bool set_IsMain{
		set{
			ismain = value;
		}
	}

	private Trigger_Interface triggers;

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
		if (triggers == null) triggers = this.GetComponent<Trigger_Interface> ();
		if (playing == user.first) {
			move = this.gameObject.AddComponent<First_Move_Func> ();
			keylist = new First_Key_List ();
			triggers.init (1);
		} else {
			move = this.gameObject.AddComponent<Second_Move_Func> ();
			keylist = new Second_Key_List ();
			triggers.init (2);
		}
	}

	void Start () {
		
		/*ガード処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKey(keylist.guard_Key))
			.Subscribe (_ => 
				{
					move.guardMove();
				});

		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyUp (keylist.guard_Key))
			.Subscribe (_ => 
				{
					move.noguardMove();
				});

		/*弱攻撃処理*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => !(Input.GetKey(keylist.strong_Key)))
			.Where (_ => Input.GetKeyDown(keylist.jab_Key))
			.Where (_ => triggers.jab_Hit)
			.Subscribe(_ =>
				{
					move.jabMove();
				});

		/*強攻撃処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => !(Input.GetKey(keylist.jab_Key)))
			.Where (_ => Input.GetKeyDown(keylist.strong_Key))
			.Where (_ => triggers.strong_Hit)
			.Subscribe (_ => 
				{
					move.strongMove();
				});
		
		/*必殺技処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.jab_Key))
			.Where (_ => Input.GetKeyDown(keylist.strong_Key))
			.Where (_ => triggers.deathblow_Hit)
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
}
