using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    private int layerMask = 1 << 8;
    float distance = 300;
    public GameObject cam;
    public BuildingUI buildingUI;

	// Use this for initialization
	void Start () {
        //layerMask = ~layerMask;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        if (Physics.Raycast(ray.origin, ray.direction, out hit, distance,layerMask))
        {
            if(Input.GetMouseButtonDown(0))
            {
                
                GameObject po = hit.transform.gameObject;
                buildingUI.SetBuildingTarget(po);
            }
        }
    }
}
