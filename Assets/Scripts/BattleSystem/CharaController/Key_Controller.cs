using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

/*
 キャラコントローラー実装部
 Key_Listからキーの割り当てを拾って関数呼び出してます。
 API部はMove＿Func
*/
[RequireComponent(typeof(Move_Func))]
public class Key_Controller : MonoBehaviour {

	/*デバック用*/
	const bool 	DEBUGMODE = true;

	void Start () {
		/*Keyの配列*/
		Key_List 	playerkey	=	new Key_List(DEBUGMODE);

		/*実際に動作させる関数群*/
		Move_Func 	movefunc 	=	this.GetComponent<Move_Func> ();
		movefunc.init ();

		/*弱攻撃*/
		this.UpdateAsObservable()
			.Where (_=>!(Input.GetKeyDown(playerkey.strong_Key)))
			.Where (_=>Input.GetKeyDown(playerkey.jab_Key))
			.Subscribe (_=>movefunc.jabMove());

		/*強攻撃*/
		this.UpdateAsObservable()
			.Where (_=>!(Input.GetKeyDown(playerkey.jab_Key)))
			.Where (_=>Input.GetKeyDown(playerkey.strong_Key))
			.Subscribe (_=>movefunc.strongMove());
		
		/*必殺技*/
		this.UpdateAsObservable ()
			.Where (_ =>Input.GetKeyDown (playerkey.jab_Key))
			.Where (_ =>Input.GetKeyDown(playerkey.strong_Key))
			.Subscribe (_=>movefunc.deathBlowMove());

		/*ジャンプ*/
		this.UpdateAsObservable()
			.Where (_=>Input.GetKeyDown(playerkey.jump_Key))
			.Subscribe (_=>movefunc.jumpMove());

		/*ガード*/
		this.UpdateAsObservable()
			.Where (_=>Input.GetKeyDown(playerkey.guard_Key))
			.Subscribe (_=>movefunc.guardMove());

		/*左移動*/
		this.UpdateAsObservable()
			.Where (_=>Input.GetKey(playerkey.left_Key))
			.Subscribe (_=>movefunc.leftMove());

		/*右移動*/
		this.UpdateAsObservable()
			.Where (_=>Input.GetKey(playerkey.right_Key))
			.Subscribe (_=>movefunc.rightMove());

		/*ジャンプ*/
		this.UpdateAsObservable()
			.Where (_=>Input.GetKeyDown(playerkey.up_Key))
			.Subscribe (_=>movefunc.jumpMove());
	
		/*しゃがみ*/
		this.UpdateAsObservable()
			.Where (_=>Input.GetKeyDown(playerkey.down_Key))
			.Subscribe (_=>movefunc.downMove());
	}
}
