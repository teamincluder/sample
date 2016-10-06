using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour {
	[SerializeField]
	Animator MoveAnim;
	bool isPlay;

	void Update(){
		if (!isPlay)
			StartCoroutine (Idle());
	}


	public IEnumerator Move(){
		if (isPlay)
			yield break;
		isPlay = true;
		int anim = Animator.StringToHash ("Move");
		MoveAnim.Play (anim,0,0.0f);
		yield return new WaitForAnimation (MoveAnim,0);
		isPlay = false;
	}
	public IEnumerator Idle(){
		if (isPlay)
			yield break;
		isPlay = true;
		MoveAnim.Play (Animator.StringToHash ("Idle"),0,0f);
		yield return new WaitForAnimation(MoveAnim,0);
		isPlay = false;
	}
}
