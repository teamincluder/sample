public class End_Battle_Checker {
	
	private static End_Battle_Checker instance =null;
	private bool isend = false;

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

}
