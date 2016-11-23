using UnityEngine;

public class Guard_Controller : MonoBehaviour {
	private bool isvisible 	= false;
	private	static Guard_Controller instance;  

	public static Guard_Controller get_Instance{
		get{
			return instance;
		}
	}
	private void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}

	public void isVisible(bool result){
		isvisible = result;
		this.gameObject.SetActive (result);
	}
	public bool is_Visible{
		get{
			return isvisible;
		}
	}

	public void init(bool isfirst){
		if (isfirst)
			this.gameObject.tag = TagList.getInstance.firstGuardTag;
		else
			this.gameObject.tag = TagList.getInstance.secondGuardTag;
		this.isVisible (false);
	}
}