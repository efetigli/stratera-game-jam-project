using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    [Header("Pickaxe Materials")]
    [SerializeField] private Material stone;
    [SerializeField] private Material metal;
    [SerializeField] private Material gold;

    [Header("Pickaxe Head")]
    [SerializeField] private GameObject pickaxeHead;
    [SerializeField] private GameObject pickaxeTop;
    private string typeOfPickaxe;

    [Header("Save Materials")]
    [SerializeField] private saveMaterials mySaveMaterials;

    private void Awake()
    {
        AssignPickaxeHead();
    }

    public void AssignPickaxeHead()
    {
        typeOfPickaxe = mySaveMaterials.pickaxeType;
        if (typeOfPickaxe == "Stone")
        {
            pickaxeHead.GetComponent<MeshRenderer>().material = stone;
            pickaxeTop.GetComponent<MeshRenderer>().material = stone;
            pickaxeTop.GetComponent<MeshRenderer>().material = stone;
        }
        else if (typeOfPickaxe == "Metal")
        {
            pickaxeHead.GetComponent<MeshRenderer>().material = metal;
            pickaxeTop.GetComponent<MeshRenderer>().material = metal;

        }
        else if (typeOfPickaxe == "Gold")
        {
            pickaxeHead.GetComponent<MeshRenderer>().material = gold;
            pickaxeTop.GetComponent<MeshRenderer>().material = gold;

        }
    }

    public string GetTypeOfPickaxe()
    {
        return typeOfPickaxe;
    }
}
