using UnityEngine;
using UnityEngine.UI;
public class Menu_Scene : Scene_Interface {
	public Menu_Scene(App_Controller manager):base(manager){
	}
	
	public override void start ()
	{
	}
	
	public override void update ()
	{
			
	}
	
	public override void nextScene ()
	{
		this.manager.nowScene = new Battle_Scene (this.manager);
		this.manager.nextScene ("Battle");
	}

	public override void onClick ()
	{
		nextScene ();
	}
}