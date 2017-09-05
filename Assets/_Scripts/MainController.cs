using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    public static MainController Instance;

    public GameObject MainCamera;
    public GameObject ARCamera;

    public Text InfoAboutModels;
    public GameObject CameraTexture;
    public GameObject ButtonOnModels;
    public GameObject ButtonOffModels;

    private objReaderCSharpV4 _objReader;
    public GameObject ObjectForModel;
    public GameObject Map;

    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        _objReader = GetComponent<objReaderCSharpV4>();
        Map.gameObject.GetComponent<AbstractMap>().enabled = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void TurnModelOn()
    {
        InteractiveZone interactiveZone = Player.Instance.CurrentZone;

        ARCamera.SetActive(true);
        MainCamera.SetActive(false);
        ButtonOnModels.SetActive(false);
        ButtonOffModels.SetActive(true);
        CameraTexture.SetActive(true);
        InfoAboutModels.text = interactiveZone.Description;

        _objReader._textFieldString = interactiveZone.ModelLink;
        _objReader._textureLink = interactiveZone.TextureLink;

        _objReader.StartCoroutine(_objReader.SomeFunction("Object for Model"));
    }

    public void TurnModelOff()
    {
        if (Player.Instance.CurrentZone != null)
            ButtonOnModels.gameObject.SetActive(true);

        ARCamera.SetActive(false);
        MainCamera.SetActive(true);
        ButtonOffModels.SetActive(false);
        ObjectForModel.SetActive(false);
        CameraTexture.SetActive(false);
        InfoAboutModels.text = "";
    }

    public void SetOnButton(bool isActive)
    {
        ButtonOnModels.SetActive(isActive);
    }







	
}
