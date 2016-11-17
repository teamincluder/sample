using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Battle_Font))]
public class Battle_UI_Controller : MonoBehaviour {

	/*テキストメッセージ*/
	private const string START_MESSAGE 	=	"Click Start!";

	private static Battle_UI_Controller instance;

	public static Battle_UI_Controller getInstance{
		get{
			return instance;
		}
	}

	private void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}

	public void startBattleScene(){
		Battle_Font bf = this.GetComponent<Battle_Font> ();
		bf.isVisible (true);
		bf.setMessage (START_MESSAGE);
	}
	public void mainBattleScene(){
		Battle_Font bf = this.GetComponent<Battle_Font> ();
		bf.isVisible (true);
		bf.setMessage ("Main");
	}
	public void endBattleScene(string result){
		Battle_Font bf = this.GetComponent<Battle_Font> ();
		bf.isVisible (true);
		bf.setMessage (result);
	}
}
