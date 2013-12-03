using UnityEngine;
using System.Collections;
using System.Linq;

public class OnMouse : MonoBehaviour {
	
	public int gIndex = 0;
	
	public void OnMouseDown () {
		//Debug.Log("HITTEST"+this.name);
		//Debug.LogError("HITTEST"+this.name);
		
		if(IterateList(this.name)) {
			GlobalVariables.activeObject = GlobalVariables.myList[gIndex];
			
			//Debug.LogError("HITTEST : ActiveOBJ: " +GlobalVariables.activeObject.name);
		}
		else {
			GlobalVariables.activeObject = GlobalVariables.myList[0];	
		}
		
		Vector3 arrowPos = GlobalVariables.activeObject.transform.position;
		arrowPos.y = GlobalVariables.activeObject.collider.bounds.size.y + GlobalVariables.activeObject.transform.position.y + 100;
		GlobalVariables.Arrow.transform.position = arrowPos;	
	}
	
	private bool IterateList(string name) {
		gIndex=0;
		foreach (GameObject go in GlobalVariables.myList) {
			//Debug.LogError("HITTEST : go.name:"+go.name+" this.name:"+name+" gIndex:"+gIndex.ToString());
			if(go.name == name) {
				return true;	
			}
			gIndex++;
		}
		return false;
	}
}
