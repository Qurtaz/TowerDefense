using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour {
    public float hp;
    public GameControler controler;
    public Text Lives;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Lives.text = "Lives: " + hp.ToString();
		if(hp<=0)
        {
            Lost();
        }
	}
    void Lost()
    {
        controler.lost = true;
        controler.SetFinish(true);
    }
    public  void FinishGame()
    {
        StartCoroutine(Enemy());
    }
    IEnumerator Enemy()
    {
        int p = 0;
        for(int z=0; z<6;)
        {
            p = 0;
            GameObject[] enemy = GameObject.FindGameObjectsWithTag(TagGame.EnemyTag);
            foreach(GameObject e in enemy)
            {
                p++;
            }
            if(p==0 && controler.GetFinish() == false)
            {
                z = 7;
                controler.win = true;
                controler.SetFinish(true);
            }
            else
            {
                yield return new WaitForSeconds(2f);
            }
            yield return null;
        }
    }
    public void AddMOneyAfterKill(float money)
    {
        controler.money = controler.money + money;
    }
}
