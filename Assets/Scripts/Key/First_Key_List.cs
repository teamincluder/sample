using UnityEngine;
public class First_Key_List : Key_Interface{ 
	public First_Key_List(bool isdebug = true){
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
			left_Key 	= KeyCode.A;
			up_Key 		= KeyCode.W;
			right_Key 	= KeyCode.D;
			down_Key 	= KeyCode.S;
			jab_Key 	= KeyCode.J;
			guard_Key	= KeyCode.K;
			jump_Key 	= KeyCode.L;
			strong_Key 	= KeyCode.H;
		}
	}
}
