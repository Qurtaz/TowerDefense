using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    private int Building_Mask = 1 << 8;
    private int UI_Mask = 1 << 5;
    float distance = 300;
    public GameObject cam;
    public BuildingUI buildingUI;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //if (Physics.Raycast(ray.origin, ray.direction, out hit, distance, UI_Mask))
        //{
        //    Debug.Log("UI");
        //    return;
        //}
        //if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        if (Physics.Raycast(ray.origin, ray.direction, out hit, distance, Building_Mask))
        {
            if(Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == TagGame.BuildingGrundTag)
            {
                
                GameObject po = hit.transform.gameObject;
                Debug.Log(po);
                buildingUI.SetBuildingTarget(po);
            }
        }
    }
}
