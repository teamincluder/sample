using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BackGround_Controller : MonoBehaviour {
	private Image background;

	public void changeBg(string imgpath){
		if(background==null) background = GameObject.Find("BackGround").GetComponent<Image> ();
		Texture2D newimg = Resources.Load (imgpath) as Texture2D;
		background.sprite = Sprite.Create(newimg , new Rect(0,0,newimg.width,newimg.height) , Vector2.zero); 
	}
}