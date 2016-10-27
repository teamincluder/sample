using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu_BackGround : MonoBehaviour {
	private const string BACKGROUND_PATH = "Canvas/BackGround";
	private Image background;

	public void changeBg(string imgpath){
		if(background==null) background = GameObject.Find(BACKGROUND_PATH).GetComponent<Image> ();
		Texture2D newimg = Resources.Load (imgpath) as Texture2D;
		background.sprite = Sprite.Create(newimg , new Rect(0,0,newimg.width,newimg.height) , Vector2.zero); 
	}
}