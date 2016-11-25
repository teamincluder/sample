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

	private Image[] angel1;
	private Image[] angel2;

	public Battle_Win(){
		angel1[0] = GameObject.Find(ANGEL_PATH1 + "1_1").GetComponent<Image>();
		angel1[1] = GameObject.Find(ANGEL_PATH1 + "1_2").GetComponent<Image>();
		angel1[2] = GameObject.Find(ANGEL_PATH1 + "1_3").GetComponent<Image>();
		angel2[0] = GameObject.Find(ANGEL_PATH2 + "2_1").GetComponent<Image>();
		angel2[1] = GameObject.Find(ANGEL_PATH2 + "2_2").GetComponent<Image>();
		angel2[2] = GameObject.Find(ANGEL_PATH2 + "2_3").GetComponent<Image>();
		angel1 [0].gameObject.SetActive(false);
		angel1 [1].gameObject.SetActive(false);
		angel1 [2].gameObject.SetActive(false);
		angel2 [0].gameObject.SetActive(false);
		angel2 [1].gameObject.SetActive(false);
		angel2 [2].gameObject.SetActive(false);
	}
	/*どっちが勝ったか送るとAngelの数が変わる*/
	private void DicisionWin(bool winFlug){
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

}
