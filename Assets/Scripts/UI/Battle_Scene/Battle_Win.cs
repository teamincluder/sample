using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Sprites;

/* angelを勝敗数と紐づける */
/*画像の切り替え*/
public class Battle_Win {

	private const	string 	ANGEL_PATH1 = "Canvas/angel1/win";
	private const	string 	ANGEL_PATH2 = "Canvas/angel2/win";
	private const 	int WINUPPER	= 4;

	/*テスト定数　どちらが勝ったか*/
	private const bool WINPLAYER 	= true;
	private const bool WINCPU 		= false;

	/* 勝ち数 */
	private int win1 = 0;
	private int win2 = 0;

	private Image[] angel1 = new Image[3];
	private Image[] angel2 = new Image[3];

	private static Battle_Win instance;
	public static Battle_Win get_Instance{
		get{
			if (instance == null)
				instance = new Battle_Win ();
			return instance;
		}
	}

	public void init(){
		Debug.Log (ANGEL_PATH1+"1_1");
		angel1[0] = GameObject.Find(ANGEL_PATH1 + "1_1").GetComponent<Image>();
		angel1[1] = GameObject.Find(ANGEL_PATH1 + "1_2").GetComponent<Image>();
		angel1[2] = GameObject.Find(ANGEL_PATH1 + "1_3").GetComponent<Image>();
		angel2[0] = GameObject.Find(ANGEL_PATH2 + "1_1").GetComponent<Image>();
		angel2[1] = GameObject.Find(ANGEL_PATH2 + "1_2").GetComponent<Image>();
		angel2[2] = GameObject.Find(ANGEL_PATH2 + "1_3").GetComponent<Image>();
		angel1 [0].gameObject.SetActive(false);
		angel1 [1].gameObject.SetActive(false);
		angel1 [2].gameObject.SetActive(false);
		angel2 [0].gameObject.SetActive(false);
		angel2 [1].gameObject.SetActive(false);
		angel2 [2].gameObject.SetActive(false);
		drawAngel ();
	}
	/*どっちが勝ったか送るとAngelの数が変わる*/
	public void DicisionWin(bool winFlug){
		if (WINPLAYER == winFlug) {
			win1++;
			AddAngel (win1, winFlug);
		} else if (WINCPU == winFlug) {
			win2++;
			AddAngel (win2, winFlug);
		}
	}
	private void AddAngel(int win, bool winFlug){
		if (WINUPPER > win) {
			if (WINPLAYER == winFlug) {
				angel1 [win - 1].gameObject.SetActive(true);
			} else if (WINCPU == winFlug) {
				angel2 [win - 1].gameObject.SetActive(true);
			}
		}
	}
	private void drawAngel(){
		for (int i = 0; i < win1; i++) {
			angel1 [i].gameObject.SetActive (true);
		}
		for (int j = 0; j < win2; j++) {
			angel2 [j].gameObject.SetActive (true);
		}
	}
	public void exit(){
		instance = null;
	}

}
