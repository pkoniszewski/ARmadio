using UnityEngine;
using System.Collections;

public class GlobalLightScript : MonoBehaviour 
{	
	private GameObject defLight;
	private float radius = 150;
	public GUISkin ARmadioSkin;
	
	private Vector2 screenCenter;
	private Vector3 imgPos;
	
	public float vSliderValue = 400.0F;
	
	// Use this for initialization
	void Start () 
	{
		defLight = CreateLight("default");
		defLight.transform.position = imgPos;
		screenCenter = new Vector2(Screen.width/2,Screen.height/2);
		imgPos = GameObject.Find("ImageTarget").transform.position;
		GlobalVariables.bulb.SetActive(false);
	}
	
	
    void OnGUI()
	{
		GUI.skin = ARmadioSkin;
		
		if(GlobalVariables._light) 
		{
			vSliderValue = GUI.VerticalSlider(new Rect(Screen.width - 50,30, 100, 200), vSliderValue, 1000.0F, 0.0F);
			GlobalVariables.bulb.SetActive(true);
		}
		else
		{
			GlobalVariables.bulb.SetActive(false);
		}
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(GlobalVariables._light)
		{
			imgPos = new Vector3(imgPos.x, imgPos.y + 500, imgPos.z);
			if (!GlobalVariables.bulb.activeSelf) GlobalVariables.bulb.SetActive(true);
			if (Input.touchCount == 1) {
				if(Input.touches[0].phase == TouchPhase.Moved) {
					
					Vector2 nowy = Input.touches[0].position;
					nowy.x -= screenCenter.x;
					nowy.y -= screenCenter.y;
					
					imgPos = GameObject.Find("ImageTarget").transform.position;
					
					float kat = Mathf.Atan2(nowy.y,nowy.x);
					float plus = 90* Mathf.Deg2Rad;
					
					kat += plus;
					
					float x = (float)imgPos.x + radius * Mathf.Cos(kat);
					float z = (float)imgPos.z + radius * Mathf.Sin(kat);

					Vector3 tempPos = new Vector3(x, GlobalVariables.lightHeight, z);
					
					defLight.transform.position = tempPos;
					GlobalVariables.bulb.transform.position = tempPos;
				}			
			}
			defLight.light.range = vSliderValue;
		}
	}	
	
	//fabryka swiatla ;)
	GameObject CreateLight(string name)
	{
		GameObject newLight = new GameObject("gLight_"+name);
		newLight.AddComponent(typeof(Light));
		
		newLight.light.type = LightType.Point;
		newLight.light.range = 300.0F;
		newLight.light.intensity = 5.02F;
		
		return newLight;
	}
}
