using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Map;
using Mapbox.Unity;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Examples.LocationProvider;
using Mapbox.Unity.Location;


public class MapBoxTest : MonoBehaviour 
{
    public Text ResultText;
    public Text CurrentPosition;

    public EditorLocationProvider editorLocationProvider;
    public DeviceLocationProvider deviceLocationProvider;

    private Vector2d requiredPosition;
    private double precision = 0.0005;
        

	private void Awake () 
	{
		
	}
	
	private void Start () 
	{
        //requiredPosition = new Vector2d(49.443733, 32.056695); //Bidon
        requiredPosition = new Vector2d(49.44333, 32.05922); //Ferma


    }

    private void Update ()
	{
        #if UNITY_EDITOR
            CurrentPosition.text = editorLocationProvider.Location.ToString();
            ResultText.gameObject.SetActive(CheckCurrentPosition(editorLocationProvider.Location));

        #elif UNITY_ANDROID
            CurrentPosition.text = deviceLocationProvider.Location.ToString();
            ResultText.gameObject.SetActive(CheckCurrentPosition(deviceLocationProvider.Location));

        #endif

        

        //#if UNITY_EDITOR
        //        CurrentPosition.text = editorLocationProvider.Location.ToString();
        //#elif UNITY_ANDROID
        //        CurrentPosition.text = deviceLocationProvider.Location.ToString();
        //#endif
    }

    private bool CheckCurrentPosition(Vector2d currentPos)
    {
        bool isInZone = true;

        isInZone &= currentPos.x >= requiredPosition.x - precision 
                    && currentPos.x <= requiredPosition.x + precision;

        isInZone &= currentPos.y >= requiredPosition.y - precision
                    && currentPos.y <= requiredPosition.y + precision;

        return isInZone;
    }
}
