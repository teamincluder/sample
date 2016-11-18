using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Menu_BackGround))]
[RequireComponent(typeof(Menu_Button))]
public class Menu_UI_Controller : MonoBehaviour {
	/*画像パス*/
	private const string TITLE_BG		=	"BG/Title_BG";
	private const string MENU_BG		=	"BG/Menu_BG";

	private Menu_BackGround	menubackground;
	private Menu_Button		menubutton;

	private static Menu_UI_Controller instance;

	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
		if (menubackground 	==	null)	menubackground	=	this.GetComponent<Menu_BackGround> ();
		if (menubutton		==	null)	menubutton		=	this.GetComponent<Menu_Button>();
	}

	public static Menu_UI_Controller getInstance{
		get{
			return instance;
		}
	}

	public void titleScene(){		
		menubackground.changeBg (TITLE_BG);
		menubutton.isVisible (false);
	}

	public void menuScene(){
		menubackground.changeBg (MENU_BG);
		menubutton.isVisible (true);
		//Logo.getInstance.mainScene ();
	}
}