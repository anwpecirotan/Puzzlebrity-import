using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{
    public Image AdsImage;
    public Sprite[] Ads;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Ads") % 2 == 0)
        {
            AdsImage.sprite = Ads[0];
        }
        else
        {
            AdsImage.sprite = Ads[1];
        }
        PlayerPrefs.SetInt("Ads", (PlayerPrefs.GetInt("Ads") + 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
