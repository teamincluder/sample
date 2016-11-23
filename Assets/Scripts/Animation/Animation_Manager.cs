using UnityEngine;
public class Animation_Manager : MonoBehaviour{
	private const 	string FIRST_ANIM	=	"1P/C_Man";


	private static 	Animation_Manager instance;
	public	static 	Animation_Manager get_Instance{
		get{
			return instance;
		}
	}

	private Animation_Interface firstanim;
	public 	Animation_Interface first{
		get{
			if (firstanim == null)
				firstanim = GameObject.Find (FIRST_ANIM).GetComponent<Animation_Interface> ();
			return firstanim;
		}
	}

	private void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}
}
