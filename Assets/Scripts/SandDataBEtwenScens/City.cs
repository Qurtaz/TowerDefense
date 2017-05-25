using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "City", menuName = "TransferData/City")]
public class City : ScriptableObject {

    public bool conquered;
    public bool bound;
    public ownership owner;

    public List<City> neigbours;

    public List<GameObject> towerToUnlock;
    public List<GameObject> monsterToUnlock;
    public List<GameObject> crystalToUnlock;

    public bool ChoseFight()
    {
        foreach(City n in neigbours)
        {
            if(n.owner == ownership.Player && n.ChoseFight())
            {
                return true;
            }
        }
        return false;
    }
}
