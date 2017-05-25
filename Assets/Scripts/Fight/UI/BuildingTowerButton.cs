using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTowerButton : MonoBehaviour {

    [SerializeField]
    private BuildingUI _ui;
    [SerializeField]
    private GameObject _towerPrefab;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(Building);
	}
    public void SetUi(BuildingUI ui)
    {
        _ui = ui;
    }
	public void SetTowerPrefab(GameObject tower)
    {
        _towerPrefab = tower;
    }
	private void Building()
    {
        GameObject target = _ui.GetBuildingTarget();
        if (target.GetComponent<Node>().GetTower() == null)
        {
            GameObject tower = Instantiate(_towerPrefab, target.transform.position + new Vector3(0,0.1f,0), target.transform.rotation);
            tower.transform.parent = target.transform;
            tower.transform.position = new Vector3(tower.transform.position.x, 1, tower.transform.position.z);
            if(!target.GetComponent<Node>().SetTower(tower))
            {
                Destroy(tower);
            }
            _ui.SetBuildingTarget(null);
        }
        else
        {
            Debug.Log("You cant build");
        }
    }
}
