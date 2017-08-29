using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class InteractiveZone : MonoBehaviour
{
    public int Id;
    public string Name;
    public double Latitude;
    public double Longtitude;
    public float Rotation;
    public string Description;
    public string ModelLink;
    public string TextureLink;

    public InteractiveZone()
    {
        Id = -1;
        Name = "No name";
        Latitude = 0;
        Longtitude = 0;
        Rotation = 0;
        Description = "No description";
        ModelLink = "";
        TextureLink = "";
    }

    public InteractiveZone(int id, string name, double latitude, double longtitude, float rotation, 
                           string description, string modelLink, string textureLink)
    {
        Id = id;
        Name = name;
        Latitude = latitude;
        Longtitude = longtitude;
        Rotation = rotation;
        Description = description;
        ModelLink = modelLink;
        TextureLink = textureLink;
    }

    public void CopyZoneInfo(InteractiveZone zone)
    {
        Id = zone.Id;
        Name = zone.Name;
        Latitude = zone.Latitude;
        Longtitude = zone.Longtitude;
        Rotation = zone.Rotation;
        Description = zone.Description;
        ModelLink = zone.ModelLink;
        TextureLink = zone.TextureLink;
    }
}
