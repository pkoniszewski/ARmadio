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
	
	public static bool rotate = false;
	public static bool move = false;
	public static bool scale = false;
	public static bool add_ = false;
	public static bool change = false;
	public static bool light = true;
	
	public static bool lightOnBar = true;	
	
	public static bool showInventory = false;
	public static bool changeActive = true;
	
	
	
	
}

