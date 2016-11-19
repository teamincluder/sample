using UnityEngine;
using System.Collections;
/*コミットされてない疑惑*/
public abstract class Scene_Interface {
	protected App_Controller manager;
	public Scene_Interface(App_Controller manager){
		this.manager = manager;
	}
	public abstract void start();
	public abstract void nextScene();
	public abstract void onClick();
}
