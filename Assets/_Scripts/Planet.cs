using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour 
{
    private const float _rotateSpeed = 0.10f;
    private Vector3 _rotateDirection;
    
	private void Start () 
	{
        _rotateDirection = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
	}
	
	private void Update () 
	{
        transform.Rotate(_rotateDirection * Time.deltaTime * _rotateSpeed);
	}
}
