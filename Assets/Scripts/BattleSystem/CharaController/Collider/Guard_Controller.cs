using UnityEngine;

public class Guard_Controller : MonoBehaviour {
	public void isVisible(bool result){
		this.gameObject.SetActive (result);
	}
	public void init(bool isfirst){
		if (isfirst)
			this.gameObject.tag = TagList.getInstance.firstGuardTag;
		else
			this.gameObject.tag = TagList.getInstance.secondGuardTag;
		this.isVisible (false);
	}
}
