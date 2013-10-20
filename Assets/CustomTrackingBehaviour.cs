using UnityEngine;
using System.Collections;

public class CustomEventHandler2 : MonoBehaviour, ITrackableEventHandler 
{
 
    #region PRIVATE_MEMBER_VARIABLES
  
    private TrackableBehaviour mTrackableBehaviour;
    private bool isRendered = false;
    private GameObject Dragon;
 
     
    #endregion // PRIVATE_MEMBER_VARIABLES
 
 
 
    #region UNTIY_MONOBEHAVIOUR_METHODS
     
    void Start()
    {
         
        Dragon = GameObject.Find("Chair");
         
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
 
        OnTrackingLost();
    }
     
    void Update()
    {
        if( isRendered && Dragon.transform.position.x < 140 ){
             
            Dragon.transform.position += Dragon.transform.forward * 20.0f * Time.deltaTime;
             
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
 
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
         
        isRendered = true;
    }
 
 
    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
 
        // Disable rendering:
        foreach (Renderer component in rendererComponents) {
            component.enabled = false;
        }
 
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
         
        isRendered = false;
    }
 
    #endregion // PRIVATE_METHO
}
