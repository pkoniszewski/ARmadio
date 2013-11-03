using UnityEngine;
using System.Collections;

public class GuiBehaviour2 : MonoBehaviour {
	
	private GameObject gui_actions;
	private GameObject gui_modes;
	private GameObject gui_move;
	private GameObject gui_rotate;
	private GameObject gui_scale;
	
	// Use this for initialization
	void Start () {
		gui_actions = GameObject.Find("Actions");
		gui_modes = GameObject.Find("modes");
		gui_move = GameObject.Find("Move");
		gui_rotate = GameObject.Find("Rotate");
		gui_scale = GameObject.Find("Scale");
		
		gui_modes.SetActive(false);
		(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt2") as Texture2D;
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
						
						if(TouchBehaviour.move == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt2") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							TouchBehaviour.move = true;
							TouchBehaviour.scale = false;
							TouchBehaviour.rotate = false;
						}
					}
					
					if((gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(TouchBehaviour.scale == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt2") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt") as Texture2D;
							
							TouchBehaviour.move = false;
							TouchBehaviour.scale = true;
							TouchBehaviour.rotate = false;
						}
					}
					
					if((gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).HitTest(touch.position) && gui_modes.activeSelf){
						gui_actions.SetActive(true);
						gui_modes.SetActive(false);
						
						if(TouchBehaviour.rotate == false){
							(gui_move.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("move_butt") as Texture2D;
							(gui_scale.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("scale_butt") as Texture2D;
							(gui_rotate.GetComponent(typeof(GUITexture)) as  GUITexture).texture = Resources.Load ("rotate_butt2") as Texture2D;
							
							TouchBehaviour.move = false;
							TouchBehaviour.scale = false;
							TouchBehaviour.rotate = true;
						}
					}
				}
			}
		}
	}
}
