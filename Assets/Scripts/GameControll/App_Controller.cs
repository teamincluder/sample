﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class App_Controller : MonoBehaviour {
	private const int FRAMERATE = 60;

	private static App_Controller instance;
	public static App_Controller get_Instance{
		get{
			return App_Controller.instance;
		}
	}

	private Scene_Controll_Interface nowScene;

	//シングルトン
	void Awake(){
		Application.targetFrameRate = FRAMERATE;
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}


	void Start () {
		DontDestroyOnLoad (this);
		nowScene = this.gameObject.AddComponent<Scene_Controll_Interface> ();
		nowScene.changeState(new Title_Scene(this.nowScene));
		nowScene.nowSceneStart ();
		this.UpdateAsObservable()
			.Where(_ => Input.GetKeyDown(KeyCode.Escape))
			.Subscribe(_=>
				{
					Application.Quit();
				});
	}

	void Update(){
		nowScene.nowSceneUpdate ();
	}
}
