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
	private const float GUARD 				=	10f;

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

	public void firstJab(bool isGuard){
		draw (user.first,DAMAGE_JAB,isGuard);
	}

	public void firstStrong(bool isGuard){
		draw (user.first,DAMAGE_STRONG,isGuard);
	}

	public void firstDeathBlow(bool isGuard){
		draw (user.first,DAMAGE_DEATHBLOW,isGuard);
	}

	public void secondJab(bool isGuard){
		draw (user.second,DAMAGE_JAB,isGuard);
	}

	public void secondStrong(bool isGuard){
		draw (user.second, DAMAGE_STRONG,isGuard);
	}

	public void secondDeathBlow(bool isGuard){
		draw (user.second,DAMAGE_DEATHBLOW,isGuard);
	}

	private void draw(user playing,float damage,bool isGuard){
		if (playing == user.first) {
			secondhp	-= damageCalc (damage, isGuard);
		}
		else if (playing == user.second) {
			firsthp -= damageCalc (damage, isGuard);
			if(!isGuard)
				Audio_Manager.get_Instance.first_Audio.damage ();
		}
		this.checkEnd ();
		hpbar.lifeDraw (firsthp,secondhp);
	}

	private float damageCalc(float damage,bool isGuard){
		float result = damage;
		if (isGuard) {
			if (GUARD <= damage)
				result -= GUARD;
			else
				result = 0;
		}
		return result;
	}

	private void checkEnd(){
		if (firsthp <= 0 && secondhp <= 0) {
			End_Battle_Checker.get_Instance.isEnd = true;
		}
		else if (secondhp <= 0) {
			End_Battle_Checker.get_Instance.is_First_Win = true;
			End_Battle_Checker.get_Instance.isEnd = true;
		} 
		else if (firsthp <= 0) {
			End_Battle_Checker.get_Instance.is_First_Win	= false;
			End_Battle_Checker.get_Instance.isEnd 			= true;
		}
	}


}