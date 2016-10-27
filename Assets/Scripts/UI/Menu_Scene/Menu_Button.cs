using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
public class Menu_Button : MonoBehaviour {
	/*画像パス*/
	private const string STORY_IMG_PATH 			= "MenuButton/story";
	private const string SELECTED_STORY_IMG_PATH 	= "MenuButton/select_story";
	private const string BATTLE_IMG_PATH 			= "MenuButton/battle";
	private const string SELECTED_BATTLE_IMG_PATH	= "MenuButton/select_battle";
	private const string OPTION_IMG_PATH 			= "MenuButton/option";
	private const string SELECTED_OPTION_IMG_PATH	= "MenuButton/select_option";

	/*obj*/
	private GameObject story;
	private GameObject battle;
	private GameObject option;

	/*ステート*/
	private enum select { story,battle,option };
	private select nowselect = select.story;

	/*obj取得*/
	private void setObj(){
		if(story==null)		story = GameObject.Find("StoryButton");
		if(battle==null)	battle = GameObject.Find("BattleButton");
		if(option==null)	option = GameObject.Find("OptionButton");
	}

	/*表示非表示制御*/
	public void isVisible(bool visible){
		setObj ();
		story.SetActive (visible);
		battle.SetActive (visible);
		option.SetActive (visible);
		if (visible) {
			subscribe ();
			changeImg ();
		}
	}

	/*オブザーバ購読*/
	private void subscribe(){
		First_Key_List list = new First_Key_List (true);
		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.up_Key))
			.Subscribe (_=>
				{
					upKey();
					changeImg();
				})
			.AddTo(this);


		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.down_Key))
			.Subscribe (_=>
				{
					downKey();
					changeImg();
				})
			.AddTo(this);
					
					
		this.UpdateAsObservable ()
			.Where (_ =>Input.GetKeyDown (list.strong_Key))
			.Subscribe (_ =>
				{
					nextScene();
				})
			.AddTo(this);
	}
	/*下押されたときの処理*/
	private void downKey(){
		if (nowselect != select.option)
			nowselect++;
	}
	/*上押されたときの処理*/
	private void upKey(){
		if (nowselect != select.story)
			nowselect--;
	}

	/*丸押された時の処理*/
	private void nextScene(){			

		switch(nowselect)
		{
		case select.story:
			Debug.Log("Story");
			break;
		case select.battle:
			App_Controller.getInstance.nextScene(new Battle_Scene(App_Controller.getInstance),"Battle");
			break;
		case select.option:
			Debug.Log("option");
			break;
		}
	}

	/*画像張替え*/
	private void changeImg(){
		setObj ();
		Image storyImg 		=	story.GetComponent	<Image>	();
		Image battleImg 	=	battle.GetComponent	<Image>	();
		Image optionImg 	=	option.GetComponent	<Image>	();
		switch (nowselect) 
		{
		case  select.story:
			storyImg.sprite		= 	makeSprite (SELECTED_STORY_IMG_PATH);
			battleImg.sprite	=	makeSprite (BATTLE_IMG_PATH);
			optionImg.sprite	=	makeSprite (OPTION_IMG_PATH);
			break;
		case select.battle:
			storyImg.sprite		= 	makeSprite (STORY_IMG_PATH);
			battleImg.sprite	=	makeSprite (SELECTED_BATTLE_IMG_PATH);
			optionImg.sprite	=	makeSprite (OPTION_IMG_PATH);
			break;
		case select.option:
			storyImg.sprite		= 	makeSprite (STORY_IMG_PATH);
			battleImg.sprite	=	makeSprite (BATTLE_IMG_PATH);
			optionImg.sprite	=	makeSprite (SELECTED_OPTION_IMG_PATH);
			break;
		}
	}

	/*Sprite生成処理*/
	private Sprite makeSprite(string path){
		Texture2D img = Resources.Load (path)	as Texture2D;
		return Sprite.Create (img,new Rect(0,0,img.width,img.height),Vector2.zero);
	}
}