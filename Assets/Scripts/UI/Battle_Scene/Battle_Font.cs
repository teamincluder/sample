using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Battle_Font : MonoBehaviour {
	private const string FIRST_FONT_PATH 	= 	"Canvas/first_result";
	private const string SECOND_FONT_PATH	=	"Canvas/second_result";

	private const string WIN_MESSAGE 		=	"Win";
	private const string LOSE_MESSAGE 		=	"Lose";
	GameObject firstresult;
	GameObject secondresult;
	public void isVisible(bool active){
		if (firstresult == null)	firstresult = GameObject.Find(FIRST_FONT_PATH);
		if (secondresult == null)	secondresult = GameObject.Find(SECOND_FONT_PATH);
		firstresult.SetActive(active);
		secondresult.SetActive (active);

	}
	public void setMessage(bool firstwin){
		Debug.Log ("setmessage:" + firstwin);
		Text tex1 = firstresult.GetComponent<Text> ();
		Text tex2 = secondresult.GetComponent<Text> ();
		if (firstwin) {
			tex1.text = "1P" + WIN_MESSAGE;
			tex2.text = "2P" + LOSE_MESSAGE;
		}
		else {
			tex1.text = "1P" + LOSE_MESSAGE;
			tex2.text = "2P" + WIN_MESSAGE;
		}

	}
}
