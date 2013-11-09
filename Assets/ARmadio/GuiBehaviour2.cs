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
		
		
		gui_modes.SetActive(false);
		(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt2") as Texture2D;
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
														
							GlobalVariables.move = true;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.lightOnBar = false;
							
							
							
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
							
							GlobalVariables.move = false;
							GlobalVariables.scale = true;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.lightOnBar = false;
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
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = true;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.lightOnBar = false;
						}
					}
					
					
					if((gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(GlobalVariables.add_ == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt2") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = true;
							GlobalVariables.change = false;
							GlobalVariables.light = false;
							GlobalVariables.lightOnBar = false;
						}
					}
					
					if((gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(GlobalVariables.change == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							(gui_add.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("add_butt") as Texture2D;
							(gui_change.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("change_butt2") as Texture2D;
							(gui_light.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("light_butt") as Texture2D;
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = true;
							GlobalVariables.light = false;
							GlobalVariables.lightOnBar = false;
						}
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
							
							GlobalVariables.move = false;
							GlobalVariables.scale = false;
							GlobalVariables.rotate = false;
							GlobalVariables.add_ = false;
							GlobalVariables.change = false;
							GlobalVariables.light = true;
							GlobalVariables.lightOnBar = true;
							
						}
						//GlobalVariables.showInventory = true;
					}

					
					
					
					
					
				}
			}
		}
	}
}
