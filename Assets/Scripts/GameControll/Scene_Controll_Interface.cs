using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;
public class Scene_Controll_Interface :MonoBehaviour{
	private	Scene_Interface	nowscene;
	private void Start(){
		this.UpdateAsObservable ()
			.Where (_ => Input.anyKeyDown)
			.Subscribe (_ =>
				{
					nowscene.onClick();
				});
		this.battlecounter = BATTLE_COUNT;
	}
	private const int BATTLE_COUNT = 3;

	private int battlecounter;
	public	int battle_Counter{
		get{
			return battlecounter;
		}
	}
	public bool countDown(){
		battlecounter--;
		bool battleend = false;
		if (battlecounter <= 0) {
			battlecounter = BATTLE_COUNT;
			battleend = true;
		}
		return battleend;
	}

	public void nowSceneStart(){
		nowscene.start ();
	}

	public void nowSceneUpdate(){
		nowscene.update ();
	}

	public void changeState(Scene_Interface next,string scenename = ""){
		this.nowscene = next;
		if (scenename != "") {
			SceneManager.LoadScene (scenename);
			StartCoroutine (nextFrame ());
		} else {
			nowscene.start ();
		}
	}

	/*LoadScene後は、次のフレームじゃないといじれないから１フレーム待機*/
	private IEnumerator nextFrame(){
		yield return null;
		nowscene.start ();
	}
}

