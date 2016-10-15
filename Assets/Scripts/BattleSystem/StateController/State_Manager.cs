using UnityEngine;
using System.Collections;

public class State_Manager : MonoBehaviour {
	State_Interface nowState;
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
}
