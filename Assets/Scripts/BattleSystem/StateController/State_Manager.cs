using UnityEngine;
using System.Collections;

[RequireComponent(typeof(State_Key_Click))]
public class State_Manager : MonoBehaviour {
	private static State_Manager instance;
	private State_Interface nowState;
	private Key_Controll firstmanager;
	public 	Key_Controll first_Manager{
		get{
			return firstmanager;
		}
	}
	private Key_Controll secondmanager;
	public 	Key_Controll second_Manager{
		get{
			return secondmanager;
		}
	}
	private const string FIRST_OBJ_PATH		=	"1P";
	private const string SECOND_OBJ_PATH	=	"2P";

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
		firstmanager 	= 	GameObject.Find (FIRST_OBJ_PATH).GetComponent<Key_Controll>();
		secondmanager	= 	GameObject.Find	(SECOND_OBJ_PATH).GetComponent<Key_Controll>();
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
