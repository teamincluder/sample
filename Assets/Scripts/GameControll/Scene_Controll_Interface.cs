using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Controll_Interface{
	private	Scene_Interface	nowscene;
	private IEnumerator wait;
	private bool isnextscene = false;
	public Scene_Controll_Interface(){
		wait = nextFrame();
	}
	public void start(){
		nowscene.start ();
		Debug.Log (nowscene.ToString());
	}
	public void onClick(){
		nowscene.onClick ();
	}

	public void update(){
		if (isnextscene)
			wait.MoveNext ();
		if (Input.anyKeyDown)
			onClick ();
	}

	public void changeState(Scene_Interface next,string scenename = ""){
		nowscene = next;
		if (scenename != "") {
			SceneManager.LoadScene (scenename);
			isnextscene = true;
		}
		else {
			start ();
		}
	}
	/*LoadScene後は、次のフレームじゃないといじれないから１フレーム待機*/
	private IEnumerator nextFrame(){
		while (true) {
			yield return null;
			if (isnextscene) {
				start ();
				isnextscene = false;
			}
			yield return null;
		}
	}
}