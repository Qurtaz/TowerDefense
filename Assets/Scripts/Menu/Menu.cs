using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject menu;
    public GameObject option;
    public GameObject credits;
    public StarGame data;
	public void NewGame()
    {
        data.StartGame = true;
        SceneManager.LoadScene(1);
    }
    public void Option()
    {
        menu.SetActive(false);
        option.SetActive(true);
    }
    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void ExitChose(GameObject t)
    {
        menu.SetActive(true);
        t.SetActive(false);

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadLastGame()
    {
        data.StartGame = false;
        SceneManager.LoadScene(1);
    }
}
