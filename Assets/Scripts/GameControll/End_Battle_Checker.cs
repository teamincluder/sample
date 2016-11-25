public class End_Battle_Checker {
	
	private static End_Battle_Checker instance =null;
	private bool isend 		=	false;
	private bool firstwin	=	false;

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
		set{
			firstwin = value;
			Battle_Win.get_Instance.DicisionWin (firstwin);
			if (firstwin) {
				Audio_Manager.get_Instance.first_Audio.win ();
			} 
			else {
				Audio_Manager.get_Instance.first_Audio.lose ();
			}
		}
	}
}
