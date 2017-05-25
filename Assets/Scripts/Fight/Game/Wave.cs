using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave {
    [Range(1,40)]
    public int howManyMonster;
    [SerializeField]
    private GameObject prefab;
    public TypeMonster type;

    public void SetMonster(GameObject z)
    {
        prefab = z;
    }
    public GameObject GetMonster()
    {
        return prefab;
    }
}
