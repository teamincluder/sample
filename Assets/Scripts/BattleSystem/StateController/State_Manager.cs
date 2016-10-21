using UnityEngine;
using System.Collections;

[RequireComponent(typeof(State_Key_Click))]
public class State_Manager : MonoBehaviour {
	private static State_Manager instance;
	private State_Interface nowState;
	public static State_Manager getInstance{
		get{ 
			return instance;
		}
	}
	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this.gameObject);
	}
	void Start(){
		nowState = new Start_State (this);
		nowState.start ();
	}
	void Update(){
		nowState.update ();
	}
	public void nextState(State_Interface nextState){
		nowState = nextState;
		nowState.start ();
	}
	public void onClick(){
		nowState.onClick ();
	}
}
