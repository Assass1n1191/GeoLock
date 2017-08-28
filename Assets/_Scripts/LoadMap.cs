using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour {

    const string KeyMap = "cbMvOsqLicdJ23zMERdjof7jLPRtBOBV";
    public Renderer Maprender;
    private Vector2 StartLocation;
    //Vector2 PlayerPosition = new Vector2(49.443735f, 32.056691f); //Latitude , LOngitude


    int _zoom = 19;
    string _typeMap = "map";
    string _url;
	// Use this for initialization
	void Start ()
    {
        //StartLocation = TestLocationService.Instance.LatLong;
        StartLoadMap(TestLocationService.Instance.LatLong);
       // StartLoadMap(PlayerPosition);
    }

    private void StartLoadMap(Vector2 playerPosition)
    {
        // _url = "https://www.mapquestapi.com/staticmap/v5/map?locations=New+York,NY||Buffalo,NY||Rochester,NY&size=600,400@2x&key=" + KeyMap;
        //"https://www.mapquestapi.com/staticmap/v5/map?key=" + KeyMap + "&size=1280,1280&zoom=" + _zoom + "&type=" + _typeMap + "&center=" + playerPosition.x + "," + playerPosition.y;
        _url = "https://www.mapquestapi.com/staticmap/v5/map?center="+ playerPosition.x + "," + playerPosition.y + "&size=600,400&zoom=" + _zoom + "&key=" + KeyMap;


        //  https://open.mapquestapi.com/staticmap/v5/map?locations=Denver,CO||Boulder,CO||39.9205,-105.0867&size=@2x&defaultMarker=marker-num&key=KEY


        Debug.Log(_url);
        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        WWW www = new WWW(_url);
        while (!www.isDone)
        {
            yield return null;
            Debug.Log("LoadImage");
        }

        //if (www.error == null)
        //{
            yield return new WaitForSeconds(0.5f);
            Maprender.material.mainTexture = null;
            Texture2D tmp;
            tmp = new Texture2D(600, 400, TextureFormat.RGB24, false);
            Maprender.material.mainTexture  = tmp;
            www.LoadImageIntoTexture(tmp);
        //}
        //else
        //{
        //    Debug.Log(www.error + "Error");
        //    yield return new WaitForSeconds(1f);
        //    Maprender.material.mainTexture = null;
        //}

        Maprender.enabled = true;
    }
}

