using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour {
    [Header("Level data")]
    public float money;
    public float time;
    public List<Wave> wawes = new List<Wave>();
    [SerializeField]
    private bool _finish = false;
    [SerializeField]
    private bool _lost = false;
    [SerializeField]
    private bool _win = false;

    [Header("List tower and monsters")]
    public ListObject data;

    [Header("UI Data")]
    public GameObject finishPanel;
    public Color winColor;
    public Color lostColor;
    public Text finishInformaion;
    public Text moneyInformation;
    public List<GameObject> inventory;

    public bool win
    {
        get
        {
            return _win;
        }

        set
        {
            _win = value;
        }
    }

    public bool lost
    {
        get
        {
            return _lost;
        }

        set
        {
            _lost = value;
        }
    }

    public void Finish()
    {
        if(_win == true)
        {
            data.fightCity.conquered = true;
            data.fightCity.owner = ownership.Player;
        }
        SceneManager.LoadScene(1);
    }
    public void SetFinish(bool finish)
    {
        _finish = finish;
        if (_lost == true)
        {
            finishPanel.SetActive(true);
            finishPanel.GetComponent<Image>().color = lostColor;
            finishInformaion.text = " Lost Game";
        }
        if (_win == true)
        {
            finishPanel.SetActive(true);
            finishPanel.GetComponent<Image>().color = winColor;
            finishInformaion.text = " Win Game";
        }
    }
    public bool GetFinish()
    {
        return _finish;
    }
    // Use this for initialization
    void Start () {
		foreach(Wave w in wawes)
        {
            List<GameObject> chose = new List<GameObject>();
            foreach(GameObject z in data.monsters)
            {
                if(z.GetComponent<Monster>().type == w.type)
                {
                    chose.Add(z);
                }
            }
            int war = Random.Range(0, chose.Count - 1);
            w.SetMonster(chose[war]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        moneyInformation.text = "Money: " + money.ToString();
	}

}
