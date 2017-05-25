using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Monster : MonoBehaviour {
    private NavMeshAgent _agent;
    public TypeMonster type;
    [Header("MOnster data")]
    public float speed;
    [Range(0,800)]
    public float hp = 1000;
    public float armor = 10;
    public Slider lifeBar;
    [Header("After kill && efect")]
    public float moneyForKill;
    public List<Effect> effects = new List<Effect>();
    private GameObject drPo;
    [Range(0.1f,1f)]
    public float dropRate;

	// Use this for initialization
	void Awake () {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        lifeBar.maxValue = hp;
    }
	public void SetDescination(GameObject dr)
    {
        drPo = dr;
        _agent.SetDestination(drPo.transform.position);
    }
	// Update is called once per frame
	void Update () {
        _agent.speed = speed;
        lifeBar.value = hp;
        foreach(Effect z in effects)
        {
            if(z.active == false)
            StartCoroutine(Doing(z));
        }
	    if(_agent.remainingDistance <= 0.5f)
        {
            drPo.GetComponent<Finish>().hp--;
            Destroy(gameObject);
        }
        if(hp <= 0)
        {
            drPo.GetComponent<Finish>().AddMOneyAfterKill(moneyForKill);
            if (drPo.GetComponent<Finish>().controler.data.crystals.Count > 0)
            {
                float z = Random.Range(0, 100);
                if (z <= dropRate*100)
                {
                    int p = Random.Range(0, drPo.GetComponent<Finish>().controler.data.crystals.Count - 1);
                    drPo.GetComponent<Finish>().controler.inventory.Add(drPo.GetComponent<Finish>().controler.data.crystals[p]);
                }
            }
            Destroy(gameObject);
        }
	}
    public void RecivedDmg(float dmg)
    {
        hp = hp - dmg / armor;
    }
    public IEnumerator Doing(Effect z)
    {
        z.active = true;
        bool loop = false;
        if (z.singleActiwation == true)
        {

            yield return StartCoroutine(z.Active());
            while (!loop)
            {
                if (z.clotdown < 0)
                {
                    z.activeTime -= 1;
                    z.clotdown = z.time;
                    if (z.activeTime <= 0)
                    {
                        loop = true;
                        yield return StartCoroutine(z.DeacitiveEffect());
                    }
                }
             z.clotdown -= Time.deltaTime;
             yield return null;
            }

        }
        else
        {
            while (!loop)
            {
                if (z.clotdown < 0)
                {
                    z.clotdown = z.time;
                    z.activeTime -= 1;
                    if (z.activeTime <= 0)
                    {
                        loop = true;
                        yield return StartCoroutine(z.DeacitiveEffect());
                    }
                    yield return StartCoroutine(z.Active());
                }
                z.clotdown -= Time.deltaTime;
                yield return null;
            }
        }
    }
}
