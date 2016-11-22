using UnityEngine;
using System.Collections;

public class Audio_Controller : MonoBehaviour {
	private const string FIRST_AUDIO 	= 	"1P";

	private const string C_MAN_PATH 	=	"AUDIO/c_man_audio";

	private Audio_Interface firstaudio;

	private static Audio_Controller instance;

	public static Audio_Controller get_Instance{
		get{
			return instance;
		}
	}

	private void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
		
		firstaudio = makeObj (FIRST_AUDIO,C_MAN_PATH);
		Debug.Log (firstaudio);
	}

	public void firstStart(){
		firstaudio.start ();
	}
	public void firstJab(){
		firstaudio.jab ();
	}
	public void firstStrong(){
		firstaudio.strong ();
	}
	public void firstWin(){
		firstaudio.win ();
	}
	public void firstLose(){
		firstaudio.lose ();
	}

	private Audio_Interface makeObj(string parent,string charactor){
		GameObject parentObj 		=	GameObject.Find (parent);
		GameObject data				=	Resources.Load (charactor) as GameObject;
		GameObject charaAudio 		=	(GameObject)Instantiate (data,Vector3.zero,Quaternion.Euler(Vector3.zero));
		charaAudio.transform.parent	=	parentObj.transform;
		return charaAudio.GetComponent<Audio_Interface> ();
	}
}
