using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorNeibour : MonoBehaviour {
    public CityMenager menager;

    void OnTriggerStay(Collider other)
    {
        if(other.tag== TagGame.City)
        {
            menager.Check(other.GetComponent<CityMenager>().city);
        }
    }

}
