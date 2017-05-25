using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour {
    [SerializeField]
    private GameObject _target;
    public GameObject buttonPrefab;
    public GameObject contentBuilding;
    public GameObject scrollViwe;
    public GameObject upgradePlane;
    public GameObject towerInformation;
    public GameObject addCrystal;
    public GameObject crystalPlane;
    public List<GameObject> Prefab;
    public GameControler controler;
    // Use this for initialization
    public GameObject GetTower()
    {
        if (_target != null)
            return _target.GetComponent<Node>().GetTower();
        else
            return null;
    }
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
            DeactiveAllPanel();
        }
        else
        {
            if(_target.GetComponent<Node>().GetTower() == null)
            {
                DeactiveAllPanel();
                scrollViwe.SetActive(true);
            }
            else
            {
                DeactiveAllPanel("z");
                upgradePlane.SetActive(true);
                towerInformation.SetActive(true);
                towerInformation.GetComponent<TowerInformation>().tower = _target.GetComponent<Node>().GetTower();
                if(_target.GetComponent<Node>().GetTower().GetComponent<Tower>().GetCrystal() == null && controler.inventory.Count != 0)
                {
                    addCrystal.SetActive(true);
                }
                else
                {
                    addCrystal.SetActive(false);
                }
                if (towerInformation.GetComponent<TowerInformation>().active == false)
                {
                    towerInformation.GetComponent<TowerInformation>().Data();
                }

            }
        }
	}
    public void SetBuildingTarget(GameObject target)
    {
        _target = null;
        _target = target;
    }
    public GameObject GetBuildingTarget()
    {
        return _target;
    }

    public void UpgradeRange()
    {
        Tower t = _target.GetComponent<Node>().GetTower().GetComponent<Tower>();
        if(controler.money - t.upgradeRangeCost > 0)
        {
            controler.money -= t.upgradeRangeCost;
            t.UpgradeRanger();
        }
        else
        {
            Debug.Log("To small money");
        }
        _target = null;
    }

    public void UpgradeDemage()
    {
        Tower t = _target.GetComponent<Node>().GetTower().GetComponent<Tower>();
        if (controler.money - t.upgradeDamegeCost > 0)
        {
            controler.money -= t.upgradeDamegeCost;
            t.UpgradeDemage();
        }
        else
        {
            Debug.Log("To small money");
        }
        _target = null;
    }
    public void UpgradeSpeed()
    {
        Tower t = _target.GetComponent<Node>().GetTower().GetComponent<Tower>();
        if (controler.money - t.upgradeFireRateCost > 0)
        {
            controler.money -= t.upgradeFireRateCost;
            t.UpgradeFireRate();
        }
        else
        {
            Debug.Log("To small money");
        }
        _target = null;
    }
    public void UpgradeTower()
    {
        _target.GetComponent<Node>().GetTower();
        _target = null;
    }
    public void DestroyTower()
    {
        Destroy(_target.GetComponent<Node>().GetTower());
        _target = null;
    }
    void DeactiveAllPanel()
    {
        scrollViwe.SetActive(false);
        upgradePlane.SetActive(false);
        towerInformation.GetComponent<TowerInformation>().active = false;
        towerInformation.SetActive(false);
    }
    void DeactiveAllPanel(string z)
    {
        scrollViwe.SetActive(false);
        upgradePlane.SetActive(false);
        towerInformation.SetActive(false);
    }
    public void AddCrystal()
    {
        crystalPlane.SetActive(true);
    }
}
