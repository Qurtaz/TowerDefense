using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public GameObject prefabUI;
    public GameControler controler;
    [SerializeField]
    List<GameObject> button;
    private GameObject check;
    public BuildingUI buildingUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(buildingUI.GetTower() != null)
        {
            foreach (GameObject p in controler.inventory)
            {
                check = Check(p);
                if (check == null)
                {
                    GameObject z = Instantiate(prefabUI);
                    z.transform.SetParent(transform, false);
                    z.GetComponent<CrystalButtonUI>().crystal = p;
                    button.Add(z);
                    z.GetComponent<CrystalButtonUI>().tower = buildingUI.GetTower();
                    z.GetComponent<CrystalButtonUI>().inventoryUI = this;
                    z.GetComponent<CrystalButtonUI>().howMany = HowMany(p);
                }
                else
                {
                    check.GetComponent<CrystalButtonUI>().tower = buildingUI.GetTower();
                    check.GetComponent<CrystalButtonUI>().howMany = HowMany(p);
                }
            }
        }
		else
        {
            gameObject.SetActive(false);
        }
	}
    public int HowMany(GameObject z)
    {
        int war = 0;
        foreach(GameObject p in controler.inventory)
        {
            if(p == z)
            {
                war++;
            }
           
        }
        return war;
    }

    GameObject Check(GameObject z)
    {
        foreach(GameObject zw in button)
        {
            if(zw.GetComponent<CrystalButtonUI>().crystal == z)
            {
                return zw;
            }
        }
        return null;
    }

    public void Remove(GameObject z)
    {
        controler.inventory.Remove(z.GetComponent<CrystalButtonUI>().crystal);
        button.Remove(z);
        Destroy(z);
        gameObject.SetActive(false);
    }

}
