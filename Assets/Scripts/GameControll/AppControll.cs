using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;
public class AppControll : MonoBehaviour {
	private static AppControll instance = null;
	public SceneInterface nowScene;
	public static AppControll getInstance{
		get{
			return AppControll.instance;
		}
	}
	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}
	void Start () {
		DontDestroyOnLoad (this);
		nowScene = new TitleScene (this);
		nowScene.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		nowScene.Update ();
	}

	public void Next_Scene(string nextStr){
		SceneManager.LoadScene (nextStr);
		Thread.Sleep (100);
		nowScene.Start ();
	}
}
