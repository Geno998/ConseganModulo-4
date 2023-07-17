using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class bot : MonoBehaviour
{

    [SerializeField] List<Bxes> boxes;
    [SerializeField] List<string> Items;
    List<string> currentRecipie;


    public int item1;
    public int item2;

    [SerializeField] Transform[] boxPositions;
    [SerializeField] Transform[] storagePositions;

    public Bxes currentBox1;
    public Bxes currentBox2;

    public Vector3 currentBoxPos1;
    public Vector3 currentBoxPos2;

    public Vector3 currentSroragePos1;
    public Vector3 currentSroragePos2;

    public Vector3 cookPlace;
    public Vector3 nextToBed;
    public Vector3 onBed;

    NavMeshAgent agent;
    request currentRequest;


    public bool hasItem1;
    public bool hasItem2;
    public bool sleeping;
    public bool hasStock;
    public bool NearBed;
    public bool isWorkTime;


    private Node topNode;
    int CurrentScore = -1;
    GameManager Gm;

    private void Start()
    {
        Gm = GameManager.Instance;
        currentRequest = GameManager.Instance.requstRef;
        agent = GetComponent<NavMeshAgent>();
        //ConstructBehaviourTree();
    }



    private void Update()
    {
        CalculateWorkTime();
        Refreshtree();
        SeeCurrentRequest();
        selectItem1();
        selectItem2();
        defineBoxes();

        topNode.Evaluate();
    }


    private void ConstructBehaviourTree()
    {
        isSleepingNode isSleepingN = new isSleepingNode(this);
        IsWorkTimeNode isWorkTimeN = new IsWorkTimeNode(this);
        hasItem1Node hasItem1N = new hasItem1Node(this);
        hasItem2Node hasItem2N = new hasItem2Node(this);
        boxFull1Node boxFull1N = new boxFull1Node(currentBox1);
        boxFull2Node boxFull2N = new boxFull2Node(currentBox2);
        wakeUpNode wakeUpN = new wakeUpNode(nextToBed, transform, this);
        goToSleepNode goToSleepN = new goToSleepNode(nextToBed, onBed, agent, this, transform);
        takeItem1Node takeItem1N = new takeItem1Node(currentBox1, currentSroragePos1, agent, this);
        takeItem2Node takeItem2N = new takeItem2Node(currentBox2, currentSroragePos2, agent, this);
        replenishShelf1Node replenishShelf1N = new replenishShelf1Node(currentBox1, currentSroragePos1, currentBoxPos1, this, agent);
        replenishShelf2Node replenishShelf2N = new replenishShelf2Node(currentBox2, currentSroragePos2, currentBoxPos2, this, agent);
        CookNode cookN = new CookNode(cookPlace, agent, this, currentRequest, GameManager.Instance);




        Selector SleepSelector = new Selector(new List<Node> { isSleepingN, goToSleepN });





        Sequence itemOnShelf2Selector = new Sequence(new List<Node> { boxFull2N, replenishShelf2N });
        Selector takeItem2BotSequence = new Selector(new List<Node> { itemOnShelf2Selector, takeItem2N });
        Inverter hasItem2Inverter = new Inverter(hasItem2N);
        Sequence takeItem2TopSequence = new Sequence(new List<Node> { hasItem2Inverter, takeItem2BotSequence });

        Sequence itemOnShelf1Selector = new Sequence(new List<Node> { boxFull1N, replenishShelf1N });
        Selector takeItem1BotSequence = new Selector(new List<Node> { itemOnShelf1Selector, takeItem1N });
        Inverter hasItem1Inverter = new Inverter(hasItem1N);
        Sequence takeItem1TopSequence = new Sequence(new List<Node> { hasItem1Inverter, takeItem1BotSequence });

        Sequence coockSequence = new Sequence(new List<Node> { hasItem1N, hasItem2N, cookN });

        Selector WorkSelector = new Selector(new List<Node> { coockSequence, takeItem1TopSequence, takeItem2TopSequence });

        Inverter isSleepingInverter = new Inverter(isSleepingN);
        Selector isSleepingSelector = new Selector(new List<Node> { isSleepingInverter, wakeUpN });

        Sequence workSequence = new Sequence(new List<Node> { isWorkTimeN, isSleepingSelector, WorkSelector });



        topNode = new Selector(new List<Node> { workSequence, SleepSelector });
    }

    void Refreshtree()
    {
        if (CurrentScore < Gm.Score)
        {
            SeeCurrentRequest();
            selectItem1();
            selectItem2();
            defineBoxes();
            ConstructBehaviourTree();
            CurrentScore = Gm.Score;
        }
    }

    void CalculateWorkTime()
    {
        if (Gm.GlobalTimeH > 7 && Gm.GlobalTimeH < 23)
        {
            isWorkTime = true;
        }
        else
        {
            isWorkTime = false;
        }
    }
    void SeeCurrentRequest()
    {
        currentRecipie = currentRequest.currentRecipe;
    }

    void selectItem1()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == currentRecipie[0])
            {
                item1 = i;
            }
        }
    }

    void selectItem2()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == currentRecipie[1])
            {
                item2 = i;
            }
        }
    }


    void defineBoxes()
    {
        currentBox1 = boxes[item1];
        currentBox2 = boxes[item2];

        currentBoxPos1 = storagePositions[item1].position;
        currentBoxPos2 = storagePositions[item2].position;

        currentSroragePos1 = boxPositions[item1].position;
        currentSroragePos2 = boxPositions[item2].position;
    }

    public void TakeItem1()
    {
        currentBox1.currentItems--;

    }

    public void TakeItem2()
    {
        currentBox2.currentItems--;

    }
}
