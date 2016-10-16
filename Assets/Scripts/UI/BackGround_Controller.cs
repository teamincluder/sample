using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BackGround_Controller : MonoBehaviour {
	Image background;
	void Awake(){
		background = GameObject.Find("BackGround").GetComponent<Image> ();
	}

	public void changeBg(string imgpath){
		Debug.Log (imgpath);
		var newimg = Resources.Load (imgpath) as Sprite;
		background.sprite = newimg; 
	}
}