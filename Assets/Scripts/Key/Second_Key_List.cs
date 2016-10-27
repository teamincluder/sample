using UnityEngine;

public class Second_Key_List :Key_Interface{ 
	public Second_Key_List(bool isdebug = false){
		if (!isdebug) {
			left_Key 	= KeyCode.JoystickButton14;
			up_Key	 	= KeyCode.JoystickButton15;
			down_Key 	= KeyCode.JoystickButton16;
			right_Key 	= KeyCode.JoystickButton13;
			jab_Key 	= KeyCode.JoystickButton1;
			guard_Key 	= KeyCode.JoystickButton3;
			jump_Key 	= KeyCode.JoystickButton2;
			strong_Key 	= KeyCode.JoystickButton0;
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
