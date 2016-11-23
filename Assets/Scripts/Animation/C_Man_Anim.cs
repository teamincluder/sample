﻿using UnityEngine;
using System.Collections;

public class C_Man_Anim : MonoBehaviour,Animation_Interface {
	Animator anim;

	void Awake(){
		anim =	this.gameObject.GetComponent<Animator>();
	}

	public void run ()
	{
		anim.SetTrigger ("Run");
	}
	public void jab ()
	{
		anim.SetTrigger ("Jab");		
	}
	public void strong ()
	{
		anim.SetTrigger ("Strong");
	}
	public void lose ()
	{
		anim.SetTrigger ("Lose");
	}
	public void guard ()
	{
		anim.SetTrigger ("Guard");
	}
	public void damage ()
	{
		anim.SetTrigger ("Damage");
	}
}
