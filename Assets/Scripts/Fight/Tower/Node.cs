using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    [SerializeField]
    private GameObject _tower;
    [SerializeField]
    private GameControler control;
    public Material towerBuild;
    public Material grass;

    public bool SetTower(GameObject tower)
    {
        if(control.money >= tower.GetComponent<Tower>().cost)
        {
            _tower = tower;
            control.money -= tower.GetComponent<Tower>().cost;
            GetComponent<Renderer>().material = towerBuild;
            return true;
        }
        else
        {
            Debug.Log("NIE MASZ pieniedy");
            return false;
        }
        
    }
    public GameObject GetTower()
    {
        return _tower;
    }
    public void DestroyTower()
    {
        Destroy(_tower);
        _tower = null;
        GetComponent<Renderer>().material = grass;
    }
	// Use this for initialization
	void Start () {
        control = GetComponentInParent<GameControler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
