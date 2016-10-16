using UnityEngine;
using System.Collections;

public class Title_Scene : Scene_Interface {

	public Title_Scene(App_Controller manager):base(manager){
	}

	public override void start ()
	{
	}

	public override void update ()
	{
	}

	public override void nextScene ()
	{
		this.manager.nowScene = new Menu_Scene (this.manager);
	}
		
	public override void onClick ()
	{
		nextScene ();
	}
}
