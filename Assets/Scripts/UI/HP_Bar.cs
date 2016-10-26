using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HP_Bar : MonoBehaviour {
	private const string ENEMY_HP_PATH = "Canvas/HP_bar2/hp_bar";
	private float hp = 100;
	[SerializeField]
	private Image hpImg;
	/*弱攻撃＝5ダメ*/
	public void init(){
		hpImg = GameObject.Find (ENEMY_HP_PATH).GetComponent<Image> ();
	}
	public void jab(){
		hp -= 5f;
		draw ();
	}
	/*強攻撃＝10ダメ*/
	public void strong(){
		hp -= 10f;
		draw ();
	}
	/*必殺技＝30ダメ*/
	public void deathBlow(){
		hp -= 30f;
		draw ();
	}
	public void draw(){
		hpImg.fillAmount = (hp / 100f);
	}
}