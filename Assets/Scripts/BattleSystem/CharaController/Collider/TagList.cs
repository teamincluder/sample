public class TagList {
	private const string FIRST_USER_TAG		= "first";
	private const string SECOND_USER_TAG 	= "second";
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

}
