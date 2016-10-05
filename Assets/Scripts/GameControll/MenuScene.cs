using UnityEngine;
using UnityEngine.UI;
public class MenuScene : SceneInterface {
	public MenuScene(AppControll manager):base(manager){
	}
	
	public override void Start ()
	{
	}
	
	public override void Update ()
	{
		if (Input.anyKeyDown)
			Next_Scene ();
	}
	
	public override void Next_Scene ()
	{
		this.manager.nowScene = new BattleScene (this.manager);
		this.manager.Next_Scene ("Battle");
	}
}