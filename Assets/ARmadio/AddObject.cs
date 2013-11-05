using System;
using UnityEngine;

public class AddObject : MonoBehaviour
{
	public void addObject(Transform t)
	{
		GlobalVariables.numberOfModels++;
		t.name = t.name + '.' + GlobalVariables.numberOfModels.ToString();
		t.transform.parent = this.transform;
	}
}


