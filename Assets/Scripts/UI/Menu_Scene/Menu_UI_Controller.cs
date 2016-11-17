using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Menu_BackGround))]
[RequireComponent(typeof(Menu_Button))]
public class Menu_UI_Controller : MonoBehaviour {
	/*画像パス*/
	private const string TITLE_BG		=	"BG/Title_BG";
	private const string MENU_BG		=	"BG/Menu_BG";

	private static Menu_UI_Controller instance;

	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}

	public static Menu_UI_Controller getInstance{
		get{
			return instance;
		}
	}

	public void titleScene(){
		Menu_BackGround bg = this.GetComponent<Menu_BackGround> ();
		bg.changeBg (TITLE_BG);
		Menu_Button mb	=	this.GetComponent<Menu_Button> ();
		mb.isVisible (false);
	}

	public void menuScene(){
		Menu_BackGround bg = this.GetComponent<Menu_BackGround> ();
		bg.changeBg (MENU_BG);
		Menu_Button mb	=	this.GetComponent<Menu_Button> ();
		mb.isVisible (true);
		//Logo.getInstance.mainScene ();
	}
}