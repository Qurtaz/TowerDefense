using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public Color crystrColor;
    public Effect effect;
    public int difence;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ActiveEfect(GameObject target)
    {
        Effect ef = Instantiate(effect);
        List<Effect> z = target.GetComponent<Monster>().effects;
        if (z.Count == 0)
        {
            z.Add(ef);
            ef.ActiveEffect(target.GetComponent<Monster>());
        }
        Effect check = Exist(z, ef);
        if(check == null)
        {
            z.Add(ef);
            ef.ActiveEffect(target.GetComponent<Monster>());
        }
        else
        {
            check.AddTimeActive(ef.activeTime);
        }

    }

    public Effect Exist(List<Effect> p, Effect z)
        {
        foreach(Effect o in p)
        {
            if(o.nameObject == z.nameObject)
            {
                return o;
            }
        }
        return null;
        }
}
