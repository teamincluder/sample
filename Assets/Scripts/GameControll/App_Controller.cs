﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;

[RequireComponent(typeof(App_Key_Click))]
public class App_Controller : MonoBehaviour {
	
	private static App_Controller instance;
	private Scene_Interface nowScene;

	public static App_Controller getInstance{
		get{
			return App_Controller.instance;
		}
	}
	//シングルトン
	void Awake(){
		if (instance == null)	instance = this;
		else 					Destroy (this.gameObject);
		Application.targetFrameRate = 60;
	}


	void Start () {
		DontDestroyOnLoad (this);
		nowScene = new Title_Scene (App_Controller.getInstance);
		nowScene.start ();
	}

	public void nextScene(Scene_Interface nextscene,string nextstr = ""){
		this.nowScene = nextscene;
		if (nextstr != "") {
			SceneManager.LoadScene (nextstr);
			StartCoroutine (nextFrame ());
		} 
		else {
			nowScene.start ();
		}
	}
	private IEnumerator nextFrame(){
		yield return null;
		nowScene.start ();
	}
	public void onClick(){
		nowScene.onClick ();
	}
}