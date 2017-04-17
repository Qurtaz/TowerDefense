using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Wave {

    public int howManyMonster;
    public GameObject prefab;

    public Wave(int how, GameObject p)
    {
        howManyMonster = how;
        prefab = p;
    }
}
