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
    public Text rundCount;
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
            if (actualWave < waves.Count && controler.GetFinish() == false)
            {
                if (time <= 0)
                {
                    controler.money += 150;
                    yield return StartCoroutine(CreateWave());
                }
                time = time - deltaTime;
                yield return new WaitForSeconds(deltaTime);
            }
            else
            {
                destination.GetComponent<Finish>().FinishGame();
                z = 6;
                time = 0;
            }
        }           
    }
    IEnumerator CreateWave()
    {
        if(actualWave >= waves.Count)
        {
            destination.GetComponent<Finish>().FinishGame();

        }
        else
        {
            for (int z = 0; z <= waves[actualWave].howManyMonster; z++)
            {
                CreateMonster(waves[actualWave].GetMonster());
                time = controler.time;
                yield return new WaitForSeconds(0.2f);
            }
            time = controler.time;
            actualWave++;
        }
    }
	void CreateMonster(GameObject Prefab)
    {
        GameObject monsterObject = Instantiate(Prefab, transform.position, transform.rotation) as GameObject;
        monsterObject.transform.SetParent(transform);
        Monster monsterScripts = monsterObject.GetComponent<Monster>();
        monsterScripts.SetDescination(destination);
    }
	// Update is called once per frame
	void Update () {
        rundCount.text = "Round: " + (actualWave).ToString();
        TimeText.text = "Time to next wave: " + time.ToString("F2");
	}
    public  void NextRound()
    {
        time = 0;
    }
}
