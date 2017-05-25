using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyEquipmnetUI : MonoBehaviour {
    public CityMenager cityMenager;
    public WorldControler controler;
    [Header("UIElements")]
    public GameObject crystalPlane;
    public GameObject towerPlane;
    public Text cityName;
    private List<GameObject> towersButton = new List<GameObject>();
    private List<GameObject> crystalsButton= new List<GameObject>();
    [Header("Prefab")]
    public GameObject prefabUITOwer;
    public GameObject prefabUICrystal;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void Run()
    {
        cityName.text = cityMenager.city.name;
        GameObject check;
        foreach(GameObject p in cityMenager.city.towerToUnlock)
        {
            check = CheckTower(p);
            if (check == null)
            {
                GameObject z = Instantiate(prefabUITOwer);
                z.transform.SetParent(towerPlane.transform, false);
                z.GetComponent<TowersButtonUIWorld>().tower = p;
                towersButton.Add(z);
                z.GetComponent<TowersButtonUIWorld>().buyEguipment = this;
            }
        }
        foreach(GameObject p in cityMenager.city.crystalToUnlock)
        {
            check = CheckTower(p);
            if (check == null)
            {
                GameObject z = Instantiate(prefabUICrystal);
                z.transform.SetParent(crystalPlane.transform, false);
                z.GetComponent<CrystalButtonUIWorld>().crystal = p;
                crystalsButton.Add(z);
                z.GetComponent<CrystalButtonUIWorld>().buyEguipment = this;
            }
        }

    }

    public void StartEquipment()
    {
        Clear();
        Run();
    }

    private void Clear()
    {
        if(towersButton.Count>0)
        foreach(GameObject z in towersButton)
        {
            Destroy(z);
        }
        towersButton.Clear();
        if (towersButton.Count > 0)
        foreach (GameObject p in crystalsButton)
        {
            Destroy(p);
        }
        crystalsButton.Clear();
    }
    public void  BuyTower(GameObject z)
    {
        GameObject zw = CheckTower(z);
        towersButton.Remove(zw);
        cityMenager.city.towerToUnlock.Remove(z);
        controler.data.tower.Add(z);
        Destroy(zw);
    }
    public void BuyCrystal(GameObject z)
    {
        GameObject zw = CheckCrystal(z);
        crystalsButton.Remove(zw);
        cityMenager.city.crystalToUnlock.Remove(z);
        controler.data.crystals.Add(z);
        Destroy(zw);
    }
    GameObject CheckTower(GameObject z)
    {
        foreach (GameObject zw in towersButton)
        {
            if (zw.GetComponent<TowersButtonUIWorld>().tower == z)
            {
                return zw;
            }
        }
        return null;
    }
    GameObject CheckCrystal(GameObject z)
    {
        foreach (GameObject zw in crystalsButton)
        {
            if (zw.GetComponent<CrystalButtonUIWorld>().crystal == z)
            {
                return zw;
            }
        }
        return null;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
