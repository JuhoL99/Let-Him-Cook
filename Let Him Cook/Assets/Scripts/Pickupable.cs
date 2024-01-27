using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    PickupDrop2 pickupScript;
    void Start()
    {
        pickupScript = GameObject.Find("Player").GetComponent<PickupDrop2>();
    }
    void GetInteracted()
    {
        pickupScript.PickUp(gameObject);
    }
}
