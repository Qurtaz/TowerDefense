using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ListObject", menuName = "TransferData/ListObject")]
public class ListObject : ScriptableObject {

    public List<GameObject> monsters;
    public List<GameObject> tower;
    public List<GameObject> crystals;
    public City fightCity;
    public int star;
}
