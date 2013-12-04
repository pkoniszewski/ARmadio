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
				GlobalVariables.showInventory = false;
			}
		}
	}	
}
