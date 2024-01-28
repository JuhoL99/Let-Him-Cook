using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceBehaviour : MonoBehaviour
{
    public int spiceNum;
    public GameObject particleEffect;
    public Color spiceTextureColor;
    //PickupDrop2 pickupScript;
    Transform pickupSlot;
    //Vector3 rotation;
    void Start()
    {
        //pickupScript = GameObject.Find("Player").GetComponent<PickupDrop2>();
    }

    void Update()
    {
        
    }
    public void SpiceItUp()
    {
        Instantiate(particleEffect,transform);
        //rotation = transform.localRotation.eulerAngles;
        transform.parent.Rotate(new Vector3(0, 0, 90));
        pickupSlot = transform.parent;
        Invoke("UnrotateSpice", 0.5f);
    }
    void UnrotateSpice()
    {
        pickupSlot.Rotate(new Vector3(0, 0, -90));
    }
}
