using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*

public class Energy : MonoBehaviour
{
    [SerializeField] Text energyText;
    [SerializeField] int EnergyApply = 20;
    [SerializeField] int EnergyPlus = 40;

    public int energyTotal = 200;



    void Start()
    {
        energyText.text = energyTotal.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void PlusEnergy(int energyToAdd, GameObject batteryObj)
    {
        batteryObj.GetComponent<BoxCollider>().enabled = false;
        energyTotal += energyToAdd;
        //energyText.text = EnergyTotal + energyToAdd.ToString();
        Destroy(batteryObj);
    }

    public void Fly()
    {
        energyTotal -= Mathf.RoundToInt(EnergyApply * Time.deltaTime);
        energyText.text = energyTotal.ToString();
    }

    public void AddEnergy()
    {
        energyTotal += EnergyApply;
    }
}
*/