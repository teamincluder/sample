using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	private float posx=-0.02f;
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		pos.x += posx;
		this.transform.position = pos;
	}
}