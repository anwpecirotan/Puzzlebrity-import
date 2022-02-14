using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AreaSelectManager : MonoBehaviour
{
    public Text areaText;
    private String areaContent;
    public Button selectAreaButton;
    public ButtonManager theButtonManager;
    public GameObject[] continents;

    // Start is called before the first frame update
    void Start()
    {
        theButtonManager = FindObjectOfType<ButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        areaText.text = areaContent;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "areaBox")
        {
            areaContent = other.name;
        }
    }

    public void GoToLevel(string continent)
    {
        switch (continent)
        {
            case "Asia":
                {
                    continents[0].SetActive(true);
                    break;
                }
            case "Afrika":
                {
                    continents[1].SetActive(true);
                    break;
                }
            case "AmerikaUtara":
                {
                    continents[2].SetActive(true);
                    break;
                }
            case "Australia":
                {
                    continents[3].SetActive(true);
                    break;
                }
            case "Eropa":
                {
                    continents[4].SetActive(true);
                    break;
                }
            case "AsiaTenggara":
                {
                    continents[5].SetActive(true);
                    break;
                }
            case "AmerikaSelatan":
                {
                    continents[6].SetActive(true);
                    break;
                }
        }
    }

    public void PlayLevel(string levelName)
    {
        Application.LoadLevel(levelName);
    }

    public void CloseContinent()
    {
        for (int i = 0; i < continents.Length; i++)
        {
            continents[i].SetActive(false);
        }
    }

}
