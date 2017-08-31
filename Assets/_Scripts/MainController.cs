using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    public static MainController Instance;


    public GameObject MainCamera;
    public GameObject ARCamera;
    public GameObject PLWEBCAM;


    public Text PlaneRotateDebug;
    public Text InfoAboutModels;
    public GameObject CameraTexture;
    public GameObject ButtonOnModels;
    public GameObject ButtonOffModels;
    //public List<GameObject> PlanetsGameObject = new List<GameObject>();
    //GameObject _instantiateModels;
    private objReaderCSharpV4 objReader;
    public GameObject ObjectForModel;

    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        objReader = GetComponent<objReaderCSharpV4>();
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

        objReader._textFieldString = interactiveZone.ModelLink;
        objReader._textureLink = interactiveZone.TextureLink;

        objReader.StartCoroutine(objReader.SomeFunction("Object for Model"));

        //_instantiateModels = Instantiate(interactiveZone.Model);

        PlaneRotateDebug.text = PLWEBCAM.transform.rotation.ToString();
    }

    public void TurnModelOff()
    {
        if (Player.Instance.CurrentZone != null)
            ButtonOnModels.gameObject.SetActive(true);

        //Destroy(_instantiateModels);
        //ButtonOnModels.SetActive(true);

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
