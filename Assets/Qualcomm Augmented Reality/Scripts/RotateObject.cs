using System;
using UnityEngine;
using System.Collections;


public class RotateObject : MonoBehaviour 
{
	public bool startRotating = false;
	public Renderer component;
	
	void Awake()
	{
		m_Instance = this;
	}
	
    void Start()
    {
    }
 
    void Update()
    {
		
		if (startRotating)
		{
			component.transform.Rotate(Vector3.up, 5*Time.deltaTime);
		}
    }
	
	private static RotateObject m_Instance = null;
 
    private RotateObject() { }
	
	public static RotateObject Instance
    {
       get { return m_Instance; }
    }
}

