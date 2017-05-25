using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Slowing",menuName = "Effect/Slowing")]
public class Slowing : Effect {
    public float slowRate = 2;
    void Start()
    {
        nameObject = "Slowing";
    }
    override public IEnumerator Active()
    {
        base.monster.speed /= slowRate;
        yield return null;
    }
    override public IEnumerator Deactive()
    {
        base.monster.speed *= slowRate;
        yield return null;
    }
}
