using UnityEngine;
using System.Collections;

public class Second_Key_List { 
	/*Key Settings*/
	private KeyCode leftkey	 	= new KeyCode();
	private KeyCode upkey		= new KeyCode();
	private KeyCode downkey 	= new KeyCode();
	private KeyCode rightkey	= new KeyCode();
	private KeyCode jabkey 		= new KeyCode();
	private KeyCode guardkey	= new KeyCode();
	private KeyCode jumpkey 	= new KeyCode();
	private KeyCode strongkey	= new KeyCode();

	public KeyCode left_Key{
		get{
			return leftkey;
		}
		set{
			leftkey = value;
		}
	}
	public KeyCode right_Key{
		get{
			return rightkey;
		}
		set{
			rightkey = value;
		}
	}
	public KeyCode up_Key{
		get{
			return upkey;
		}
		set{
			upkey = value;
		}
	}
	public KeyCode down_Key{
		get{
			return downkey;
		}
		set{
			downkey = value;
		}
	}
	public KeyCode jab_Key{
		get{
			return jabkey;
		}
		set{
			jabkey = value;
		}
	}
	public KeyCode strong_Key{
		get{
			return strongkey;
		}
		set{
			strongkey = value;
		}
	}
	public KeyCode jump_Key{
		get{
			return jumpkey;
		}
		set{
			jumpkey = value;
		}
	}
	public KeyCode guard_Key{
		get{
			return guardkey;
		}
		set{
			guardkey = value;
		}
	}

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
