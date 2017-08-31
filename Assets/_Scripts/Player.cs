using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;

public class Player : MonoBehaviour 
{
    public static Player Instance;

    public InteractiveZone CurrentZone;
    private bool _isInInteractiveZone = false;

    private DateTime _lastZoneEnterTime;
    private double _pushMessageDelay = 60; //In seconds
    private string _lastZoneName = "";

	private void Awake () 
	{
        Instance = this;
	}
	
	private void Start () 
	{
		
	}
	
	private void Update () 
	{
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        //if (_isInInteractiveZone) return;

        if (CurrentZone == null) //If null there is first zone entered
        {
            _lastZoneEnterTime = DateTime.Now;
            CurrentZone = collider.gameObject.transform.parent.GetComponent<InteractiveZone>();
            _lastZoneName = CurrentZone.Name;

            NotificationManager.SendWithAppIcon(TimeSpan.Zero, CurrentZone.Name + " is near!",
                CurrentZone.Description, Color.black);
        }
        else
        {
            TimeSpan timeFromLastZone = DateTime.Now.Subtract(_lastZoneEnterTime);
            CurrentZone = collider.gameObject.transform.parent.GetComponent<InteractiveZone>();

            Debug.Log(timeFromLastZone.TotalSeconds);

            if (timeFromLastZone.TotalSeconds > _pushMessageDelay || CurrentZone.Name != _lastZoneName)
            {
                NotificationManager.SendWithAppIcon(TimeSpan.Zero, CurrentZone.Name + " is near!",
                    CurrentZone.Description, Color.black);
            }

            _lastZoneEnterTime = DateTime.Now;
            _lastZoneName = CurrentZone.Name;
        }

        MainController.Instance.SetOnButton(true);
        _isInInteractiveZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //MainController.Instance.TurnModelOff();
        MainController.Instance.SetOnButton(false);
        //CurrentZone = null;
        //_isInInteractiveZone = false;
    }
}
