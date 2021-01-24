using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergyDisplayer : MonoBehaviour
{
    [SerializeField] private UFO player;
    [SerializeField] private Text energyText;

    private void OnEnable()
    {
        player.EnergyCollected += OnEnergyTotal;
    }


    private void OnDisable()
    {
        player.EnergyCollected -= OnEnergyTotal;

    }

    private void OnEnergyTotal(int totalEnergy)
    {
        energyText.text = "Energy: " + totalEnergy.ToString();
    }
}
