using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController TheBgmController;
    public AudioSource BGM;

    public static BGMController Instance
    {
        get { return TheBgmController; }
    }

    private void Awake()
    {
        if (TheBgmController == null)
        {
            TheBgmController = this;
        }
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "Prototype")
        {
            BGM.Stop();
        }
        else {
            if (BGM.isPlaying == false)
            {
                BGM.Play();
            }
        }
    }
}
