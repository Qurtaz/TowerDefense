using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour {
    [SerializeField]
    private GameObject _target;
    public GameObject buttonPrefab;
    public GameObject contentBuilding;
    public List<GameObject> Prefab;
    // Use this for initialization
	void Start () {
		//foreach(GameObject n in Prefab)
  //      {
  //          GameObject butt = Instantiate(buttonPrefab);
  //          butt.transform.SetParent(contentBuilding.transform);
  //          butt.transform.localScale = new Vector3(1, 1, 1);
  //      }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetBuildingTarget(GameObject target)
    {
        _target = target;
    }
}
