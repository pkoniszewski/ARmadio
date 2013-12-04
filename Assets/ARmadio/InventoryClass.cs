using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InventoryClass : MonoBehaviour
{
	private int textureWidth = 60;
	private int textureHeight = 60;

	GUIStyle guiStyle = new GUIStyle();
	

	void Start()
	{
	}

	void OnGUI() {
		if(GlobalVariables.showInventory)
		{
			GUI.Window(1, new Rect(0,0,(float)(Screen.width),(float)(textureHeight+18)),populateInv,"Lista modeli");
		}
		else
		{
			GlobalVariables.showInventory = false;
		}
	}

	public void populateInv(int id) 
	{
		foreach(var go in GlobalVariables.goList)
		{
			Texture2D temp = (Resources.Load("InventoryThumbs/"+go.name)) as Texture2D;
			Rect nowy = new Rect((GlobalVariables.goList.IndexOf(go)*textureWidth)+1,18, textureWidth, textureHeight);
			if( GUI.Button (nowy,temp,guiStyle))
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
					
					//int index = GlobalVariables.goList.IndexOf(GlobalVariables.activeObject);
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
		}
	}	
}
