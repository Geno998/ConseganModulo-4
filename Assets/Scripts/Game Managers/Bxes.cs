using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bxes : MonoBehaviour
{
    [SerializeField] Image bar;
    public float currentItems;
    public float maxItems = 5;

    public bool empty;

    private void Start()
    {
        currentItems = maxItems;
    }


    private void Update()
    {
        if (currentItems <= 0)
        {
            empty = true;
        }
        else
        {
            empty = false;
        }



        bar.fillAmount =  currentItems / maxItems;
    }
}
