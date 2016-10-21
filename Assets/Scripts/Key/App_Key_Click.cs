using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
public class App_Key_Click : MonoBehaviour {
	void Start () {
		App_Controller manager = App_Controller.getInstance;
		this.UpdateAsObservable ()
			.Where (_ => Input.anyKeyDown)
			.Subscribe (_=>manager.onClick());
	}

}
