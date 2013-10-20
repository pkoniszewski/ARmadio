using System;
using UnityEngine;
using System.Collections;


public class RotateObject : MonoBehaviour
{
    private Vector3 lastPlanePoint;
    public bool allowMovement = false;

    void Awake()
    {
        m_Instance = this;
    }

    void Start()
    {
    }


    void Update()
    {
        if (allowMovement)
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            foreach (var renderer in rendererComponents)
            {
                /* TODO
                 * Dodać UI do kamery
                 * Z poziomu UI powinna być możliwość wyboru obiektu, którym manipulujemy
                 * Lista powinna być wypełniona tablicą rendererComponents
                 * W tej chwili manipuluje sie wszystkimi obiektami na raz
                 * Można też rozważyć sposób wykrycia dotyku
                 * W tej chwili można przesuwać palcem obojętnie gdzie, a modele i tak będą latały po ekranie
                 * Można by się pokusić o wykrycie, czy na pewno trafiamy palcem w model (diagram voronoia?)
                 * TODO */
                Plane targetPlane = new Plane(transform.up, transform.position);
                // Dla każdego wykrytego dotknięcia (multitouch wspierany)
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
                        // Przesuń model i zmień ostatni punkt
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

    private static RotateObject m_Instance = null;

    private RotateObject() { }

    public static RotateObject Instance
    {
        get { return m_Instance; }
    }

}

