using UnityEngine;
public class Animation_Manager : MonoBehaviour{
	private const 	string FIRST_ANIM	=	"1P/C_Man";
	private const 	string SECOND_ANIM	=	"2P/Syatyo";


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
	private Animation_Interface secondanim;
	public 	Animation_Interface second{
		get{
			if (secondanim == null)
				secondanim = GameObject.Find (SECOND_ANIM).GetComponent<Animation_Interface> ();
			return secondanim;
		}
	}
	private void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}
}
