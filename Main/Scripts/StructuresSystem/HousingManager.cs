using Assets.Main.Scripts.StructuresSystem;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HousingManager : MonoBehaviour
{
    List<Residential> unoccupied_houses = new List<Residential>();
    Dictionary<Character, Residential> characterHouse = new Dictionary<Character, Residential>();

    int startDelay = 5;
    void Start()
    {
        ScanForHouses();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHouse() { }
    public void RegisterCharacter(Character character) {


    }
    public void ScanForHouses()
    {
        unoccupied_houses.Clear();
        GameObject[] houseObjects = GameObject.FindGameObjectsWithTag("RESIDENTIAL");
        foreach (GameObject houseObject in houseObjects)
        {
            Residential house = houseObject.GetComponent<Residential>();
            if (house != null)
            {
                unoccupied_houses.Add(house);
            }
        }
    }
}
