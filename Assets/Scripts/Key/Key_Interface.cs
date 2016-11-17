using UnityEngine;
/*
	Key配列のリスト
	初期化や設定読み込みは子クラスが実行する
*/
public abstract class Key_Interface{
	protected KeyCode leftkey	= new KeyCode();
	protected KeyCode upkey		= new KeyCode();
	protected KeyCode downkey 	= new KeyCode();
	protected KeyCode rightkey	= new KeyCode();
	protected KeyCode jabkey 	= new KeyCode();
	protected KeyCode guardkey	= new KeyCode();
	protected KeyCode jumpkey 	= new KeyCode();
	protected KeyCode strongkey	= new KeyCode();

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
}
