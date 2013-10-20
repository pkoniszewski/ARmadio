using UnityEngine;
using System.Collections;

public class CustomTracker : MonoBehaviour,ITrackableEventHandler  {


    #region PRIVATE_MEMBER_VARIABLES
  
    private TrackableBehaviour mTrackableBehaviour;
    private bool isRendered = false;
    private GameObject Dragon;
	private GUITexture controls;
 
     
    #endregion // PRIVATE_MEMBER_VARIABLES
 
 
 
    #region UNTIY_MONOBEHAVIOUR_METHODS
     
    void Start()
    {
         
        Dragon = GameObject.Find("Chair");
        controls = (GameObject.Find("controls").GetComponent(typeof(GUITexture))) as GUITexture;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
 
        OnTrackingLost();
    }
     
    void Update()
    {
		int i = 0;
		
//		ARCamera = GameObject.Find("ARCamera");
		
		//Czy obiekt jest sledzony i renderowany
        if( isRendered ){
			//Przechwycenie wszystkich dotykow ekranu
            while (i < Input.touchCount) {
	            if (Input.GetTouch(i).phase == TouchPhase.Stationary) {
	               if (controls.HitTest(Input.GetTouch(i).position)) {
						Debug.Log("DOTKNIETY");
						Dragon.transform.RotateAround(Vector3.down, 1 * Time.deltaTime);
					}
				}
	            ++i;
					
        }
			
			
			
			//;
             
            //Debug.Log( Dragon.transform.position.ToString() );
             
        }
    }
 
    #endregion // UNTIY_MONOBEHAVIOUR_METHODS
 
 
 
    #region PUBLIC_METHODS
 
    // Implementation of the ITrackableEventHandler function called when the
    // tracking state changes.
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }
     
     
 
    #endregion // PUBLIC_METHODS
 
 
 
    #region PRIVATE_METHODS
 
 
    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
 
        // Enable rendering:
        foreach (Renderer component in rendererComponents) {
            component.enabled = true;
        }
 
        Debug.Log("Trackable KRZESLO" + mTrackableBehaviour.TrackableName + " found");
         
        isRendered = true;

    }
 
 
    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
 
        // Disable rendering:
        foreach (Renderer component in rendererComponents) {
            component.enabled = false;
        }
 
        Debug.Log("Trackable KRZESLO" + mTrackableBehaviour.TrackableName + " lost");
         
        isRendered = false;
    }
	
	#endregion 
}
