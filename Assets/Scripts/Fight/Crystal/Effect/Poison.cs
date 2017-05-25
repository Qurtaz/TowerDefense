using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Poisining", menuName = "Effect/Poisoning")]
public class Poison : Effect {
    public float damagePreSecond;
    void Start()
    {
        nameObject = "Poison";
    }
    override public IEnumerator Active()
    {
        base.monster.hp -= damagePreSecond;
        yield return null;
    }
    override public IEnumerator Deactive()
    {
        yield return null;
    }
}
