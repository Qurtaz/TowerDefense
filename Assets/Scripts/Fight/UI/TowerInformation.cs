using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInformation : MonoBehaviour {
    public Text levelInformation;
    public Text damageInformation;
    public Text rangeInformation;
    public Text speedInformation;
    public Text crystalInformaton;

    public GameObject tower;
    public bool active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Data () {
        active = true;
        Debug.Log(active);
        levelInformation.text = "Level: " + tower.GetComponent<Tower>().level.ToString();
        damageInformation.text = "Damage: " + tower.GetComponent<Tower>().damage.ToString("F2");
        rangeInformation.text = "Range: " + tower.GetComponent<Tower>().rangeDistance.ToString("F2");
        speedInformation.text = "Shoot pre second: " + tower.GetComponent<Tower>().fireRate.ToString("F2");
        if(tower.GetComponent<Tower>().GetCrystal()== null)
        {
            crystalInformaton.text = "Crystal: Absence";
        }
        else
        {
            crystalInformaton.text = "Crystal: " + tower.GetComponent<Tower>().GetCrystal().effect.nameObject;
        }
        
	}
    public void UpdateDamega()
    {
        damageInformation.text = damageInformation.text + "<color=green> + " + tower.GetComponent<Tower>().GetUpgradeDemage().ToString("F2") + "</color>";
    }
    public void UpdateSpeed()
    {
        speedInformation.text = speedInformation.text + "<color=green> + " + tower.GetComponent<Tower>().GetUpgradeFireRate().ToString("F2") + "</color>";
    }
    public void UpdateRannge()
    {
        rangeInformation.text = rangeInformation.text + "<color=green> + " + tower.GetComponent<Tower>().GetUpgradeRanger().ToString("F2") + "</color>";
    }
}
