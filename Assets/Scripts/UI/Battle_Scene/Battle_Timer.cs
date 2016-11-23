using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Battle_Timer : MonoBehaviour {
	private const string TIMER_PATH	=	"Canvas/Timer/time_text";

	private bool 	ismain 		= false;
	private float	time;
	private Text	timetext;

	private void Awake(){
		if (timetext == null)
			timetext = GameObject.Find (TIMER_PATH).GetComponent<Text> ();
		StartCoroutine (countTime ());
	}

	private IEnumerator countTime(){
		while(true){
			if (ismain) {
				time--;
				timetext.text	=	time.ToString ();
				if (time <= 0)
					End_Battle_Checker.get_Instance.isEnd = true;
			}
			yield return new WaitForSeconds (1f);
		}
	}
	public void setTime(int battletime){
		time = (float)battletime;
		timetext.text	=	time.ToString ();
	}
	public void isMain(bool result){
		ismain = result;
	}
}
