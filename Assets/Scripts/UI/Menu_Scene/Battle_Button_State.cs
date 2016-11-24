using UnityEngine;
using System.Collections;

public class Battle_Button_State {

	private static Battle_Button_State instance;
	public static Battle_Button_State get_Instance{
		get{
			if (instance == null)
				instance = new Battle_Button_State ();
			return instance;			
		}
	}
	public enum state{
		cpu,
		second
	}
	private state nowstate = state.cpu;
	public	state now_State{
		get{
			return nowstate;
		}
		set{
			if (value >= state.cpu && state.second >= value)
				nowstate = value;
		}
	}

	public bool isCPU(){
		return ( nowstate == state.cpu );
	}

	public bool isSecond(){
		return ( nowstate == state.second );
	}

	public void nowStatePlus(){
		now_State++;
	}

	public void nowStateMinus(){
		now_State--;
	}
	public void exit(){
		instance = null;
	}

}