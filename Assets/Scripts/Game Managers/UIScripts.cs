using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScripts : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Timer;
    [SerializeField] TextMeshProUGUI recipe;
    [SerializeField] TextMeshProUGUI ing1;
    [SerializeField] TextMeshProUGUI ing2;
    [SerializeField] TextMeshProUGUI score;

    GameManager Gm;
    request request;
    bot botRef;

    [SerializeField] List<GameObject> slot1Items;
    [SerializeField] List<GameObject> slot2Items;
    [SerializeField] List<GameObject> stock1Items;
    [SerializeField] List<GameObject> stock2Items;

    [SerializeField] GameObject StockItemsMult;


    private void Start()
    {
        Gm = GameManager.Instance;
        request = Gm.requstRef;
        botRef = Gm.botRef;
    }

    private void Update()
    {
        updateTexts();
        updateInventory();
    }

    void updateTexts()
    {
        Timer.text = new string(Gm.GlobalTimeH + " : " + Mathf.RoundToInt(Gm.GlobalTimeM));

        recipe.text = request.currentRecipeSO.dishName;
        ing1.text = request.currentRecipe[0];
        ing2.text = request.currentRecipe[1];
        score.text = new string("Score:" + Gm.Score);

    }


    void updateInventory()
    {
        if (!botRef.hasItem1)
        {
            for (int i = 0; i < slot1Items.Count; i++)
            {
                slot1Items[i].SetActive(false);
            }

            if (!botRef.hasStock)
            {
                for (int i = 0; i < stock2Items.Count; i++)
                {
                    stock1Items[i].SetActive(false);
                    stock2Items[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < stock2Items.Count; i++)
                {
                    slot2Items[i].SetActive(false);
                }

                for (int i = 0; i < stock1Items.Count; i++)
                {

                    if (i == botRef.item1)
                    {
                        stock1Items[i].SetActive(true);
                    }
                    else
                    {
                        stock1Items[i].SetActive(false);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < slot1Items.Count; i++)
            {

                if (i == botRef.item1)
                {
                    slot1Items[i].SetActive(true);
                }
                else
                {
                    slot1Items[i].SetActive(false);
                }
            }

            if (!botRef.hasStock)
            {
                for (int i = 0; i < stock1Items.Count; i++)
                {
                    stock1Items[i].SetActive(false);
                    stock2Items[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < stock1Items.Count; i++)
                {
                    slot1Items[i].SetActive(false);
                }

                for (int i = 0; i < stock2Items.Count; i++)
                {

                    if (i == botRef.item2)
                    {
                        stock2Items[i].SetActive(true);
                    }
                    else
                    {
                        stock2Items[i].SetActive(false);
                    }
                }
            }
        }


        if (!botRef.hasItem2)
        {
            for (int i = 0; i < slot2Items.Count; i++)
            {
                slot2Items[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < slot2Items.Count; i++)
            {

                if (i == botRef.item2)
                {
                    slot2Items[i].SetActive(true);
                }
                else
                {
                    slot2Items[i].SetActive(false);
                }
            }
        }

        if (!botRef.hasStock)
        {
            StockItemsMult.SetActive(false);
        }
        else
        {
            StockItemsMult.SetActive(true);
        }

    }




}
