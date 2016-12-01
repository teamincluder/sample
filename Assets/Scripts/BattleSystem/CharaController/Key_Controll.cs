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
	private user playing = user.second;
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

	void Awake(){
		if (playing == user.first) {
			move = this.gameObject.AddComponent<First_Move_Func> ();
			keylist = new First_Key_List ();
		} else {
			move = this.gameObject.AddComponent<Second_Move_Func> ();
			keylist = new Second_Key_List ();
		}
	}

	void Start () {
		
		/*ガード処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.guard_Key))
			.Subscribe (_ => 
				{
					move.guardMove();
				});

		/*ガード終了処理*/
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
			.Where (_ => !(Input.GetKey(keylist.guard_Key)))
			.Where (_ => !(Input.GetKey(keylist.strong_Key)))
			.Where (_ => Input.GetKeyDown(keylist.jab_Key))
			.Subscribe(_ =>
				{
					move.jabMove();
				});

		/*強攻撃処理*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => !(Input.GetKey(keylist.guard_Key)))
			.Where (_ => !(Input.GetKey(keylist.jab_Key)))
			.Where (_ => Input.GetKeyDown(keylist.strong_Key))
			.Subscribe (_ => 
				{
					move.strongMove();
				});

		/*必殺技処理
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.jab_Key))
			.Where (_ => Input.GetKeyDown(keylist.strong_Key))
			.Where (_ => triggers.deathblow_Hit)
			.Subscribe (_=>
				{
					move.deathBlowMove();
				});
		*/

		/*左移動開始*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.left_Key))
			.Subscribe (_=>
				{
					move.startLeftMove();
				});
		
		/*左移動*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKey(keylist.left_Key))
			.Subscribe (_=>
				{
					move.leftMove();
				});

		/*左終了*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyUp (keylist.left_Key))
			.Subscribe (_ => 
				{
					move.stopLeftMove();
				});

		/*右移動開始*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyDown(keylist.right_Key))
			.Subscribe (_=>
				{
					move.startRightMove();
				});

		/*右移動*/
		this.UpdateAsObservable()
			.Where (_ => ismain)
			.Where (_ => Input.GetKey(keylist.right_Key))
			.Subscribe (_=>
				{
					move.rightMove();
				});
		
		/*右終了*/
		this.UpdateAsObservable ()
			.Where (_ => ismain)
			.Where (_ => Input.GetKeyUp (keylist.right_Key))
			.Subscribe (_ => 
				{
					move.stopRightMove();
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
