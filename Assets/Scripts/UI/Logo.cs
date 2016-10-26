using UnityEngine;
using System.Collections;

public class Logo: MonoBehaviour {
	private static Logo instance;
	private bool isvisible = true;
	public static Logo getInstance{
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
	public void notVisible(){
		isvisible = false;
		this.gameObject.SetActive (isvisible);
	}
	public bool getVisible{
		get{
			return isvisible;
		}
	}
}
