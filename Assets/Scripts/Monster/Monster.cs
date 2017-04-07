using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Monster : MonoBehaviour {
    private NavMeshAgent _agent;
    public float speed;
    public float hp = 100;
    public float armor = 10;
    GameObject drPo;
	// Use this for initialization
	void Awake () {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;
    }
	public void SetDescination(GameObject dr)
    {
        drPo = dr;
        _agent.SetDestination(drPo.transform.position);
    }
	// Update is called once per frame
	void Update () {
	    if(_agent.remainingDistance <= 0.5f)
        {
            Destroy(gameObject);
        }
	}
    public void recivedDmg(float dmg)
    {
        hp = hp - dmg / armor;
    }
}
