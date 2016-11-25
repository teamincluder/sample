using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/* angelを勝敗数と紐づける */
public class Battle_Win : MonoBehaviour {
	private const	string ANGEL_PATH1 = "Canvas/angel1/win";
	private const	string ANGEL_PATH2 = "Canvas/angel2/win";

	private Image angel1_1 = GameObject.Find(ANGEL_PATH1 + "1_1").GetComponent<Image>();
	private Image angel1_2 = GameObject.Find(ANGEL_PATH1 + "1_2").GetComponent<Image>();
	private Image angel1_3 = GameObject.Find(ANGEL_PATH1 + "1_3").GetComponent<Image>();
	private Image angel2_1 = GameObject.Find(ANGEL_PATH2 + "2_1").GetComponent<Image>();
	private Image angel2_2 = GameObject.Find(ANGEL_PATH2 + "2_2").GetComponent<Image>();
	private Image angel2_3 = GameObject.Find(ANGEL_PATH2 + "2_3").GetComponent<Image>();

	private void Awake(){
		
	}
}
