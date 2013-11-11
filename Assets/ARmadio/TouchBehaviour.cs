using System;
using UnityEngine;
using System.Collections;


public class TouchBehaviour : MonoBehaviour
{
    private Vector3 lastPlanePoint;
    public bool touchToMove = false;
	
	
	//zmienne odpowiedzialne za obracanie lub przesuwanie ekranu
	//public static bool rotate = true;
	//public static bool move = false;
	//public static bool scale = false;
	public static bool changeActive = false;
	public static GameObject activeObj;
	
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
	
	

    void Start()
    {
		//szukanie i przypisanie
		//tutaj bedzie pobranie z ref od GUI aktywnego obiektu
				
		//preInitialization();
		
		moveObj = GlobalVariables.activeObject;
		//changeActive = true;
		
		
    }
	
	

    void Update()
    {
		moveObj = GlobalVariables.activeObject;
        if (touchToMove)

        {
            //Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);

            //foreach (var renderer in rendererComponents)
            //{
                /* TODO
                 * DodaÄ‡ UI do kamery
                 * Z poziomu UI powinna byÄ‡ moĹĽliwoĹ›Ä‡ wyboru obiektu, ktĂłrym manipulujemy
                 * Lista powinna byÄ‡ wypeĹ‚niona tablicÄ… rendererComponents
                 * W tej chwili manipuluje sie wszystkimi obiektami na raz
                 * MoĹĽna teĹĽ rozwaĹĽyÄ‡ sposĂłb wykrycia dotyku
                 * W tej chwili moĹĽna przesuwaÄ‡ palcem obojÄ™tnie gdzie, a modele i tak bÄ™dÄ… lataĹ‚y po ekranie
                 * MoĹĽna by siÄ™ pokusiÄ‡ o wykrycie, czy na pewno trafiamy palcem w model (diagram voronoia?)
                 * TODO 
                 * 
                 * */
				
			
                Plane targetPlane = new Plane(transform.up, transform.position);

					//operacje dla rotacji		
					if(GlobalVariables.rotate) {

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
								
								float diff = startX - stopX;
								
								//w zaleznosci od roznicy obrot w prawo albo lewo
								if( diff > 0) {
									moveObj.transform.Rotate(Vector3.forward, 60 * Time.deltaTime);
								}
								else {
									moveObj.transform.Rotate(-Vector3.forward, 60 * Time.deltaTime);	
								}
								//Debug.LogError("diff: "+diff.ToString()+"  STARTX:"+StartX.ToString()+"STOPX:"+StopX.ToString()+"__localscale:"+ChairObj.transform.localScale.ToString());
							}
							return;
	                    }

						
					}
					
					else if(GlobalVariables.move) {
						
						
						//foreach (Touch touch in Input.touches)
                		//{
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
		                        // PrzesuĹ„ model i zmieĹ„ ostatni punkt
		                        moveObj.transform.position += planePoint - lastPlanePoint;
		                        lastPlanePoint = planePoint;
		                    }
	
							return;
						}
						else if(Input.touchCount == 2) {
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
						
								//Debug.LogError("diff:"+diff.ToString()+" Y="+touch2.position.y.ToString()+" StartY:"+startPos2.y+" objZ="+moveObj.transform.position.y.ToString());
								
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
						
								//Debug.LogError("diff:"+diff.ToString()+" Y="+touch2.position.y.ToString()+" StartY:"+startPos2.y+" objZ="+moveObj.transform.position.y.ToString());
							}
							
							
						}
					}
					
					else if(GlobalVariables.scale) {
					/*
					 * Wczytuje 2 dotkniecia, obliczam odleglosc miedzy nimi,
					 * po przesunieciu obliczam odleglosc koncowych punktow i odlegosc miedzy nimi.
					 * Na tej podstawie skaluje obraz w gore albo w dol. 
					 * jest ustawiona minimalna skala, zeby nie zniknal. Gornej nie ustawialem.
					 * 
					 */
					
						var tapCount = Input.touchCount;
					
					//wczytanie 2 dotkniec w tym samym czasie
						if(tapCount > 1) {
						    var touch1 = Input.GetTouch(0);
						    var touch2 = Input.GetTouch(1);
							
							if (touch1.phase == TouchPhase.Began && touch1.phase == TouchPhase.Began) {
								//trzeba sie odwolac do globalnych, bo w next update wykona sie nizszy if
								scaleStart1 = touch1.position;
								scaleStart2 = touch2.position;
								scaleStartDiff = Vector2.Distance(touch1.position,touch2.position);
								Debug.LogError("Scale Diff:"+scaleStartDiff+"___ScaleObj: "+moveObj.transform.localScale.ToString());
							
							}
							else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved) {
								
								Vector2 scaleEnd1 = touch1.position;
								Vector2 scaleEnd2 = touch2.position;
								float scaleEndDiff = Vector2.Distance(scaleEnd1,scaleEnd2);
								
								if(scaleEndDiff > scaleStartDiff) {
									moveObj.transform.localScale += new Vector3(0.0009F, 0.0009F, 0.0009F);
								}
								else {
									if(moveObj.transform.localScale.x < 0.1) 
									{
										moveObj.transform.localScale = new Vector3(0.1F,0.1F,0.1F);
									}
									moveObj.transform.localScale -= new Vector3(0.0009F, 0.0009F, 0.0009F);
								}

								//przepisanie nowych wartosci na poprzednie, zachowuje plynnosc
								scaleStart1 = touch1.position;
								scaleStart2 = touch2.position;
								scaleStartDiff = Vector2.Distance(touch1.position,touch2.position);
							
							}
						}	
					}
					else if (GlobalVariables.active) {
						 if (!GlobalVariables.Arrow.activeSelf) GlobalVariables.Arrow.SetActive(true);
				         if(Input.touchCount > 1) {
						 RaycastHit hit = new RaycastHit();
							if (Input.GetTouch(0).phase.Equals(TouchPhase.Began)) {
								Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
					            if (Physics.Raycast(ray, out hit)) {
					                hit.transform.gameObject.SendMessage("OnMouseDown");
					            }
							}
						}

				     }
			
					/*else if(GlobalVariables.showInventory) {
						if(Input.touchCount > 1) {
							Vector2 touch = Input.GetTouch(0).position;
							foreach (Rect r in GlobalVariables.invRect) {
								if( r.Contains(touch)) {
									int pos = GlobalVariables.invRect.FindIndex(FindR);
									Debug.LogError("rect touch: "+pos.ToString());
								}
							}					
						}
							
					}*/
            }
        }
	
    private static TouchBehaviour m_Instance = null;

    private TouchBehaviour() { }

    public static TouchBehaviour Instance
    {
        get { return m_Instance; }
    }

}

