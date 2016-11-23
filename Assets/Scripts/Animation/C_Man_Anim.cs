using UnityEngine;
using System.Collections;

public class C_Man_Anim : MonoBehaviour {
	private const string ANIM_DAMAGE_STR	= "C_Damage";
	private const string ANIM_RUN_STR 		= "";

	Animation anim ;

	void Start(){
		anim =	this.gameObject.GetComponent<Animation>();
		anim.Play (ANIM_DAMAGE_STR);
	}


}
