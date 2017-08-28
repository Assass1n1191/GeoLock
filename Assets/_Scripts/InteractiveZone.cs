using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractiveZone 
{
    public int Id;
    public string Name;
    public double Latitude;
    public double Longtitude;
    public float Rotation;
    public string Description;
    public GameObject Model;

    public InteractiveZone()
    {
        Id = -1;
        Name = "No name";
        Latitude = 0;
        Longtitude = 0;
        Rotation = 0;
        Description = "No description";
        Model = null;
    }

    public InteractiveZone(int id, double latitude, double longtitude, float rotation, string description, GameObject model)
    {
        Id = id;
        Latitude = latitude;
        Longtitude = longtitude;
        Rotation = rotation;
    }
}
