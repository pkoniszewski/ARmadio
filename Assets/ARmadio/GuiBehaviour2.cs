using System;
using UnityEngine;
using System.Collections;

public class GuiBehaviour2 : MonoBehaviour {
	
	private GameObject gui_actions;
	private GameObject gui_modes;
	private GameObject gui_move;
	private GameObject gui_rotate;
	private GameObject gui_scale;
	private GameObject gui_add;
	private GameObject gui_change;
	private GameObject gui_light;
	private GameObject gui_activ;
	
	void preInitialization() {
		GameObject iT = GameObject.Find("ImageTarget");
		GlobalVariables.Bulb.SetActive(false);
		
		float temp = 0;
		float suma = 0;
		
		foreach (Transform kidette in iT.transform) {
			GlobalVariables.goList.Add(GameObject.Find (kidette.name));
			
			if(kidette.renderer != null) {
				suma = kidette.renderer.bounds.size.y + kidette.position.y;
				//suma = kidette.collider.bounds.size.y + kidette.position.y;
				if ( suma > temp ) 
				{
					temp = suma;			
				}
			}
			
			
		}
		GlobalVariables.goMaxHeight = suma;

		foreach (GameObject kidette in GlobalVariables.goList) {
			kidette.SetActive(false);
				
		}
		GlobalVariables.activeObject = GlobalVariables.goList[0];
		GlobalVariables.activeObject.SetActive(true);
		GlobalVariables.numberOfModels = 1;
		
		Vector3 arrowPos = GlobalVariables.activeObject.transform.position;
		arrowPos.y = GlobalVariables.activeObject.collider.bounds.size.y + GlobalVariables.activeObject.transform.position.y + 100;
		GlobalVariables.Arrow.transform.position = arrowPos;
		GlobalVariables.Arrow.SetActive(false);	
		
		GlobalVariables.woodMaterials.Add(Resources.Load("Models/Materials/drewno_dark", typeof(Material)) as Material);
		GlobalVariables.woodMaterials.Add(Resources.Load("Models/Materials/drewno_Bambus", typeof(Material)) as Material);
		GlobalVariables.woodMaterials.Add(Resources.Load("Models/Materials/drewno_light", typeof(Material)) as Material);
		GlobalVariables.woodMaterials.Add(Resources.Load("Models/Materials/drewno_med", typeof(Material)) as Material);
		GlobalVariables.woodMaterials.Add(Resources.Load("Models/Materials/drewno_walnut", typeof(Material)) as Material);
	}
	
	// Use this for initialization
	void Start () {
		gui_actions = GameObject.Find("Actions");
		gui_modes = GameObject.Find("modes");
		gui_move = GameObject.Find("Move");
		gui_rotate = GameObject.Find("Rotate");
		gui_scale = GameObject.Find("Scale");
		
		gui_add = GameObject.Find("Add");
		gui_change = GameObject.Find("Change");
		gui_light = GameObject.Find("Light");
		
		gui_activ = GameObject.Find("Active");
		
		
		gui_modes.SetActive(false);
		(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt2") as Texture2D;
		
		preInitialization();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0) {
			for(var i = 0; i < Input.touchCount; i++){
 
				Touch touch = Input.GetTouch(i);
				
				if(touch.phase == TouchPhase.Began){
					//wysunięcie menu
					if((gui_actions.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_actions.activeSelf){
						gui_actions.SetActive(false);
						gui_modes.SetActive(true);
					}
					
					if((gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(GlobalVariables.move == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt2") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							(gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("active_butt") as Texture2D;
														
							GlobalVariables.move = true;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.active = false;
							
							GlobalVariables.Bulb.SetActive(false);
							GlobalVariables.Arrow.SetActive(false);
						}
					}
					
					if((gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(GlobalVariables.scale == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt2") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							(gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("active_butt") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = true;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.active = false;
							
							GlobalVariables.Bulb.SetActive(false);
							GlobalVariables.Arrow.SetActive(false);

						}
					}
					
					if((gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(GlobalVariables.rotate == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt2") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							(gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("active_butt") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = true;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.active = false;
							
							GlobalVariables.Bulb.SetActive(false);
							GlobalVariables.Arrow.SetActive(false);
						}
					}
					
					
					if((gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						/*if(GlobalVariables.add_ == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt2") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							(gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("active_butt") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = true;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.active = false;
							
							GlobalVariables.Bulb.SetActive(false);
							GlobalVariables.Arrow.SetActive(false);

						}*/
						/*GameObject chair = Instantiate(GlobalVariables.goList[1], Vector3.zero, Quaternion.identity) as GameObject;
						GlobalVariables.goList.Add(chair);
						GlobalVariables.activeObject = chair;*/
						GlobalVariables.activeObject = GlobalVariables.goList[GlobalVariables.numberOfModels];
						GlobalVariables.activeObject.SetActive(true);
						GlobalVariables.numberOfModels++;
					}
					
					if((gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						//gui_actions.SetActive(true);
						//gui_modes.SetActive(false);
						
						/*if(GlobalVariables.change == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt2") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							(gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("active_butt") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = true;
							GlobalVariables.light = false;
							GlobalVariables.active = false;
							
							GlobalVariables.Bulb.SetActive(false);
							GlobalVariables.Arrow.SetActive(false);

						}*/
						
						GlobalVariables.woodMaterialIndex = (GlobalVariables.woodMaterialIndex +1)%GlobalVariables.maxWoodMaterials;
						GlobalVariables.activeObject.renderer.material = GlobalVariables.woodMaterials[GlobalVariables.woodMaterialIndex];
						
						//nie wiem jak zmusić do działania
						//Material newMat2 = Resources.Load("tex_3", typeof(Material)) as Material;
						//GlobalVariables.activeObject.renderer.materials[1] = newMat2;
					}
					
					if((gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(GlobalVariables.light == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt2") as Texture2D;
							(gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("active_butt") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = true;
							GlobalVariables.active = false;
							GlobalVariables.Arrow.SetActive(false);
						}
					}
					
					if((gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position)){
						//gui_actions.SetActive(true);
						//gui_modes.SetActive(false);
						
						if(GlobalVariables.active == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							(gui_activ.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("active_butt2") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = true;
							GlobalVariables.light = false;
							GlobalVariables.active = true;
							GlobalVariables.Bulb.SetActive(false);
							

						}
					}					
				}
			}
		}
	}
}
