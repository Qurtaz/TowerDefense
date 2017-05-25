using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Friezing", menuName = "Effect/Friezing")]
public class Freez : Effect {
    public float speed = 0;
    private float oldSpeed;
    void Start()
    {
        nameObject = "Freez";
    }
    override public IEnumerator Active()
    {
        oldSpeed = base.monster.speed;
        base.monster.speed = speed;
        yield return null;
    }
    override public IEnumerator Deactive()
    {
        base.monster.speed = oldSpeed;
        yield return null;
    }
}
