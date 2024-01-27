using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookerBehaviour : MonoBehaviour
{
    PickupDrop2 pickupScript;
    void Start()
    {
        pickupScript = GameObject.Find("Player").GetComponent<PickupDrop2>();
    }
    void GetInteracted()
    {

    }
}
