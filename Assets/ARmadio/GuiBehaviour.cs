using UnityEngine;
using System.Collections;

public class GuiBehaviour : MonoBehaviour {
	//class variables
	private GUITexture gui_move;
	private GUITexture gui_rotate;
	private GUITexture gui_scale;
	
	//textury buttonow
	private Texture2D t_move_2;
	private Texture2D t_move_1;
	private Texture2D t_scale_2;
	private Texture2D t_scale_1;
	private Texture2D t_rotate_2;
	private Texture2D t_rotate_1;
	private string texture;
	

	void Start () {
		gui_move = (GameObject.Find("gui_move").GetComponent(typeof(GUITexture))) as GUITexture;
		gui_rotate = (GameObject.Find("gui_rotate").GetComponent(typeof(GUITexture))) as GUITexture;
		gui_scale = (GameObject.Find("gui_scale").GetComponent(typeof(GUITexture))) as GUITexture;
		
		LoadTextures();
		gui_rotate.texture = t_rotate_2;
	}
	
	void Update () {
		
		TouchToMoveSwitch();
		
		
		
	}
	
	
	void TouchToMoveSwitch(){
		//operacje sterujace dla gui_buttons:
		if(Input.touchCount > 0) {
			if(Input.touches[0].phase == TouchPhase.Began && gui_rotate.HitTest(Input.touches[0].position)) {
				if(!TouchBehaviour.rotate) {
					TouchBehaviour.rotate = true;
					gui_rotate.texture = t_rotate_2;
					TouchBehaviour.move = false;
					gui_move.texture = t_move_1;
					TouchBehaviour.scale = false;
					gui_scale.texture = t_scale_1;	
				}
				
			}
			else if(Input.touches[0].phase == TouchPhase.Began && gui_move.HitTest(Input.touches[0].position)) {
				if(!TouchBehaviour.move) {
					TouchBehaviour.rotate = false;
					gui_rotate.texture = t_rotate_1;
					TouchBehaviour.move = true;
					gui_move.texture = t_move_2;
					TouchBehaviour.scale = false;
					gui_scale.texture = t_scale_1;	
				}
				
			}
			else if(Input.touches[0].phase == TouchPhase.Began && gui_scale.HitTest(Input.touches[0].position)) {
				if(!TouchBehaviour.scale) {
					TouchBehaviour.rotate = false;
					gui_rotate.texture = t_rotate_1;
					TouchBehaviour.move = false;
					gui_move.texture = t_move_1;
					TouchBehaviour.scale = true;
					gui_scale.texture = t_scale_2;	
				}
				
			}
		}
		
	}
	void LoadTextures() {
		
		t_move_2 = Resources.Load ("move_butt2") as Texture2D;
		t_move_1 = Resources.Load ("move_butt") as Texture2D;
		t_scale_1 = Resources.Load ("scale_butt") as Texture2D;
		t_scale_2 = Resources.Load ("scale_butt2") as Texture2D;
		t_rotate_1 = Resources.Load ("rotate_butt") as Texture2D;
		t_rotate_2 = Resources.Load ("rotate_butt2") as Texture2D;		
	}
}
