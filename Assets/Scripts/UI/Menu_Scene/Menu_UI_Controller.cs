using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
[RequireComponent(typeof(Menu_BackGround))]
[RequireComponent(typeof(Menu_Button))]
public class Menu_UI_Controller : MonoBehaviour {
	/*画像パス*/
	private const string TITLE_BG		=	"BG/Title_BG";
	private const string MENU_BG		=	"BG/Menu_BG";

	private Menu_BackGround	menubackground;
	private Menu_Button		menubutton;

	private static Menu_UI_Controller instance;

	private Button_State buttonstate;

	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
		if (menubackground 	==	null)	menubackground	=	this.GetComponent<Menu_BackGround> ();
		if (menubutton		==	null)	menubutton		=	this.GetComponent<Menu_Button>();
		if (buttonstate 	==	null)	buttonstate		=	Button_State.get_Instance;
	}

	public static Menu_UI_Controller get_Instance{
		get{
			return instance;
		}
	}

	public void titleScene(){
		menubackground.logoVisible (true);
		menubutton.isVisible (false);
	}

	public void menuScene(){
		menubutton.isVisible (true);
		menubackground.logoVisible (false);
		subscribe ();
		//Logo.getInstance.mainScene ();
	}


	/*オブザーバ購読*/
	private void subscribe(){
		First_Key_List list = new First_Key_List (true);
		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.right_Key))
			.Subscribe (_=>
				{
					rightMoveButton();
					changeImg();
				})
			.AddTo(this);


		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.left_Key))
			.Subscribe (_ =>
				{
					leftMoveButton ();
					changeImg ();
				})
			.AddTo (this);
	}

	public void changeImg(){
		menubutton.changeImg ();
	}

	/*右押されたときの処理*/
	private void rightMoveButton(){
		buttonstate.nowStatePlus();
	}

	/*左押されたときの処理*/
	private void leftMoveButton(){
		buttonstate.nowStateMinus ();
	}

}