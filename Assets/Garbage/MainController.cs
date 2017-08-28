using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    public Text DebugText;

    private bool _startTracking = false;
    private int counter = 0;

    public string debugLog
    {
        set
        {
            Debug.Log(value);
            DebugText.text = value + "\n";
        }
    }

	private IEnumerator Start ()
    {
        if (Input.location.isEnabledByUser)
        {
            debugLog = "Is Enabled By User";
            //yield break;
        }

        Input.location.Start(10, 0.1f);

        int maxWait = 20;

        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1f);
            maxWait--;
        }

        if(maxWait < 0)
        {
            debugLog = "Timed Out";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            debugLog = "Unable to determine device location";
        }
        else
        {
            //_startTracking = true;
            PrintLocation();
        }

        Input.location.Stop();

    }

    private void Update ()
    {
        //try
        //{
        //    if (!_startTracking || Input.location.status != LocationServiceStatus.Running) return;

        //    PrintLocation();

        //}
        //catch (System.Exception e)
        //{
        //    debugLog = e.Message;
        //}

    }

    private void PrintLocation()
    {
        debugLog = "Location: " + Input.location.lastData.latitude + " " +
            Input.location.lastData.longitude + " " +
            Input.location.lastData.altitude + " " +
            Input.location.lastData.horizontalAccuracy + " " +
            Input.location.lastData.timestamp + " " + counter;
    }
}
