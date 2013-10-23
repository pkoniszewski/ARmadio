using System;
using UnityEngine;
using System.Collections;


public class TouchBehaviour : MonoBehaviour
{
    private Vector3 lastPlanePoint;
    public bool touchToMove = false;
	
	
	//zmienne odpowiedzialne za obracanie lub przesuwanie ekranu
	public bool rotate = true;
	public bool move = false;
	public bool scale = false;
	
	//zmienne do rotacji
	private float StartX=0;
	private float StopX=0;
	
	//zmienne do skalowania
	private Vector2 scaleStart1;
	private Vector2 scaleStart2;
	private float scaleStartDiff;
	
	
	//obiekty kontrolujace i kontrolowane
	private GameObject ChairObj;
	//private GUITexture controls;
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
	
	
	
	//wczytanie png'ow z resource'a.
	void LoadTextures() {
		
		t_move_2 = Resources.Load ("move_butt2") as Texture2D;
		t_move_1 = Resources.Load ("move_butt") as Texture2D;
		t_scale_1 = Resources.Load ("scale_butt") as Texture2D;
		t_scale_2 = Resources.Load ("scale_butt2") as Texture2D;
		t_rotate_1 = Resources.Load ("rotate_butt") as Texture2D;
		t_rotate_2 = Resources.Load ("rotate_butt2") as Texture2D;		
	}
	
    void Awake()
    {
        m_Instance = this;
    }

    void Start()
    {
		//szukanie i przypisanie 
		ChairObj = GameObject.Find("Chair");
        //controls = (GameObject.Find("controls").GetComponent(typeof(GUITexture))) as GUITexture;
		
		//kontrolki
		gui_move = (GameObject.Find("gui_move").GetComponent(typeof(GUITexture))) as GUITexture;
		gui_rotate = (GameObject.Find("gui_rotate").GetComponent(typeof(GUITexture))) as GUITexture;
		gui_scale = (GameObject.Find("gui_scale").GetComponent(typeof(GUITexture))) as GUITexture;
		
		LoadTextures();
		gui_rotate.texture = t_rotate_2;
		

    }
	
	

    void Update()
    {
        if (touchToMove)

        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);

            foreach (var renderer in rendererComponents)
            {
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
                 * 
                 * TODOV2
                 * 
                 * Odwoluje sie do znalezionego wczesniej ChairObjecta, nie do elementow z renderera
                 * nie wiem czy ta petla jest potrzebna tam.
                 * 
                 * */
				
                Plane targetPlane = new Plane(transform.up, transform.position);
					
                	//operacje sterujace dla gui_buttons:
					if(Input.touches[0].phase == TouchPhase.Began && gui_rotate.HitTest(Input.touches[0].position)) {
						if(!rotate) {
							rotate = true;
							gui_rotate.texture = t_rotate_2;
							move = false;
							gui_move.texture = t_move_1;
							scale = false;
							gui_scale.texture = t_scale_1;	
						}
						
					}
					else if(Input.touches[0].phase == TouchPhase.Began && gui_move.HitTest(Input.touches[0].position)) {
						if(!move) {
							rotate = false;
							gui_rotate.texture = t_rotate_1;
							move = true;
							gui_move.texture = t_move_2;
							scale = false;
							gui_scale.texture = t_scale_1;	
						}
						
					}
					else if(Input.touches[0].phase == TouchPhase.Began && gui_scale.HitTest(Input.touches[0].position)) {
						if(!scale) {
							rotate = false;
							gui_rotate.texture = t_rotate_1;
							move = false;
							gui_move.texture = t_move_1;
							scale = true;
							gui_scale.texture = t_scale_2;	
						}
						
					}

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
		
		                    //Returns point dist along the ray.
		                    Vector3 planePoint = ray.GetPoint(dist);
							
							
							//przeczytaj koordynaty,jesli palec dotknie ekranu
		                    if (touch.phase == TouchPhase.Began)
		                    {
								StartX = touch.position.x;
	
		                    }
		                    else if (touch.phase == TouchPhase.Moved)
		                    {
								
								//odczytaj koncowe koordynaty
								StopX = touch.position.x;
								
								float diff = StartX - StopX;
								
								//w zaleznosci od roznicy obrot w prawo albo lewo
								if( diff > 0) {
									ChairObj.transform.Rotate(Vector3.forward, 60 * Time.deltaTime);
								}
								else {
									ChairObj.transform.Rotate(-Vector3.forward, 60 * Time.deltaTime);	
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
		                        ChairObj.transform.position += planePoint - lastPlanePoint;
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
								Debug.LogError("Scale Diff:"+scaleStartDiff+"___ScaleObj: "+ChairObj.transform.localScale.ToString());
							
							}
							else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved) {
								
								Vector2 scaleEnd1 = touch1.position;
								Vector2 scaleEnd2 = touch2.position;
								float scaleEndDiff = Vector2.Distance(scaleEnd1,scaleEnd2);
								
								if(scaleEndDiff > scaleStartDiff) {
									ChairObj.transform.localScale += new Vector3(0.0009F, 0.0009F, 0.0009F);
								}
								else {
									if(ChairObj.transform.localScale.x < 0.1) 
									{
										ChairObj.transform.localScale = new Vector3(0.1F,0.1F,0.1F);
									}
									ChairObj.transform.localScale -= new Vector3(0.0009F, 0.0009F, 0.0009F);
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
        }
    

    private static TouchBehaviour m_Instance = null;

    private TouchBehaviour() { }

    public static TouchBehaviour Instance
    {
        get { return m_Instance; }
    }

}

