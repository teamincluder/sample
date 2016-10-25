using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine.SceneManagement;
public class Menu_Button : MonoBehaviour {
	private const string STORY_IMG_PATH 			= "story";
	private const string SELECTED_STORY_IMG_PATH 	= "select_story";
	private const string BATTLE_IMG_PATH 			= "battle";
	private const string SELECTED_BATTLE_IMG_PATH	= "select_battle";
	private const string OPTION_IMG_PATH 			= "option";
	private const string SELECTED_OPTION_IMG_PATH	= "select_option";

	private GameObject story;
	private GameObject battle;
	private GameObject option;
	private enum select { story,battle,option };
	private select nowselect = select.story;

	private void setObj(){
		if(story==null)		story = GameObject.Find("StoryButton");
		if(battle==null)	battle = GameObject.Find("BattleButton");
		if(option==null)	option = GameObject.Find("OptionButton");
	}

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
	private void subscribe(){
		Key_List list = new Key_List (true);
		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.up_Key))
			.Subscribe (_=>
				{
					if (SceneManager.GetActiveScene().name == "Menu")
					{
						nowselect--;
						changeImg();
					}
				})
			.AddTo(this);


		this.UpdateAsObservable ()
			.Where (_ => Input.GetKeyDown (list.down_Key))
			.Subscribe (_=>
				{
					if (SceneManager.GetActiveScene().name == "Menu")
					{
						nowselect++;
						changeImg();
					}
				})
			.AddTo(this);
					
					
		this.UpdateAsObservable ()
			.Where (_ =>Input.GetKeyDown (list.strong_Key))
			.Subscribe (_ =>
				{
					if (SceneManager.GetActiveScene().name == "Menu")
						nextScene();
				})
			.AddTo(this);
	}

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
	private Sprite makeSprite(string path){
		Texture2D img = Resources.Load (path)	as Texture2D;
		return Sprite.Create (img,new Rect(0,0,img.width,img.height),Vector2.zero);
	}
		
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
}