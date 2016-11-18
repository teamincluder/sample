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

	/*ガード*/
	private const float GUARD 				=	3f;
	private bool		isfirstguard		=	false;
	private bool		issecondguard		=	false;
	/*ライフ*/
	private float firsthp 	= 100f;
	private float secondhp	= 100f;

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

	public void firstGuard(){
		isfirstguard = true;
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

	public void secondGuard(){
		issecondguard = true;
	}


	private void draw(user playing,float damage){
		if (playing == user.first) {
			if (issecondguard)
				damage -= GUARD;
			issecondguard = false;
			secondhp -= damage;
			hpbar.secondImgDraw (secondhp);
			if (secondhp <= 0) {
				End_Battle_Checker.getInstance.isEnd = true;
			}
		} 
		else if(playing == user.second){
			if (isfirstguard)
				damage -= GUARD;
			isfirstguard = false;
			firsthp -= damage;
			hpbar.firstImgDraw (firsthp);
			if (firsthp <= 0) {
				End_Battle_Checker.getInstance.isEnd = true;
			}
		}
	}
}