using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Mapbox.Map;

using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Examples.LocationProvider;
using Mapbox.Unity.Location;


public class InteractiveZoneSpawner : MonoBehaviour 
{
    [SerializeField] private AbstractMap _map;
    public GameObject InteractiveZonePrefab;

    private List<InteractiveZone> _interactiveZones;

	private void Awake () 
	{
        _interactiveZones = new List<InteractiveZone>();

    }

    private void Start () 
	{
        _map.OnInitialized += InitDefaultZones;
    }

    private void InitDefaultZones()
    {
        _interactiveZones.Add(new InteractiveZone(49.443733, 32.056695, 100f)); //BidOn
        _interactiveZones.Add(new InteractiveZone(49.44333, 32.05922, 0f)); //Ferma

        foreach (var zone in _interactiveZones)
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
