using UnityEngine;
using System.Collections;

public class OnMouse : MonoBehaviour {

	// Use this for initialization
	public void OnMouseDown () {
		Debug.Log("HITTEST"+this.name);
		Debug.LogError("HITTEST"+this.name);
	}
}
