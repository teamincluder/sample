public class End_Battle_Checker {
	
	private static End_Battle_Checker instance =null;
	private bool isend = false;

	public static End_Battle_Checker getInstance{
		get{
			if (instance == null)
				instance = new End_Battle_Checker ();
			return instance;
		}
	}

	public bool isEnd{
		get{
			return isend;
		}
		set{
			isend = value;
			if (isend) {
				//Scene_Controll_Interface.get_Instance.changeState (new End_Battle_Scene ());
				instance = null;
			}
		}
	}

}
