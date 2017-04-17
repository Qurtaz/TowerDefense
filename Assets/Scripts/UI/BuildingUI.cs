using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour {
    [SerializeField]
    private GameObject _target;

    public List<GameObject> Prefab;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetBuildingTarget(GameObject target)
    {
        _target = target;
    }
}
