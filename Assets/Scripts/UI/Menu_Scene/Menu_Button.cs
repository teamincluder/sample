using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu_Button : MonoBehaviour {
	/*画像パス*/
	private const string STORY_IMG_PATH 			= "UI/UI_Story_buttun";
	private const string SELECTED_STORY_IMG_PATH 	= "UI/UI_Story_buttun_pushed";
	private const string BATTLE_IMG_PATH 			= "UI/UI_Battle_buttun";
	private const string SELECTED_BATTLE_IMG_PATH	= "UI/UI_Battle_buttun_pushed";
	private const string OPTION_IMG_PATH 			= "UI/UI_Option_buttun";
	private const string SELECTED_OPTION_IMG_PATH	= "UI/UI_Option_buttun_pushed";

	/*画像パス*/
	private const string VS_CPU_IMG_PATH			= "UI/1PvsCPU";
	private const string SELECTED_VS_CPU_IMG_PATH	= "UI/1PvsCPU_pushed";
	private const string VS_SECOND_IMG_PATH 		= "UI/1Pvs2P";
	private const string SELECTED_VS_SECOND_IMG_PATH= "UI/1Pvs2P_pushed";

	/*obj*/
	private GameObject story;
	private GameObject battle;
	private GameObject option;

	private GameObject vscpu;
	private GameObject vssecond;

	/*表示非表示制御*/
	public void isVisible(bool visible){
		if (story		==	null)	story  		= 	GameObject.Find("StoryButton");
		if (battle		==	null)	battle 		= 	GameObject.Find("BattleButton");
		if (option		==	null)	option 		= 	GameObject.Find("OptionButton");

		story.SetActive (visible);
		battle.SetActive (visible);
		option.SetActive (visible);
		if (visible) {
			changeImg ();
		}
	}

	public void isBattle(bool visible){
		if (vscpu 		== 	null)	vscpu 		=	GameObject.Find("VSCPU");
		if (vssecond 	==	null)	vssecond	=	GameObject.Find("VS2P");
		vscpu.SetActive (visible);
		vssecond.SetActive (visible);
		if (visible) {
		}
	}

	public void changeMake(){
		if (vscpu 		== 	null)	vscpu 		=	GameObject.Find("VSCPU");
		if (vssecond 	==	null)	vssecond	=	GameObject.Find("VS2P");
		Image cpuImg	=	vscpu.GetComponent<Image> ();
		Image secondImg	=	vssecond.GetComponent<Image> ();

	}



	/*画像張替え*/
	public void changeImg(){
		if(story==null)		story = GameObject.Find("StoryButton");
		if(battle==null)	battle = GameObject.Find("BattleButton");
		if(option==null)	option = GameObject.Find("OptionButton");
		Image storyImg 		=	story.GetComponent	<Image>	();
		Image battleImg 	=	battle.GetComponent	<Image>	();
		Image optionImg 	=	option.GetComponent	<Image>	();
		Button_State nowstate =	Button_State.get_Instance;
		if (nowstate.checkStory ()) {
			storyImg.sprite = makeSprite (SELECTED_STORY_IMG_PATH);
			battleImg.sprite	=	makeSprite (BATTLE_IMG_PATH);
			optionImg.sprite	=	makeSprite (OPTION_IMG_PATH);
		}
		else if(nowstate.checkBattle()){
			storyImg.sprite		= 	makeSprite (STORY_IMG_PATH);
			battleImg.sprite	=	makeSprite (SELECTED_BATTLE_IMG_PATH);
			optionImg.sprite	=	makeSprite (OPTION_IMG_PATH);
		}
		else if(nowstate.checkOption()){
			storyImg.sprite		= 	makeSprite (STORY_IMG_PATH);
			battleImg.sprite	=	makeSprite (BATTLE_IMG_PATH);
			optionImg.sprite	=	makeSprite (SELECTED_OPTION_IMG_PATH);
		}
	}

	/*Sprite生成処理*/
	private Sprite makeSprite(string path){
		Texture2D img = Resources.Load (path)	as Texture2D;
		return Sprite.Create (img,new Rect(0,0,img.width,img.height),Vector2.zero);
	}
}