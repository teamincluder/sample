public class Title_Scene : Scene_Interface {
	public Title_Scene (Scene_Controll_Interface state):base(state){
	}
	public override void start ()
	{
		Menu_UI_Controller.get_Instance.titleScene ();
	}

	public override void update(){
	}

	public override void nextScene ()
	{

		this.state.changeState (new Menu_Scene(this.state));
	}
		
	public override void onClick ()
	{
		//if(Logo.getInstance.getVisible == false)
			nextScene ();
	}
}
