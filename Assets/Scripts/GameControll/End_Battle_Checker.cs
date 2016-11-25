using UnityEngine;
public class End_Battle_Checker {
	
	private static End_Battle_Checker instance =null;
	private bool isend 		=	false;
	private bool firstwin1;

	public static End_Battle_Checker get_Instance{
		get{
			if (instance == null)
				instance = new End_Battle_Checker ();
			return instance;
		}
	}
	public void exit(){
		instance = null;
	}

	public bool isEnd{
		get{
			return isend;
		}
		set{
			isend = value;
		}
	}
	public bool is_First_Win{
		get{
			Debug.Log ("getter:"+firstwin1);
			return firstwin1;
		}
		set{
			firstwin1 = value;
			Debug.Log ("is_First_Win:" + value);
			Battle_Win.get_Instance.DicisionWin (firstwin1);
			Battle_UI_Controller.get_Instance.endBattleScene (firstwin1);

			if (firstwin1) {
				Audio_Manager.get_Instance.first_Audio.win ();
			} 
			else {
				Audio_Manager.get_Instance.first_Audio.lose ();
			}
		}
	}
}
