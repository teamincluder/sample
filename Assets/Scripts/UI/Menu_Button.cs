using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
public class Menu_Button : MonoBehaviour {
	GameObject story;
	GameObject battle;
	GameObject option;

	public void isVisible(bool visible){
		if(story==null)		story = GameObject.Find("StoryButton");
		if(battle==null)	battle = GameObject.Find("BattleButton");
		if(option==null)	option = GameObject.Find("OptionButton");
		story.SetActive (visible);
		battle.SetActive (visible);
		option.SetActive (visible);
	}
	private void subscribe(GameObject obj){
		Button button = obj.GetComponent<Button>();
	}
}
