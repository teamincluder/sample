using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Battle_HP_Bar))]
public class HP_Controller : MonoBehaviour {
	private static HP_Controller instance;
	public static HP_Controller getInstance{
		get{ 
			return instance;
		}
	}
	/*リザルトメッセージ*/
	private const string FIRST_WIN_MESSAGE 		=	"1P win!";
	private const string SECOND_WIN_MESSAGE 	=	"2P win!";

	/*ダメージ*/
	private const float	DAMAGE_JAB 			=	5f;
	private const float DAMAGE_STRONG		=	10f;
	private const float DAMAGE_DEATHBLOW	=	20f;

	/*ライフ*/
	private float firsthp 	= 100;
	private float secondhp	= 100;

	/*UI*/
	private Battle_HP_Bar hpbar;

	/*リスト*/
	private enum user{first,second};

	public void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this);

		hpbar = this.GetComponent<Battle_HP_Bar> ();
	}

	public void firstJab(){
		draw (user.first,DAMAGE_JAB);
	}

	public void firstStrong(){
		draw (user.first,DAMAGE_STRONG);
	}

	public void firstDeathBlow(){
		draw (user.first,DAMAGE_DEATHBLOW);
	}

	public void secondJab(){
		draw (user.second,DAMAGE_JAB);
	}

	public void secondStrong(){
		draw (user.second, DAMAGE_STRONG);
	}

	public void secondDeathBlow(){
		draw (user.second,DAMAGE_DEATHBLOW);
	}


	private void draw(user playing,float damage){
		if (playing == user.first) {
			secondhp -= damage;
			hpbar.secondImgDraw (secondhp);
			if (secondhp <= 0) {
				App_Controller.getInstance.nextScene (new End_Battle_Scene(App_Controller.getInstance));
			}
		} 
		else if(playing == user.second){
			firsthp -= damage;
			hpbar.firstImgDraw (firsthp);
			if (firsthp <= 0) {
				App_Controller.getInstance.nextScene (new End_Battle_Scene(App_Controller.getInstance));
			}
		}
	}
}