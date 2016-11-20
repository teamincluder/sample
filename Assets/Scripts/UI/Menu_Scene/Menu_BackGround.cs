using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu_BackGround : MonoBehaviour {
	private const string BACKGROUND_PATH = "Canvas/Title_UI/BackGround";
	private const string TITLE_LOGO_PATH = "Canvas/Title_UI/Title_img";

	private Image background;
	private GameObject logo;

	public void changeBg(string imgpath){
		if(background==null) background = GameObject.Find(BACKGROUND_PATH).GetComponent<Image> ();
		Texture2D newimg = Resources.Load (imgpath) as Texture2D;
		background.sprite = Sprite.Create(newimg , new Rect(0,0,newimg.width,newimg.height) , Vector2.zero); 
	}

	public void logoVisible(bool result){
		if(logo == null) logo = GameObject.Find(TITLE_LOGO_PATH);
		logo.SetActive (result);
	}
}