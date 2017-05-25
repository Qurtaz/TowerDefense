using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    [SerializeField]
    private GameObject _tower;

    public void SetTower(GameObject tower)
    {
        _tower = tower;
    }
    public void DestroyTower()
    {
        Destroy(_tower);
        _tower = null;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
