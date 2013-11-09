using UnityEngine;
using System.Collections;
using System.Linq;

public class OnMouse : MonoBehaviour {
	
	public int gIndex = 0;
	
	// Use this for initialization
	public void OnMouseDown () {
		Debug.Log("HITTEST"+this.name);
		Debug.LogError("HITTEST"+this.name);
		
		
		if(IterateList(this.name)) {
			GlobalVariables.activeObject = GlobalVariables.goList[gIndex];
			Debug.LogError("HITTEST : ActiveOBJ: " +GlobalVariables.activeObject.name);
		}
		else {
			GlobalVariables.activeObject = GlobalVariables.goList[0];	
		}
		
		
		
	}
	
	private bool IterateList(string name) {
		gIndex=0;
		foreach (GameObject go in GlobalVariables.goList) {
			Debug.LogError("HITTEST : go.name:"+go.name+" this.name:"+name+" gIndex:"+gIndex.ToString());
			if(go.name == name) {
				return true;	
			}
			gIndex++;
			
		}
		return false;
	}
	

}
