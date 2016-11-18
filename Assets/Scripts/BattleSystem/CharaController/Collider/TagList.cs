public class TagList {
	private const string FIRST_USER_TAG		= 	"first";
	private const string SECOND_USER_TAG 	= 	"second";
	private const string FIRST_GUARD_TAG	=	"first_guard";
	private const string SECOND_GUARD_TAG	=	"second_guard";
	private static TagList instance = new TagList ();
	public static TagList getInstance{
		get{
			if (instance == null)
				instance = new TagList ();
			return instance;
		}
	}
	public string firstTag{
		get{
			return FIRST_USER_TAG;
		}
	}
	public string secondTag{
		get{
			return SECOND_USER_TAG;
		}
	}
	public string firstGuardTag{
		get{
			return FIRST_GUARD_TAG;
		}
	}
	public string secondGuardTag{
		get{
			return SECOND_GUARD_TAG;
		}
	}

}
