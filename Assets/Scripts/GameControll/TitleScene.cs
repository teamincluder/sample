using UnityEngine;
using System.Collections;

public class TitleScene : SceneInterface {

	public TitleScene(AppControll manager):base(manager){
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
		this.manager.nowScene = new MenuScene (this.manager);
		this.manager.Next_Scene ("Menu");
	}
}
