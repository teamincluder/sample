using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;

[RequireComponent(typeof(Key_Click))]

public class App_Controller : MonoBehaviour {
	private static App_Controller instance = null;
	public Scene_Interface nowScene;

	public static App_Controller getInstance{
		get{
			return App_Controller.instance;
		}
	}
	//シングルトン
	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}

	void Start () {
		DontDestroyOnLoad (this);
		nowScene = new Title_Scene (this);
		nowScene.start ();
	}
	
	// Update is called once per frame
	void Update () {
		nowScene.update ();
	}

	public void nextScene(string nextStr){
		SceneManager.LoadScene (nextStr);
		Thread.Sleep (100);
		nowScene.start ();
	}
	public void onClick(){
		nowScene.onClick ();
	}
}
