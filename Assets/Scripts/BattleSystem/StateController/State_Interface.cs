public abstract class State_Interface {
	protected State_Manager manager;
	public State_Interface(State_Manager manager){
		this.manager = manager;
	}
	public abstract void start ();
	public abstract void update();
	public abstract void nextState ();
	public abstract void onClick();
}
