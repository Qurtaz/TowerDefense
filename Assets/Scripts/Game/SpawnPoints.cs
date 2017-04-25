using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoints : MonoBehaviour {
    [SerializeField]
    private List<Wave> waves = new List<Wave>();
    public GameObject destination;
    public GameControler controler;
    public int actualWave = 0;
    [Header("UI")]
    public Text TimeText;
    public float deltaTime = 0.1f;
    private float time;
	// Use this for initialization
	void Start () {
        waves = controler.wawes;
        time = 2;
        StartCoroutine(StartRund());
	}
    IEnumerator StartRund()
    {   
        for(int z=0; z <= 5;)
        {
            Debug.Log(Time.deltaTime);
            Debug.Log("Rund" + actualWave);
            if (actualWave <= waves.Count)
            {
                if (time <= 0)
                {
                    yield return StartCoroutine(CreateWave());
                }
                time = time - deltaTime;
                yield return new WaitForSeconds(deltaTime);
            }
            else
            {
                z = 6;
            }
        }           
    }
    IEnumerator CreateWave()
    {
        if(actualWave >= waves.Count)
        {
            Debug.Log("Winn Game");

        }
        else
        {
            for (int z = 0; z <= waves[actualWave].howManyMonster; z++)
            {
                controler.money += 150;
                CreateMonster(waves[actualWave].prefab);
                time = controler.time;
                Debug.Log(time);
                yield return new WaitForSeconds(0.2f);
            }
            time = controler.time;
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
        TimeText.text = time.ToString();
	}
}
