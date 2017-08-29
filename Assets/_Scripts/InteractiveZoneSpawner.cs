using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;

public class InteractiveZoneSpawner : MonoBehaviour 
{
    [SerializeField] private AbstractMap _map;
    public GameObject InteractiveZonePrefab;
    //private objReaderCSharpV4 objReader;

    private List<InteractiveZone> InteractiveZones;

	private void Awake () 
	{
        InteractiveZones = new List<InteractiveZone>();

    }

    private void Start () 
	{
        //objReader = GetComponent<objReaderCSharpV4>();
        _map.OnInitialized += InitDefaultZones;
    }

    private void InitDefaultZones()
    {
        //InteractiveZones.Add(new InteractiveZone(0, 49.443733, 32.056695, 100f)); //BidOn
        //InteractiveZones.Add(new InteractiveZone(1, 49.44333, 32.05922, 0f)); //Ferma

        InteractiveZones.Add(new InteractiveZone(0, "BidOn-Tech", 49.443733f, 32.056695f, 100, "IT-Company",
                             "https://dl.dropbox.com/s/4x1f0y796r5pe3n/Crate1.obj",
                             "https://dl.dropbox.com/s/jmgc954deqhas89/crate_1.jpg"));

        InteractiveZones.Add(new InteractiveZone(1, "Ferma", 49.44333f, 32.05922f, 0, "Cafe",
                             "https://dl.dropbox.com/s/4x1f0y796r5pe3n/Crate1.obj",
                             "https://dl.dropbox.com/s/jmgc954deqhas89/crate_1.jpg"));

        InteractiveZones.Add(new InteractiveZone(2, "Lubava", 49.445436f, 32.056728f, 100, "Shopping Center",
                             "https://dl.dropbox.com/s/4x1f0y796r5pe3n/Crate1.obj",
                             "https://dl.dropbox.com/s/jmgc954deqhas89/crate_1.jpg"));


        foreach (var zone in InteractiveZones)
        {
            SpawnInteractiveZone(zone);
        }
    }

    private void SpawnInteractiveZone(InteractiveZone zoneInfo)
    {
        Vector3 targetPos = Conversions.GeoToWorldPosition(
                                zoneInfo.Latitude,
                                zoneInfo.Longtitude,
                                _map.CenterMercator,
                                _map.WorldRelativeScale).ToVector3xz();

        GameObject tmp = (GameObject)Instantiate(InteractiveZonePrefab, targetPos, Quaternion.Euler(0f, zoneInfo.Rotation, 0f));
        InteractiveZone newZone = tmp.GetComponent<InteractiveZone>();
        newZone.CopyZoneInfo(zoneInfo);
    }
}
