using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	public class InventoryClass : MonoBehaviour
	{
		

		private int row = 4;
		private Texture2D temp;
		private int textureWidth = 60;
		private int textureHeight = 60;
		private int INV_ID = 1;
		private int buttonCounter = 0;
		//private Rect[] invElements;
		
	
		GUIStyle guiStyle = new GUIStyle();
		
		public bool once = true;
		
		private int index=0;
	
		void Start(){
		}
	
		void OnGUI() {
			if(GlobalVariables.showInventory) {
				temp = (Resources.Load("move_butt2")) as Texture2D;
			
					
				
					GUI.Window(INV_ID, new Rect(20,20,(float)(Screen.width* 0.5),(float)(Screen.height * 0.5)),populateInv,"Lista modeli");
				
			}
		
		}
	
		public InventoryClass ()
		{
			
		}
	
		public void populateInv(int id) {
			int lenght = GlobalVariables.goList.Count;
		
			int legNormalized = (lenght/4)+1;
			int colCount = 0;
			int rowCount = 0;
		
			for (int y = 0; y < legNormalized; y++ ) 
			{
				
				for (int x =1 ; x <= lenght; x++ ) {
					
					Rect nowy = new Rect(5 + (rowCount * textureWidth),20 + ( colCount * textureHeight), textureWidth, textureHeight);
					//invElements[index++] = nowy;
					if(once && (GlobalVariables.invRect.Count < lenght)) {
						GlobalVariables.invRect.Add(nowy);
					
					}
					
					//GUI.DrawTexture(nowy,temp);
					
					if( GUI.Button (nowy,temp,guiStyle)) {
						
					
						//tu trzeba przechwycic ktory button nacisnelismy..........
					}
					
					buttonCounter++;
					rowCount++;
					if( ((float)x/4) == 1) {
						colCount++;
						y++;
						rowCount =0 ;
						
					}
				}
			}
		
			once = false;
				
		}
	
		
		
		
		
		
		
	}


