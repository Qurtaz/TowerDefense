using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Effect : ScriptableObject {

    public string nameObject;
    public float activeTime;
    protected Monster monster;
    public bool infinityAcive = true;
    public bool singleActiwation;
    public float time = 1;
    public float clotdown;
    public bool active;


    public void ActiveEffect(Monster monst)
    {
        monster = monst;
        clotdown = time;
        //monster.StartCoroutine(Doing());
    }
   
    virtual public  IEnumerator Active()
    {
        yield return null;
    }
    virtual  public  IEnumerator  Deactive()
    {
        yield return null;
    }
    public void AddTimeActive(float time)
    {
        activeTime += time;
    }

    public IEnumerator  DeacitiveEffect()
    {
        monster.effects.Remove(this);
        monster.StartCoroutine(Deactive());
        Destroy(this);
        yield return null;
    }
}
