using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Battle_Font : MonoBehaviour {
	GameObject result;

	public void isVisible(bool active){
		if (result == null)	result = GameObject.Find("Result");
		result.SetActive(active);
	}
	public void setMessage(string message){
		Text tex = result.GetComponent<Text> ();
		tex.text = message;
	}
}
