using UnityEngine;
using System.Collections;

public class Audio_Manager : MonoBehaviour {
	private const string FIRST_AUDIO 	= 	"1P";

	private const string C_MAN_PATH 	=	"AUDIO/c_man_audio";

	private Audio_Interface firstaudio;

	private static Audio_Manager instance;

	public static Audio_Manager get_Instance{
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
	}

	public Audio_Interface first_Audio{
		get{
			return firstaudio;
		}
	}

	private Audio_Interface makeObj(string parent,string charactor){
		GameObject parentObj 		=	GameObject.Find (parent);
		GameObject data				=	Resources.Load (charactor) as GameObject;
		GameObject charaAudio 		=	(GameObject)Instantiate (data,Vector3.zero,Quaternion.Euler(Vector3.zero));
		charaAudio.transform.parent	=	parentObj.transform;
		return charaAudio.GetComponent<Audio_Interface> ();
	}
}
