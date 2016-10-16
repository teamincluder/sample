using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
public class Key_Click : MonoBehaviour {
	App_Controller manager;
	void Start () {
		manager = this.GetComponent<App_Controller> ();
		var anykey =	this.UpdateAsObservable ()
							.Where (_ => Input.anyKeyDown)
							.Subscribe (_=>this.manager.onClick());
	}

}
