using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();
    }

    void Update()
    {
        InteractCheck();
    }
    void InteractCheck()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Vector3 origin = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(origin, cam.transform.forward, out RaycastHit hitInfo, 3f)) 
        {
            //Debug.Log(hitInfo.transform.gameObject.name+"   "+Time.time);
            if (hitInfo.transform.CompareTag("Interactable"))
            {
                hitInfo.transform.SendMessage("GetInteracted");
            }
        }
    }
}
