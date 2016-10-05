using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading;
public class AppControll : MonoBehaviour {
	public SceneInterface nowScene;
	// Use this for initialization
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
