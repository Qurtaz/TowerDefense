using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shoot : MonoBehaviour {
    private GameObject _target;
    private float _dmg;
    public float speed = 10;

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
    public void SetDmg(float dmg)
    {
        _dmg = dmg;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagGame.EnemyTag)
        {
            other.gameObject.GetComponent<Monster>().RecivedDmg(_dmg);
            Destroy(gameObject);
        }
    }
}
