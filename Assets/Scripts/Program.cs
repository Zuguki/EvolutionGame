using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Population;
using Population.Implementation;
using TMPro;
using UnityEngine;

public class Program : MonoBehaviour
{
    [SerializeField] private GameObject populationObject;
    
    private static bool _inProcess;
    private bool _needGetPopulation = true;

    private TextMeshProUGUI _bodyTemperature;
    private TextMeshProUGUI _arterialPressure;
    private TextMeshProUGUI _waterInBody;
    private TextMeshProUGUI _radiationInBody;

    private readonly IPopulation _population = new Human();

    private bool _isCoroutineRunning = false;

    private void Update()
    {
        if (!_inProcess || _isCoroutineRunning)
            return;
        
        if (_needGetPopulation)
            GetPopulationStats();
        
        StartCoroutine(ChangeDay());
        _population.UpdateParams();
        UpdateUIParams();
        CheckGameOver();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void CheckGameOver()
    {
        if (!_population.IsAlive)
        {
            _inProcess = false;
            Debug.Log("Популяция погибла");
        }
        else if (TimeController.DaysLeft <= 0)
        {
            _inProcess = false;
            Debug.Log("Срок итераций подошел к концу");
        }
    }

    private void UpdateUIParams()
    {
        _bodyTemperature.text = _population.BodyTemperature.ToString(CultureInfo.InvariantCulture);
        _arterialPressure.text = _population.ArterialPressure.ToCustomString();
        _waterInBody.text = _population.WaterInBody.ToString(CultureInfo.InvariantCulture);
        _radiationInBody.text = _population.Radiation.ToString(CultureInfo.InvariantCulture);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator ChangeDay()
    {
        _isCoroutineRunning = true;
        TimeController.Day += 1;
        _population.DaysAlive += 1;
        Debug.Log($"Days Alive: {_population.DaysAlive}");
        yield return new WaitForSeconds(1);
        _isCoroutineRunning = false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void GetPopulationStats()
    {
        _bodyTemperature = populationObject.transform.GetChild(0).GetChild(0).GetChild(1)
            .GetComponent<TextMeshProUGUI>();
        _arterialPressure = populationObject.transform.GetChild(0).GetChild(1).GetChild(1)
            .GetComponent<TextMeshProUGUI>();
        _waterInBody = populationObject.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        _radiationInBody = populationObject.transform.GetChild(0).GetChild(3).GetChild(1)
            .GetComponent<TextMeshProUGUI>();

        UpdateUIParams();
        _needGetPopulation = false;
    }

    public static void Run()
    {
        _inProcess = true;
    }
}
