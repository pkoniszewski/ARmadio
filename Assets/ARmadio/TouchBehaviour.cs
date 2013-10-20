using System;
using UnityEngine;
using System.Collections;


public class TouchBehaviour : MonoBehaviour
{
    private Vector3 lastPlanePoint;
    public bool touchToMove = false;

    void Awake()
    {
        m_Instance = this;
    }

    void Start()
    {
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
                 * TODO */
                Plane targetPlane = new Plane(transform.up, transform.position);
                // Dla kaĹĽdego wykrytego dotkniÄ™cia (multitouch wspierany)
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
                        renderer.transform.position += planePoint - lastPlanePoint;
                        lastPlanePoint = planePoint;
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        // 
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

