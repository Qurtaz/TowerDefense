using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [Header("Ranger")]
    public GameObject range;
    public float rangeDistance = 10;
    [Header("Shoot Atribute")]
    [SerializeField]
    private GameObject _target;
    public float fireRate;
    [SerializeField]
    private float atackColdown = 2f;
    public float damage;
    public string enemyTag;

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
        if(_target == null && other.gameObject.tag == enemyTag)
        {
            _target = other.gameObject;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(_target == null && other.gameObject.tag == enemyTag)
        {
            _target = other.gameObject;
        }
        else
        {
            if (_target != null && _target.tag == enemyTag)
            {
                if(atackColdown <= 0)
                {
                    StartCoroutine(Shoot());
                }
                atackColdown =- Time.deltaTime;
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
    IEnumerator Shoot()
    {
        Debug.Log("Shoot");
         GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
        Shoot buteltScript = bullet.GetComponent<Shoot>();
        buteltScript.SetTarget(_target);
        buteltScript.SetDmg(damage);
        atackColdown = 1f / fireRate;
        yield return new WaitForSeconds(atackColdown);
    }
}
