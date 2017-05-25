using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldControler : MonoBehaviour {
    public ListObject data;
    public StarGame start;
    public City startCity;
    public List<City> neutralCity;
    public List<City> enemyCity;
    public GameObject buyEquipment;
    public Text star;
    public float time = 2;
    private float countdown;
    public GameObject finishPlane;

	// Use this for initialization
	void Start () {
        countdown = time;

        if (start.StartGame == true)
        {
            StartGame();
        }
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(star.text != data.star.ToString())
        {
            star.text = data.star.ToString();
        }
        if (countdown <= 0)
        {
            star.text = data.star.ToString() ;
            countdown = time;
            if(FinishGame())
            {
                finishPlane.SetActive(true);
            }
        }
	}
    private void StartGame()
    {
        start.StartGame = false;
        startCity.owner = ownership.Player;
        startCity.neigbours.Clear();
        foreach(City n in neutralCity)
        {
            n.owner = ownership.Neutral;
            n.neigbours.Clear();
        }
        foreach (City n in enemyCity)
        {
            n.owner = ownership.Enemy;
            n.neigbours.Clear();
        }
    }

    public void BuyEquipment(CityMenager city)
    {
        buyEquipment.SetActive(true);
        buyEquipment.GetComponent<BuyEquipmnetUI>().cityMenager = city;
        buyEquipment.GetComponent<BuyEquipmnetUI>().StartEquipment();
    }

    private bool FinishGame()
    {
        foreach(City z in enemyCity)
        {
            if(z.owner == ownership.Enemy)
            {
                return false;
            }
        }
        return true;
    }
    public void ActivePlane(GameObject data)
    {
        data.SetActive(true);
    }
}
