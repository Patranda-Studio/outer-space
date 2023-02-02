using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    // Переменные ресурсов
    public static int metal;
    public static int humans;
    public static int humansMax;
    public static int energy;

    // UI ресурсов
    public Text metalText;
    public Text humansText;
    public Text humansMaxText;
    public Text energyText;

    void Start()
    {
        metal = 100;
        humans = 10;
        humansMax = 10;
        energy = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Отображение переменных
        metalText.GetComponent<Text>().text = metal.ToString();
        humansText.GetComponent<Text>().text = humans.ToString();
        humansMaxText.GetComponent<Text>().text = humansMax.ToString();
        energyText.GetComponent<Text>().text = energy.ToString();
    }
}
