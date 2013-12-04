using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryClass : MonoBehaviour
{
	Vector2 scrollPosition = new Vector2();
	
	void Start()
	{
	}

	void OnGUI() {
		if(GlobalVariables.showInventory)
		{
			scrollPosition = GUILayout.BeginScrollView (
				scrollPosition, GUILayout.Width (Screen.width), GUILayout.Height ((Screen.height * 0.15f)+10.0f));
			GUILayout.BeginHorizontal();
			
			int i = 0;
			foreach (var go in GlobalVariables.goList)
			{
				//TODO: sprawdzić, widocznie jakieś śmieci dodają się do goList
				if(i<26){
				if(GUILayout.Button((Resources.Load("InventoryThumbs/"+go.name) as Texture2D), GUILayout.Width (Screen.height * 0.15f), GUILayout.Height (Screen.height * 0.15f)))
				{
					if(GlobalVariables.add_)
					{
						GlobalVariables.showInventory = false;
						GlobalVariables.add_ = false;
						
						GameObject go2 = (GameObject)GameObject.Instantiate(go);
						go2.transform.localScale = go.transform.lossyScale/4;
						go2.transform.localRotation = go.transform.rotation;
						go2.transform.localPosition = go.transform.position;
						go2.transform.parent = GameObject.Find("ImageTarget").transform;
						
						go2.SetActive(true);
						
						GlobalVariables.myList.Add(go2.gameObject);
						GlobalVariables.numberOfModels++;
						GlobalVariables.activeObject = go2.gameObject;
					}
					else if(GlobalVariables.change)
					{
						GlobalVariables.showInventory = false;
						GlobalVariables.change = false;
						
						GameObject go2 = (GameObject)GameObject.Instantiate(go);
						go2.transform.localScale = go.transform.lossyScale/4;
						go2.transform.localRotation = go.transform.rotation;
						go2.transform.localPosition = GlobalVariables.activeObject.transform.position;
						go2.transform.parent = GameObject.Find("ImageTarget").transform;
						
						go2.SetActive(true);
						
						GlobalVariables.myList.Remove(GlobalVariables.activeObject);
						DestroyImmediate(GlobalVariables.activeObject);
						GlobalVariables.myList.Add(go2.gameObject);
						GlobalVariables.activeObject = go2.gameObject;
					}
				}
					
				}i++;
			}
			
			GUILayout.EndHorizontal();
			GUILayout.EndScrollView ();
		}
	}
}
