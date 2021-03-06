﻿using UnityEngine;
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

	private bool menuselected = false;
	public 	bool menu_Selected{
		get{
			return menuselected;
		}
	}

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
		menubutton.isBattle  (false);
	}

	public void menuScene(){
		menubutton.isVisible (true);
		menubackground.logoVisible (false);
		menuSubscribe ();
		Logo.getInstance.mainScene ();
	}
	public void battleSelect(){
		menuselected = true;
		menubutton.isBattle	(true);
		menubutton.isVisible (false);
		changeMake ();
		battleSubscribe ();
	}

	private void battleSubscribe(){
		First_Key_List list = new First_Key_List ();
		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.right_Key))
			.Where (_ => menuselected )
			.Subscribe (_ => 
				{
					Battle_Button_State.get_Instance.nowStatePlus();
					changeMake();
				})
			.AddTo(this);
		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.left_Key))
			.Where (_ => menuselected )
			.Subscribe (_ => 
				{
					Battle_Button_State.get_Instance.nowStateMinus();
					changeMake();
				})
			.AddTo(this);
	}

	/*オブザーバ購読*/
	private void menuSubscribe(){
		First_Key_List list = new First_Key_List ();
		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.right_Key))
			.Where (_ => !menuselected)
			.Subscribe (_=>
				{
					buttonstate.nowStatePlus();
					changeImg();
				})
			.AddTo(this);


		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.left_Key))
			.Where (_ => !menuselected )
			.Subscribe (_ =>
				{
					buttonstate.nowStateMinus ();
					changeImg ();
				})
			.AddTo (this);
	}

	public void changeMake(){
		menubutton.changeMake ();
	}
	public void changeImg(){
		menubutton.changeImg ();
	}
}