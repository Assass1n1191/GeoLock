using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScripts : MonoBehaviour {

    static WebCamTexture backCam;

    void Start()
    {
        if (backCam == null)
            backCam = new WebCamTexture();

        GetComponent<RawImage>().material.mainTexture = backCam;

        if (!backCam.isPlaying)
            backCam.Play();

    }

}
