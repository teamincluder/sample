using UnityEngine;
public class Button_State{
	public enum state{
		story,
		battle,
		option
	}
	public bool checkStory(){
		return (select == state.story);
	}
	public bool checkBattle(){
		return (select == state.battle);
	}
	public bool checkOption(){
		return (select == state.option);
	}

	private state select = state.story;
	public state  now_State{
		get{
			return select;
		}
		set{
			if (value >= state.story && state.option >= value) {
				select = value;
			}
		}
	}
	public void nowStatePlus(){
		now_State++;
	}
	public void nowStateMinus(){
		now_State--;
	}
	private static Button_State instance;
	public static Button_State get_Instance{
		get{
			if (instance == null) instance = new Button_State ();
			return instance;
		}
	}
	public void exit(){
		instance = null;
	}
}