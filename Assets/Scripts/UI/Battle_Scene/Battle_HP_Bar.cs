using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Battle_HP_Bar : MonoBehaviour {
	/*Imgパス*/
	private const string FIRST_HP_PATH		=	"Canvas/HP_bar1/hp_bar";
	private const string SECOND_HP_PATH		=	"Canvas/HP_bar2/hp_bar";

	/*img*/
	private Image firstimg;
	private Image secondimg;

	void Awake(){
		firstimg	= GameObject.Find (FIRST_HP_PATH).GetComponent<Image> ();
		secondimg 	= GameObject.Find (SECOND_HP_PATH).GetComponent<Image> ();
	}

	public void firstImgDraw(float result){
		firstimg.fillAmount = ( result / 100 );
	}

	public void secondImgDraw(float result){
		secondimg.fillAmount = ( result / 100 );
	}
}
