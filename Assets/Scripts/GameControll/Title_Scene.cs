public class Title_Scene : Scene_Interface {
	public Title_Scene(App_Controller manager):base(manager){
	}

	public override void start ()
	{
		Menu_UI_Controller.getInstance.titleScene ();
	}

	public override void nextScene ()
	{
		this.manager.nextScene (new Menu_Scene(this.manager));
	}
		
	public override void onClick ()
	{
		//if(Logo.getInstance.getVisible == false)
			nextScene ();
	}
}
