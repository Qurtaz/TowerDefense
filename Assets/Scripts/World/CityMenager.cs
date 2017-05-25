using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityMenager : MonoBehaviour {
    public City city;
    public WorldControler controler;
    public Material playerOwner;
    public Material enemyOwner;

    internal void Check(City cityP)
    {
        if (!city.neigbours.Contains(cityP))
        {
            city.neigbours.Add(cityP);
        }
    }

    public Material neutralOwner;
	// Use this for initialization
	void Start () {
        CityMAterial();

    }
    private void Update()
    {
        CityMAterial();
    }

    void Fight()
    {
        controler.data.fightCity = city;
        SceneManager.LoadScene(2);
    }
    public void Chose()
    {
        if(city.owner != ownership.Player)
        {
            Fight();
        }
        else
        {
            controler.BuyEquipment(this);
        }
    }

    private void CityMAterial()
    {
        if (city.owner == ownership.Player)
            GetComponent<Renderer>().material = playerOwner;
        if (city.owner == ownership.Enemy)
            GetComponent<Renderer>().material = enemyOwner;
        if (city.owner == ownership.Neutral)
            GetComponent<Renderer>().material = neutralOwner;
    }
}
