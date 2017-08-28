using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsController : MonoBehaviour {


    public Text InfoAboytModels;
    public GameObject Plane;
    public GameObject ButtonOnModels;
    public GameObject ButtonOffModels;
    //public List<GameObject> PlanetsGameObject = new List<GameObject>();
    GameObject _instantiateModels;

    public void Show3DModels(InteractiveZone interactiveZone)
    {
        ButtonOnModels.SetActive(false);
        Plane.SetActive(true);
        InfoAboytModels.text = interactiveZone.Description;
       _instantiateModels = Instantiate(interactiveZone.Model);
    }

    public void Destroy3DModels()
    {
        Destroy(_instantiateModels);
        ButtonOnModels.SetActive(true);
        Plane.SetActive(false);
        InfoAboytModels.text = "";

    }







	
}
