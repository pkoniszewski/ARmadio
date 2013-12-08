using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiBehaviour : MonoBehaviour {
	
	public GUISkin ARmadioSkin;
	
	Vector2 scrollPosition = new Vector2();
	
	//potrzebne do unikalnych nazw, żeby działał skrypt onMouse
	private int index = 0;
	
	void Start () {
		GameObject iT = GameObject.Find("ImageTarget");
		
		foreach (Transform kidette in iT.transform) {
			GlobalVariables.goList.Add(GameObject.Find (kidette.name));
			kidette.gameObject.SetActive(false);
			var tmp = Resources.Load("InventoryThumbs/"+kidette.name) as Texture2D;
		}
		
		GameObject go = (GameObject)GameObject.Instantiate(GlobalVariables.goList[0]);
		
		go.transform.localScale = GlobalVariables.goList[0].transform.lossyScale * GlobalVariables.globalScale;
        go.transform.localPosition = GlobalVariables.goList[0].transform.position;
        go.transform.localRotation = GlobalVariables.goList[0].transform.rotation;
		go.transform.parent = GameObject.Find("ImageTarget").transform;
		go.name = index.ToString();
		index++;
		go.SetActive(true);
		GlobalVariables.activeObject = go;
		GlobalVariables.myList.Add(go);
	}
	
	void OnGUI() 
	{
		GUI.skin = ARmadioSkin;
		float buttonSize = Screen.height * 0.15f;
		
	//GUI GUI GUI
		GUILayout.BeginArea(new Rect(0, Screen.height - (buttonSize) ,Screen.width, (buttonSize)));
		GUILayout.BeginHorizontal();
		
		if(GlobalVariables._move)
		{
			if(GUILayout.Button((Resources.Load("controls_move") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
			{
				GlobalVariables._menuState = !GlobalVariables._menuState;
			}
		}
		else if(GlobalVariables._rotate)
		{
			if(GUILayout.Button((Resources.Load("controls_rotate") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
			{
				GlobalVariables._menuState = !GlobalVariables._menuState;
			}
		}
		else if(GlobalVariables._scale)
		{
			if(GUILayout.Button((Resources.Load("controls_scale") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
			{
				GlobalVariables._menuState = !GlobalVariables._menuState;
			}
		}
		else
		{
			if(GUILayout.Button((Resources.Load("controls") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
			{
				GlobalVariables._menuState = !GlobalVariables._menuState;
			}
		}
		
		if(GlobalVariables._menuState)
		{
			if(GlobalVariables._move?
				GUILayout.Button((Resources.Load("move_butt2") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)):
				GUILayout.Button((Resources.Load("move_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
			{
				GlobalVariables._menuState = false;
				
				GlobalVariables._move = true;
				GlobalVariables._rotate = false;
				GlobalVariables._scale = false;
			}
		
			if(GlobalVariables._rotate?
				GUILayout.Button((Resources.Load("rotate_butt2") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)):
				GUILayout.Button((Resources.Load("rotate_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
			{
				GlobalVariables._menuState = false;
				
				GlobalVariables._move = false;
				GlobalVariables._rotate = true;
				GlobalVariables._scale = false;
			}
		
			if(GlobalVariables._scale?
				GUILayout.Button((Resources.Load("scale_butt2") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)):
				GUILayout.Button((Resources.Load("scale_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
			{
				GlobalVariables._menuState = false;
				
				GlobalVariables._move = false;
				GlobalVariables._rotate = false;
				GlobalVariables._scale = true;
			}
		}
		
		if(GlobalVariables._add?
				GUILayout.Button((Resources.Load("add_butt2") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)):
				GUILayout.Button((Resources.Load("add_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
		{
			GlobalVariables._menuState = false;
			GlobalVariables._add = !GlobalVariables._add;
			GlobalVariables._change = false;
			if(GlobalVariables._add)
				GlobalVariables._showInventory = true;
			else GlobalVariables._showInventory = false;
		}
	
		if(GlobalVariables._change?
				GUILayout.Button((Resources.Load("change_butt2") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)):
				GUILayout.Button((Resources.Load("change_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
		{
			GlobalVariables._menuState = false;
			GlobalVariables._change = !GlobalVariables._change;
			GlobalVariables._add = false;
			if(GlobalVariables._change)
				GlobalVariables._showInventory = true;
			else GlobalVariables._showInventory = false;
		}
	
		if(GUILayout.Button((Resources.Load("del_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
		{
			GlobalVariables._menuState = false;
			GlobalVariables._showInventory = false;
			
			GlobalVariables.myList.Remove(GlobalVariables.activeObject);
			DestroyImmediate(GlobalVariables.activeObject);
		}
	
		if(GlobalVariables._light?
				GUILayout.Button((Resources.Load("light_butt2") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)):
				GUILayout.Button((Resources.Load("light_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
		{
			GlobalVariables._menuState = false;
			GlobalVariables._light = !GlobalVariables._light;
			GlobalVariables._showInventory = false;
		}
	
		if(GlobalVariables._active?
				GUILayout.Button((Resources.Load("active_butt2") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)):
				GUILayout.Button((Resources.Load("active_butt") as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
		{
			GlobalVariables._menuState = false;
			GlobalVariables._active = !GlobalVariables._active;
			GlobalVariables._showInventory = false;
		}
		
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		
	//INVENTORY LIST
		if(GlobalVariables._showInventory)
		{
			scrollPosition = GUILayout.BeginScrollView (
				scrollPosition, GUILayout.Width (Screen.width), GUILayout.Height ((buttonSize)+20.0f));
			GUILayout.BeginHorizontal();
			
			int i = 0;
			foreach (var go in GlobalVariables.goList)
			{
				//TODO: sprawdzić, widocznie jakieś śmieci dodają się do goList
				if(i<34){
				if(GUILayout.Button((Resources.Load("InventoryThumbs/"+go.name) as Texture2D), GUILayout.Width (buttonSize), GUILayout.Height (buttonSize)))
				{
					if(GlobalVariables._add)
					{
						GlobalVariables._showInventory = false;
						GlobalVariables._add = false;
						
						GameObject go2 = (GameObject)GameObject.Instantiate(go);
						go2.transform.localScale = go.transform.lossyScale * GlobalVariables.globalScale;
						go2.transform.localRotation = go.transform.rotation;
						go2.transform.localPosition = go.transform.position;
						go2.transform.parent = GameObject.Find("ImageTarget").transform;
						go2.name = index.ToString();
						index++;
						
						go2.SetActive(true);
						
						GlobalVariables.myList.Add(go2.gameObject);
						GlobalVariables.activeObject = go2.gameObject;
					}
					else if(GlobalVariables._change)
					{
						GlobalVariables._showInventory = false;
						GlobalVariables._change = false;
						
						GameObject go2 = (GameObject)GameObject.Instantiate(go);
						go2.transform.localScale = go.transform.lossyScale * GlobalVariables.globalScale;
						go2.transform.localRotation = GlobalVariables.activeObject.transform.rotation;
						go2.transform.localPosition = GlobalVariables.activeObject.transform.position;
						go2.transform.parent = GameObject.Find("ImageTarget").transform;
						go2.name = index.ToString();
						index++;
							
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
