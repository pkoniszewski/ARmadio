using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables
{
	//moze da sie to wyjebac?
	public static List<Transform> transformList = new List<Transform>();
	
	//Globalna lista wszystkich dzieci ImageTarget(wszystkich naszych krzesel)
	public static List<GameObject> goList = new List<GameObject>();
	public static List<GameObject> myList = new List<GameObject>();
	
	public static GameObject activeObject;
	
	public static bool _menuState = false;
	public static bool _rotate = false;
	public static bool _move = true;
	public static bool _scale = false;
	public static bool _add = false;
	public static bool _change = false;
	public static bool _active = false;
	public static bool _light = false;
	public static bool _showInventory = false;
	
	public static GameObject arrow = GameObject.Find("Arrow");
	public static GameObject bulb = GameObject.Find("Bulb");
	
	public static float globalScale = 1.0f;
}

