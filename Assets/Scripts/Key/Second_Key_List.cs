using UnityEngine;

public class Second_Key_List :Key_Interface{ 
	public Second_Key_List(){
		bool isdebug = true;
		if (!isdebug) {
			left_Key 	= KeyCode.LeftArrow;
			up_Key 		= KeyCode.UpArrow;
			right_Key 	= KeyCode.RightArrow;
			down_Key 	= KeyCode.DownArrow;
			jab_Key 	= KeyCode.U;
			guard_Key	= KeyCode.I;
			jump_Key 	= KeyCode.O;
			strong_Key 	= KeyCode.Y;
		} else {
			left_Key 	= KeyCode.LeftArrow;
			up_Key 		= KeyCode.UpArrow;
			right_Key 	= KeyCode.RightArrow;
			down_Key 	= KeyCode.DownArrow;
			jab_Key 	= KeyCode.U;
			guard_Key	= KeyCode.I;
			jump_Key 	= KeyCode.O;
			strong_Key 	= KeyCode.Y;
		}
	}
}
