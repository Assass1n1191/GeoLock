using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScripts : MonoBehaviour {

    static WebCamTexture backCam;
    //public GameObject GameObjectTransform;

    void Start()
    {
        if (backCam == null)
            backCam = new WebCamTexture();

        GetComponent<MeshRenderer>().material.mainTexture = backCam;

        if (!backCam.isPlaying)
            backCam.Play();


        //#if UNITY_ANDROID
        //if (Application.isMobilePlatform)
        //{
        //GameObject cameraParent = new GameObject("camParent");

        //cameraParent.transform.position = this.transform.position;
        //this.transform.parent = cameraParent.transform;
        //transform.Rotate(Vector3.right, 90);

        //}
        //#endif

    }

   

}
