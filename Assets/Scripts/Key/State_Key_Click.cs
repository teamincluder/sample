using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
public class State_Key_Click : MonoBehaviour {


	void Start () {
		State_Manager manager = State_Manager.getInstance;
		this.UpdateAsObservable ()
			.Where (_ => Input.anyKeyDown )
			.Subscribe (_=>manager.onClick());
	}

}
