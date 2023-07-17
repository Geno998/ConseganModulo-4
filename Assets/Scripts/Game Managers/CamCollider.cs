using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCollider : MonoBehaviour
{
    [SerializeField] GameObject CamToActivate;
    [SerializeField] GameObject CamTDeactivate1;
    [SerializeField] GameObject CamTDeactivate2;



    private void OnTriggerEnter(Collider other)
    {
        CamToActivate.SetActive(true);
        CamTDeactivate1.SetActive(false); 
        CamTDeactivate2.SetActive(false);
        Debug.Log("Collided");
    }
}
