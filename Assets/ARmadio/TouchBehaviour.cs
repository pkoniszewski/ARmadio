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
	
	
	//obiekty kontrolujace i kontrolowane
	private GameObject ChairObj;
	private GUITexture controls;

    void Awake()
    {
        m_Instance = this;
    }

    void Start()
    {
		//szukanie i przypisanie 
		ChairObj = GameObject.Find("Chair");
        controls = (GameObject.Find("controls").GetComponent(typeof(GUITexture))) as GUITexture;
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
                 * Domyslnie ustawione jest rotate na true, i move na false, ale trzeba to sprawdzic, bo mozna to
                 * ustawiac z poziomu edytora Unity (jak beda dwa zaznaczone to raczej sie sypnie)
                 * 
                 * Label jest dodany na ekran, ale na chwile obecna nie dziala
                 * 
                 * Po kliknieciu w przycisk zmieniamy tryb obracania/przesuwania na drugi dostepny.
                 * 
                 * jesli dodamy zgrabne menu manipulujace tymi boolami to tak mogloby to wygladac (sterowanie, nie animacja :) )
                 * 
                 * 
                 * 
                 * 
                 * */
				
                Plane targetPlane = new Plane(transform.up, transform.position);
                // Dla kaĹĽdego wykrytego dotkniÄ™cia (multitouch wspierany)
                foreach (Touch touch in Input.touches)
                {
					
					//operacje dla rotacji (na razie w jednym kierunku)
					if(rotate) {
						if(touch.phase == TouchPhase.Began && controls.HitTest(touch.position)){
								move = true;
								rotate = false;
								return;
						}						
						
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
	                        // Tu widac typowo jeden kierunek
	                        ChairObj.transform.Rotate(Vector3.forward, 15 * Time.deltaTime);
	                        lastPlanePoint = planePoint;
	                    }

						return;
					}
					
					if(move) {
						if(touch.phase == TouchPhase.Began && controls.HitTest(touch.position)){
								move = false;
								rotate = true;
								return;
						}						
						
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

