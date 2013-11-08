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
	
		void OnGUI() {
			if(GlobalVariables.showInventory) {
				temp = (Resources.Load("move_butt2")) as Texture2D;
				GUI.Window(INV_ID, new Rect(20,20,(float)(Screen.width* 0.5),(float)(Screen.height * 0.5)),populateInv,"Lista modeli");
				//GlobalVariables.showInventory = false;
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
					
					GUI.DrawTexture(new Rect(5 + (rowCount * textureWidth),20 + ( colCount * textureHeight), textureWidth, textureHeight),temp);
					rowCount++;
					if( ((float)x/4) == 1) {
						colCount++;
						y++;
						rowCount =0 ;
						
					}
				}
			}
				
		}
		
		
		
		
		
	}


