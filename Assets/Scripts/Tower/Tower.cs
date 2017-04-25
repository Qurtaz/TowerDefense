using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public float cost;
    [Header("Ranger")]
    public GameObject range;
    public float rangeDistance = 10;
    [Header("Shoot Atribute")]
    [SerializeField]
    private GameObject _target;
    [Range(0.001f,50)]
    public float fireRate = 0.02f;
    [SerializeField]
    private float atackColdown;
    public float damage;

    [Header("Bulet Data")]
    [SerializeField]
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    [Header("Rotation")]
    public GameObject partToRotation;
    public int speedRotation;


    // Use this for initialization
    void Start () {
        range = gameObject;
        range.GetComponent<SphereCollider>().radius = rangeDistance;
	}
	
	// Update is called once per frame
	void Update () {
		if(_target == null)
        {
            return;
        }
        else
        {
            Vector3 dir = _target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotation.transform.rotation, lookRotation, Time.deltaTime *speedRotation).eulerAngles;
            partToRotation.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(_target == null && other.gameObject.tag == TagGame.EnemyTag)
        {
            _target = other.gameObject;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(_target == null && other.gameObject.tag == TagGame.EnemyTag)
        {
            _target = other.gameObject;
        }
        else
        {
            if (_target != null && _target.tag == TagGame.EnemyTag && other.gameObject == _target)
            {
                if(atackColdown <= 0)
                {
                    Shoot();
                    atackColdown = 1f / fireRate;
                }
                atackColdown = atackColdown - Time.deltaTime;
            }
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (_target == other.gameObject)
        {
            _target = null;
        }
    }
    void Shoot()
    {
         GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
        Shoot buteltScript = bullet.GetComponent<Shoot>();
            if(buteltScript != null)
        {
            buteltScript.SetTarget(_target);
            buteltScript.SetDmg(damage);
        }
        
    }
}
