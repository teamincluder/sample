using UnityEngine.SceneManagement;
public abstract class SceneInterface {
	protected AppControll manager;
	public SceneInterface(AppControll manager)
	{
		this.manager = manager;
	}
	public abstract void Start();
	public abstract void Update();
	public abstract void Next_Scene();
}
