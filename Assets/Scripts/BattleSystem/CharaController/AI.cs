using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	private float posx=-0.02f;
	void Update () {
		Vector3 pos = this.transform.position;
		pos.x += posx;
		this.transform.position = pos;
	}
}