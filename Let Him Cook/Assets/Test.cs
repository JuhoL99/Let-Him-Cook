using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject body;
    public GameObject head;
    public Transform headT;
    public Transform bodyT;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(head, headT);
        Instantiate(body, bodyT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
