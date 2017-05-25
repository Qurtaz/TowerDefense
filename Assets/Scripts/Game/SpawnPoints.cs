using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {
    public List<Wave> waves = new List<Wave>();
    public GameObject destination;
    public int actualWave = 0;
    public GameObject monster;
	// Use this for initialization
	void Start () {
        waves.Add(new Wave(10, monster));
	}
    public void StartRund()
    {
        //waves = w;
        Debug.Log("Start rund");
        StartCoroutine(CreateWave());
    }
    IEnumerator CreateWave()
    {
        if(actualWave >= waves.Count)
        {
            Debug.Log("Winn Game");

        }
        else
        {
            Debug.Log("Monster");
            for (int z = 0; z <= waves[actualWave].howManyMonster; z++)
            {
                CreateMonster(waves[actualWave].prefab);
                yield return new WaitForSeconds(0.2f);
            }
            actualWave++;
        }
    }
	void CreateMonster(GameObject Prefab)
    {
            GameObject monsterObject = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
            Monster monsterScripts = monsterObject.GetComponent<Monster>();
            monsterScripts.SetDescination(destination);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
