using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse : MonoBehaviour {

    float distance = 300;
    public GameObject cam;

    // Use this for initialization
    void Start()
    {
        //layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!EventSystem.current.IsPointerOverGameObject())
            if (Physics.Raycast(ray.origin, ray.direction, out hit, distance))
            {
            GameObject po = hit.transform.gameObject;
            if (Input.GetMouseButtonDown(0) && po.tag == TagGame.City)
                {
                po.GetComponent<CityMenager>().Chose();
                }
            }
    }
}
