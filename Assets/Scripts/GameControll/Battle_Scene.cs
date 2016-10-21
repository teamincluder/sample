public class Battle_Scene : Scene_Interface {

	public Battle_Scene(App_Controller manager):base(manager){
	}

	public override void start ()
	{
		UI_Controller.getInstance.startBattleScene ();
	}
	public override void nextScene ()
	{
	}
	public override void onClick ()
	{
		nextScene ();
	}
}
