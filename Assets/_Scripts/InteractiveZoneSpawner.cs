using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;

public class InteractiveZoneSpawner : MonoBehaviour 
{
    [SerializeField] private AbstractMap _map;
    public GameObject InteractiveZonePrefab;

    public List<InteractiveZone> InteractiveZones;

	private void Awake () 
	{
        //InteractiveZones = new List<InteractiveZone>();

    }

    private void Start () 
	{
        _map.OnInitialized += InitDefaultZones;
    }

    private void InitDefaultZones()
    {
        //InteractiveZones.Add(new InteractiveZone(0, 49.443733, 32.056695, 100f)); //BidOn
        //InteractiveZones.Add(new InteractiveZone(1, 49.44333, 32.05922, 0f)); //Ferma

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

        Instantiate(InteractiveZonePrefab, targetPos, Quaternion.Euler(0f, zoneInfo.Rotation, 0f));
    }
}
