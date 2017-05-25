using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalButtonUI : MonoBehaviour {
    public Text crystalname;
    public GameObject crystal;
    public GameObject tower;
    public InventoryUI inventoryUI;
    public int howMany;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        crystalname.text = crystal.GetComponent<Crystal>().effect.nameObject + "  crystal\n" + howMany;
	}
    public void AddCrystal()
    {
        GameObject p = Instantiate(crystal, tower.transform.position + new Vector3(0, 2.25f, 0), transform.rotation);
        tower.GetComponent<Tower>().SetCrysta(p.GetComponent<Crystal>());
        inventoryUI.Remove(gameObject);
    }
}
