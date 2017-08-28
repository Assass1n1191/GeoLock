using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveZone 
{
    public double Latitude;
    public double Longtitude;
    public float Rotation;

    public InteractiveZone()
    {
        Latitude = 0;
        Longtitude = 0;
        Rotation = 0;
    }

    public InteractiveZone(double latitude, double longtitude, float rotation)
    {
        Latitude = latitude;
        Longtitude = longtitude;
        Rotation = rotation;
    }
}
