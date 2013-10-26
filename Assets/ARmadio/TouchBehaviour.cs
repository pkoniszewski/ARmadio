using System;
using UnityEngine;
using System.Collections;


public class TouchBehaviour : MonoBehaviour
{
    private Vector3 lastPlanePoint;
    public bool touchToMove = false;
	
	
	//zmienne odpowiedzialne za obracanie lub przesuwanie ekranu
	public static bool rotate = true;
	public static bool move = false;
	public static bool scale = false;
	
	//zmienne do rotacji
	private float startX=0;
	private float stopX=0;
	
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
		moveObj = GameObject.Find("Chair");
    }
	
	

    void Update()
    {
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
					if(rotate) {

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
					
					else if(move) {
						
						
						foreach (Touch touch in Input.touches)
                		{							
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
					}
					
					else if(scale) {
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
            }
        }
    

    private static TouchBehaviour m_Instance = null;

    private TouchBehaviour() { }

    public static TouchBehaviour Instance
    {
        get { return m_Instance; }
    }

}

