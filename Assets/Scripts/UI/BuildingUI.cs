using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour {
    [SerializeField]
    private GameObject _target;
    public GameObject buttonPrefab;
    public GameObject contentBuilding;
    public GameObject ScrollViwe;
    public List<GameObject> Prefab;
    // Use this for initialization
    void Start()
    {
        foreach (GameObject n in Prefab)
        {
            GameObject butt = Instantiate(buttonPrefab);
            butt.transform.SetParent(contentBuilding.transform);
            butt.AddComponent<BuildingTowerButton>();
            BuildingTowerButton buildOpcion = butt.GetComponent<BuildingTowerButton>();
            buildOpcion.SetUi(this);
            buildOpcion.SetTowerPrefab(n);
            butt.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update () {
		if(_target == null)
        {
            ScrollViwe.SetActive(false);
        }
        else
        {
            ScrollViwe.SetActive(true);
        }
	}
    public void SetBuildingTarget(GameObject target)
    {
        _target = target;
    }
    public GameObject GetBuildingTarget()
    {
        return _target;
    }
}
