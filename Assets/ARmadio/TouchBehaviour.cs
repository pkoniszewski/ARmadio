using System;
using UnityEngine;
using System.Collections;


public class TouchBehaviour : MonoBehaviour
{
    private Vector3 lastPlanePoint;
    public bool touchToMove = false;
	
	//zmienne do rotacji
	private float startX=0;
	private float stopX=0;
	
	//zmienne do przesuwania
	private Vector2 startPos1 = new Vector2(0,Screen.height/2);
	private Vector2 startPos2 = new Vector2(0,Screen.height/2);
	
	//zmienne do skalowania
	private Vector2 scaleStart1;
	private Vector2 scaleStart2;
	private float scaleStartDiff;
	
	
	//obiekty kontrolujace i kontrolowane
	private GameObject moveObj;

    void Awake()
    {
        m_Instance = this;
    }
	
    void Update()
    {
		moveObj = GlobalVariables.activeObject;
		
		if(!GlobalVariables._showInventory)
		{
			Plane targetPlane = new Plane(transform.up, transform.position);
			
			if(GlobalVariables._move)
			{
				if (Input.touchCount == 1) {
					var touch = Input.GetTouch(0);
                    //Gets the ray at position where the screen is touched
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    //Gets the position of ray along plane
                    float dist = 0.0f;
                    //Intersects ray with the plane. Sets dist to distance along the ray wher intersects
                    targetPlane.Raycast(ray, out dist);

                    //Returns point dist along the ray.
                    Vector3 planePoint = ray.GetPoint(dist);

                    //True if finger touch began.
                    if (touch.phase == TouchPhase.Began)
                    {
                        // Ustaw ostatni punkt na obecny
                        lastPlanePoint = planePoint;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        // Przesuń model i zmień ostatni punkt
                        moveObj.transform.position += planePoint - lastPlanePoint;
                        lastPlanePoint = planePoint;
                    }

					return;
				}
				else if(Input.touchCount == 2) 
				{
					var touch1 = Input.GetTouch(0);
				    var touch2 = Input.GetTouch(1);
					
					Debug.LogError("diff: 1:"+touch1.phase.ToString()+" 2: "+touch2.phase.ToString());
					//zebranie startowych pozycji
					if(touch1.phase == TouchPhase.Began) {
						startPos1 = touch1.position;
					}
					if(touch2.phase == TouchPhase.Began) {
						startPos2 = touch2.position;
					}
			
					//VAR1: pierwszy stoi, ruszamy drugim
					if(touch1.phase == TouchPhase.Stationary && touch2.phase == TouchPhase.Moved) {
						float diff = startPos2.y - touch2.position.y;
						Vector3 old = moveObj.transform.position;
						if (diff > 0) {
							old.y -= Time.deltaTime;
							moveObj.transform.position = old;
						}
						else {
							old.y += Time.deltaTime;
							moveObj.transform.position = old;
						}
					}
					//var2: pierwszy rusza, drugi stoi
					if(touch2.phase == TouchPhase.Stationary && touch1.phase == TouchPhase.Moved) {
						float diff = startPos1.y - touch2.position.y;
						Vector3 old = moveObj.transform.position;
						if (diff > 0) {
							old.y -= Time.deltaTime;
							moveObj.transform.position = old;
						}
						else {
							old.y += Time.deltaTime;
							moveObj.transform.position = old;
						}
					}
				}
			}
			else if(GlobalVariables._rotate)
			{
				foreach (Touch touch in Input.touches)
        		{							 
                    //Gets the ray at position where the screen is touched
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);				
                    //Gets the position of ray along plane
                    float dist = 0.0f;
                    //Intersects ray with the plane. Sets dist to distance along the ray wher intersects
                    targetPlane.Raycast(ray, out dist);

					//przeczytaj koordynaty,jesli palec dotknie ekranu
                    if (touch.phase == TouchPhase.Began)
                    {
						startX = touch.position.x;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
						//odczytaj koncowe koordynaty
						stopX = touch.position.x;
						
						moveObj.transform.Rotate(Vector3.forward, (startX - stopX)/50);
					}
					return;
                }
			}
			else if(GlobalVariables._scale)
			{
				var tapCount = Input.touchCount;
				
				//wczytanie 2 dotkniec w tym samym czasie
				if(tapCount > 1) 
				{
				    var touch1 = Input.GetTouch(0);
				    var touch2 = Input.GetTouch(1);
						
					if (touch1.phase == TouchPhase.Began && touch1.phase == TouchPhase.Began) 
					{
						scaleStart1 = touch1.position;
						scaleStart2 = touch2.position;
						scaleStartDiff = Vector2.Distance(touch1.position,touch2.position);
					}
					else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved) 
					{
						Vector2 scaleEnd1 = touch1.position;
						Vector2 scaleEnd2 = touch2.position;
						float scaleEndDiff = Vector2.Distance(scaleEnd1,scaleEnd2);
					
						foreach(GameObject obj in GlobalVariables.myList)
						{
							if(scaleEndDiff > scaleStartDiff) 
							{
								obj.transform.localScale *= 1.01f;
							}
							else
							{
								obj.transform.localScale *= 0.99f;
							}
						}
						//przepisanie nowych wartosci na poprzednie, zachowuje plynnosc
						scaleStart1 = touch1.position;
						scaleStart2 = touch2.position;
						scaleStartDiff = Vector2.Distance(touch1.position,touch2.position);
					}
				}	
			}
			else if (GlobalVariables._active)
			{
				var arrow = GameObject.Find("Arrow") as GameObject;
				
				arrow.SetActive(true);
				arrow.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
				/*var position = GlobalVariables.activeObject.transform.position;
				arrow.transform.localPosition = position;
				
				if(Input.touchCount > 1) 
				{
					RaycastHit hit = new RaycastHit();
					if (Input.GetTouch(0).phase.Equals(TouchPhase.Began)) {
						Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
						if (Physics.Raycast(ray, out hit)) 
						{
							hit.transform.gameObject.SendMessage("OnMouseDown");
			            }
					}
				}*/
			}
			
			if(!GlobalVariables._active)
			{
//				GameObject.Find("Arrow").SetActive(false);
			}
		}
	}
	
    private static TouchBehaviour m_Instance = null;

    private TouchBehaviour() { }

    public static TouchBehaviour Instance
    {
        get { return m_Instance; }
    }

}

