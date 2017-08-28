using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestLocationService : MonoBehaviour {

    public Text DebugLocation;
    public Vector2 LatLong = new Vector2(); 
    public static  TestLocationService Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LocationUser();
    }
   
    void LocationUser()
        {
        //Debug.Log("CKXMCKJMX");
            // First, check if user has location service enabled
            //if (!Input.location.isEnabledByUser)
            //    yield break;

            // Start service before querying location
            Input.location.Start();

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                //yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait < 1)
            {
            //DebugLocation.text = ("Timed out");
                //yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
            //DebugLocation.text = ("Unable to determine device location");
                //yield break;
            }
            else
            {
            // Access granted and location value could be retrieved
            DebugLocation.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            LatLong = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
        }

            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }
    }
