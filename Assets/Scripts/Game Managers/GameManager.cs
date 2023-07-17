using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(_instance);
            }
            return _instance;
        }
    }



    request _requstRef;
    bot _botRef;

    public request requstRef { get { return _requstRef; } set { _requstRef = value; } }
    public bot botRef { get { return _botRef; } set { _botRef = value; } }



    private void Awake()
    {
        _instance = this;


        _requstRef = FindObjectOfType<request>();
        _botRef = FindObjectOfType<bot>();
    }



    public int GlobalTimeH = 8;
    public float GlobalTimeM;

    public int Score;

    private void Update()
    {
        AdvanceTime();
    }

    void AdvanceTime()
    {
        if (botRef.sleeping)
        {
            GlobalTimeM += Time.deltaTime * 50;
        }
        else
        {
            GlobalTimeM += Time.deltaTime * 5;
        }



        if (GlobalTimeM >= 60)
        {
            GlobalTimeH++;
            GlobalTimeM = 0;
        }

        if (GlobalTimeH == 25)
        {
            GlobalTimeH = 0;
        }
    }

    public int getCurrentH()
    {
        return GlobalTimeH;
    }



}
