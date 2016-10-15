using UnityEngine;
using System.Collections;

public class KeyList { 
	/*Key Settings*/
	public KeyCode LeftKey	 	= new KeyCode();
	public KeyCode UpKey		= new KeyCode();
	public KeyCode DownKey 		= new KeyCode();
	public KeyCode RightKey		= new KeyCode();
	public KeyCode JabKey 		= new KeyCode();
	public KeyCode GuardKey		= new KeyCode();
	public KeyCode JumpKey 		= new KeyCode();
	public KeyCode StrongKey	= new KeyCode();

	public void Init(bool isDebug = false){
		if (!isDebug) {
			LeftKey 	= KeyCode.JoystickButton14;
			UpKey	 	= KeyCode.JoystickButton15;
			DownKey 	= KeyCode.JoystickButton16;
			RightKey 	= KeyCode.JoystickButton13;
			JabKey 		= KeyCode.JoystickButton1;
			GuardKey 	= KeyCode.JoystickButton3;
			JumpKey 	= KeyCode.JoystickButton2;
			StrongKey 	= KeyCode.JoystickButton0;
		} else {
			LeftKey 	= KeyCode.A;
			UpKey 		= KeyCode.W;
			RightKey 	= KeyCode.D;
			DownKey 	= KeyCode.S;
			JabKey 		= KeyCode.J;
			GuardKey	= KeyCode.K;
			JumpKey 	= KeyCode.L;
			StrongKey 	= KeyCode.H;
		}
	}
}
