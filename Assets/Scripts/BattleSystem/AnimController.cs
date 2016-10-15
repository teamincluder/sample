using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour {
	[SerializeField]
	Animator MoveAnim;

	void Update(){
	}


	public void Move(){
		int anim = Animator.StringToHash ("Move");
		MoveAnim.CrossFade (anim,0.0f);
	}
	public void Idle(){
		MoveAnim.CrossFade (Animator.StringToHash ("Idle"),0f);
	}
}
