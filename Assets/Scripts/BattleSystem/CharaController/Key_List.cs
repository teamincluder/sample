using UnityEngine;
using System.Collections;

public class Key_List { 
	/*Key Settings*/
	public KeyCode leftkey	 	= new KeyCode();
	public KeyCode upkey		= new KeyCode();
	public KeyCode downkey 		= new KeyCode();
	public KeyCode rightkey		= new KeyCode();
	public KeyCode jabkey 		= new KeyCode();
	public KeyCode guardkey		= new KeyCode();
	public KeyCode jumpkey 		= new KeyCode();
	public KeyCode strongkey	= new KeyCode();

	public void init(bool isdebug = false){
		if (!isdebug) {
			leftkey 	= KeyCode.JoystickButton14;
			upkey	 	= KeyCode.JoystickButton15;
			downkey 	= KeyCode.JoystickButton16;
			rightkey 	= KeyCode.JoystickButton13;
			jabkey 		= KeyCode.JoystickButton1;
			guardkey 	= KeyCode.JoystickButton3;
			jumpkey 	= KeyCode.JoystickButton2;
			strongkey 	= KeyCode.JoystickButton0;
		} else {
			leftkey 	= KeyCode.A;
			upkey 		= KeyCode.W;
			rightkey 	= KeyCode.D;
			downkey 	= KeyCode.S;
			jabkey 		= KeyCode.J;
			guardkey	= KeyCode.K;
			jumpkey 	= KeyCode.L;
			strongkey 	= KeyCode.H;
		}
	}
}
