using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;

[RequireComponent(typeof(Key_Click))]
public class App_Controller : MonoBehaviour {
	private static App_Controller instance = null;
	private Scene_Interface nowScene;
	[SerializeField]
	private UI_Controller ui;
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
		ui.init ();
	}
	
	// Update is called once per frame
	void Update () {
		nowScene.update ();
	}

	public void nextScene(Scene_Interface nextscene,string nextstr = ""){
		this.nowScene = nextscene;
		if (nextstr != "") {
			SceneManager.LoadScene (nextstr);
			Thread.Sleep (100);
		}
		nowScene.start ();
	}
	public void onClick(){
		nowScene.onClick ();
	}
}
