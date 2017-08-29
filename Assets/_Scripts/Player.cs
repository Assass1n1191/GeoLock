using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;

public class Player : MonoBehaviour 
{
    public static Player Instance;

    public InteractiveZone CurrentZone;
    private bool _isInInteractiveZone = false;

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
        if (_isInInteractiveZone) return;

        NotificationManager.SendWithAppIcon(new System.TimeSpan(0, 0, 0, 1), "Holy Shit!", "You arrived to an interactive zone!", Color.black);
        CurrentZone = collider.gameObject.GetComponent<InteractiveZone>();

        ModelsController.Instance.SetOnButton(true);
        _isInInteractiveZone = true;

        //Debug.Log("Arrived");
    }

    private void OnTriggerExit(Collider other)
    {
        ModelsController.Instance.SetOnButton(false);
        CurrentZone = null;
        _isInInteractiveZone = false;
    }
}
