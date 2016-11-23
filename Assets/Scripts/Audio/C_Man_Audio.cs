using UnityEngine;
using System.Collections;

public class C_Man_Audio :MonoBehaviour,Audio_Interface{
	private AudioSource[] sources;
	public void Awake(){
		sources = this.GetComponents<AudioSource> ();
		start ();
	}
	public void start ()
	{
		sources [0].Play ();
	}

	public void jab ()
	{
		sources [1].Play ();
	}

	public void strong ()
	{
		sources [2].Play ();
	}

	public void win ()
	{
		sources [3].Play ();
	}

	public void lose ()
	{
		sources [4].Play ();
	}
	public void damage(){
		sources [5].Play ();
	}
}
