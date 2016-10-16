using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Move_Func))]
/*
 キャラコントローラー実装部
 Key_Listからキーの割り当てを拾って関数呼び出してます。
 API部はMove＿Func
*/
public class Key_Controller : MonoBehaviour {
	const bool 	DEBUGMODE = true;
	Key_List 	playerkey = new Key_List();
	Move_Func	movefunc ;

	void Start () {
		movefunc = this.GetComponent<Move_Func> ();
		movefunc.init ();
		playerkey.init (DEBUGMODE);

		var jab			=	this.UpdateAsObservable()
								.Where (_=>!(Input.GetKeyDown(playerkey.strong_Key)))
								.Where (_=>Input.GetKeyDown(playerkey.jab_Key))
								.Subscribe (_=>movefunc.jabMove());
	
		var strong	 	= 	this.UpdateAsObservable()
								.Where (_=>!(Input.GetKeyDown(playerkey.jab_Key)))
								.Where (_=>Input.GetKeyDown(playerkey.strong_Key))
								.Subscribe (_=>movefunc.strongMove());
		
		var deathblow 	= 	this.UpdateAsObservable ()
								.Where (_ =>Input.GetKeyDown (playerkey.jab_Key))
								.Where (_ =>Input.GetKeyDown(playerkey.strong_Key))
								.Subscribe (_=>movefunc.deathBlowMove());

		var jump		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.jump_Key))
								.Subscribe (_=>movefunc.jumpMove());

		var guard 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.guard_Key))
								.Subscribe (_=>movefunc.guardMove());

		var left 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKey(playerkey.left_Key))
								.Subscribe (_=>movefunc.leftMove());

		var right		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKey(playerkey.right_Key))
								.Subscribe (_=>movefunc.rightMove());

		var up			= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.up_Key))
								.Subscribe (_=>movefunc.jumpMove());
	
		var down 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.down_Key))
								.Subscribe (_=>movefunc.downMove());
	}
}
