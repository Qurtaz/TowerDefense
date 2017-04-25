using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave {
    [Range(1,40)]
    public int howManyMonster;
    public GameObject prefab;

    public Wave(int how, GameObject p)
    {
        howManyMonster = how;
        prefab = p;
    }
}
