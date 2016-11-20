using UnityEngine;
using System.Collections;
/*コミットされてない疑惑*/
public abstract class Scene_Interface {
	protected Scene_Controll_Interface state;
	public Scene_Interface (Scene_Controll_Interface state){
		this.state = state;
	}
	public abstract void start();
	public abstract void update ();
	public abstract void nextScene();
	public abstract void onClick();
}
