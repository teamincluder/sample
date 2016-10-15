using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Move_Func))]

public class Key_Controller : MonoBehaviour {
	Key_List playerkey = new Key_List();
	Move_Func movefunc ;
	// Use this for initialization
	void Start () {
		movefunc = this.GetComponent<Move_Func> ();
		movefunc.init ();
		playerkey.init (true);

		var jab			=	this.UpdateAsObservable()
								.Where (_=>!(Input.GetKeyDown(playerkey.strongkey)))
								.Where (_=>Input.GetKeyDown(playerkey.jabkey))
								.Subscribe (_=>movefunc.jabMove());
	
		var strong	 	= 	this.UpdateAsObservable()
								.Where (_=>!(Input.GetKeyDown(playerkey.jabkey)))
								.Where (_=>Input.GetKeyDown(playerkey.strongkey))
								.Subscribe (_=>movefunc.strongMove());
		
		var deathblow 	= 	this.UpdateAsObservable ()
								.Where (_ =>Input.GetKeyDown (playerkey.jabkey))
								.Where (_ =>Input.GetKeyDown(playerkey.strongkey))
								.Subscribe (_=>movefunc.deathBlowMove());

		var jump		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.jumpkey))
								.Subscribe (_=>movefunc.jumpMove());

		var guard 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.guardkey))
								.Subscribe (_=>movefunc.guardMove());

		var left 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKey(playerkey.leftkey))
								.Subscribe (_=>movefunc.leftMove());

		var right		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKey(playerkey.rightkey))
								.Subscribe (_=>movefunc.rightMove());

		var up			= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.upkey))
								.Subscribe (_=>movefunc.jumpMove());
	
		var down 		= 	this.UpdateAsObservable()
								.Where (_=>Input.GetKeyDown(playerkey.downkey))
								.Subscribe (_=>movefunc.downMove());
	}
}
