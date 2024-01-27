using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CustomerJSONParser : MonoBehaviour
{
    public TextAsset jsonText;

    [System.Serializable]
    public class Customer
    {
        public int HEIGHT, SKIN, CLOTHES, AGE, PERSONALITY;
        public string LINE, GOOD, MID, BAD;
    }
    [System.Serializable]
    public class Customers
    {
        public Customer[] customers;
    }
    public Customers customersClassObj = new Customers();
    public Customer[] customers;
    void Start()
    {
        
        customersClassObj = JsonUtility.FromJson<Customers>(jsonText.text);
        customers = customersClassObj.customers;
        Debug.Log(customers);
        foreach (Customer customer in customers)
        {
            Debug.Log(customer.LINE);
            Debug.Log(customer.HEIGHT);
        }
    }

    void Update()
    {
        
    }
}
