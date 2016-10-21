using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BackGround_Controller))]
[RequireComponent(typeof(Menu_Button))]
[RequireComponent(typeof(Battle_Font))]
public class UI_Controller : MonoBehaviour {
	private const string TITLE_BG		=	"BG_01";
	private const string MENU_BG		=	"BG_02";
	private const string START_MESSAGE 	=	"Click Start!";
	private const string END_MESSAGE	=	"Click End!";

	private static UI_Controller instance;


	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}
	void Start(){
		DontDestroyOnLoad (this);
	}

	public static UI_Controller getInstance{
		get{
			return instance;
		}
	}
	public void titleScene(){
		BackGround_Controller bg = this.GetComponent<BackGround_Controller> ();
		bg.changeBg (TITLE_BG);
		Menu_Button mb	=	this.GetComponent<Menu_Button> ();
		mb.isVisible (false);
	}

	public void menuScene(){
		BackGround_Controller bg = this.GetComponent<BackGround_Controller> ();
		bg.changeBg (MENU_BG);
		Menu_Button mb	=	this.GetComponent<Menu_Button> ();
		mb.isVisible (true);
	}

	public void startBattleScene(){
		Battle_Font bf = this.GetComponent<Battle_Font> ();
		bf.isVisible (true);
		bf.setMessage (START_MESSAGE);
	}
	public void mainBattleScene(){
		Battle_Font bf = this.GetComponent<Battle_Font> ();
		bf.isVisible (false);
	}
	public void endBattleScene(){
		Battle_Font bf = this.GetComponent<Battle_Font> ();
		bf.isVisible (true);
		bf.setMessage (END_MESSAGE);
	}
}