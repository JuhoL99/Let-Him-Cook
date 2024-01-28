using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "New CustomerData")]
public class CustomerData : ScriptableObject
{
    public GameObject[] customerModels;
}
