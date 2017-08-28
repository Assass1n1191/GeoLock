using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleAndroidNotifications;

public class Player : MonoBehaviour 
{
    private bool _isInInteractiveZone = false;

	private void Awake () 
	{
		
	}
	
	private void Start () 
	{
		
	}
	
	private void Update () 
	{
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(!_isInInteractiveZone)
            NotificationManager.SendWithAppIcon(new System.TimeSpan(0, 0, 0, 1), "Holy Shit!", "You arrived to an interactive zone!", Color.black);

        _isInInteractiveZone = true;
        //Debug.Log("Arrived");
    }

    private void OnTriggerExit(Collider other)
    {
        _isInInteractiveZone = false;
    }
}
