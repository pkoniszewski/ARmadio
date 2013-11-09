using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables
{
	public static int numberOfModels = 0;
	public static List<Transform> transformList = new List<Transform>();
	
	
	//Globalna lista wszystkich dzieci ImageTarget(wszystkich naszych krzesel)
	public static List<GameObject> goList = new List<GameObject>();
	
	public static GameObject activeObject;
	
	public static bool rotate = false;
	public static bool move = false;
	public static bool scale = false;
	public static bool add_ = false;
	public static bool change = false;
	
	//for light
	public static bool light = false;	
	public static bool lightOnBar = false;
	public static float goMaxHeight;
	
	public static bool showInventory = true;
	public static List<Rect> invRect = new List<Rect>();
	public static bool changeActive = true;
	
	
	
	
}

