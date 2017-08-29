using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsController : MonoBehaviour {

    public static ModelsController Instance;

    public Text InfoAboytModels;
    public GameObject Plane;
    public GameObject ButtonOnModels;
    public GameObject ButtonOffModels;
    //public List<GameObject> PlanetsGameObject = new List<GameObject>();
    GameObject _instantiateModels;

    private void Awake()
    {
        Instance = this;
    }

    public void Show3DModels()
    {
        InteractiveZone interactiveZone = Player.Instance.CurrentZone;

        ButtonOnModels.SetActive(false);
        ButtonOffModels.SetActive(true);
        Plane.SetActive(true);
        InfoAboytModels.text = interactiveZone.Description;
       _instantiateModels = Instantiate(interactiveZone.Model);
    }

    public void Destroy3DModels()
    {
        Destroy(_instantiateModels);
        //ButtonOnModels.SetActive(true);
        Plane.SetActive(false);
        InfoAboytModels.text = "";
    }

    public void SetOnButton(bool isActive)
    {
        ButtonOnModels.SetActive(isActive);
    }







	
}
