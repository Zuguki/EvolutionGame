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
    [SerializeField] private GameObject populationPanel;
    
    private static bool _inProcess;
    private bool _needGetPopulation = true;

    private TextMeshProUGUI _bodyTemperature;
    private TextMeshProUGUI _arterialPressure;
    private TextMeshProUGUI _waterInBody;
    private TextMeshProUGUI _bloodInBody;
    private TextMeshProUGUI _radiationInBody;
    private TextMeshProUGUI _populationDays;

    private readonly IPopulation _population = new Human();

    private bool _isCoroutineRunning;

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
        _bloodInBody.text = _population.BloodInBody.ToString(CultureInfo.InvariantCulture);
        _radiationInBody.text = _population.Radiation.ToString(CultureInfo.InvariantCulture);
        _populationDays.text = _population.DaysAlive.ToString(CultureInfo.InvariantCulture);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator ChangeDay()
    {
        _isCoroutineRunning = true;
        TimeController.Day += 1;
        _population.DaysAlive += 1;
        yield return new WaitForSeconds(1);
        _isCoroutineRunning = false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void GetPopulationStats()
    {
        _bodyTemperature = populationPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        _arterialPressure = populationPanel.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        _waterInBody = populationPanel.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        _bloodInBody = populationPanel.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        _radiationInBody = populationPanel.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
        _populationDays = populationPanel.transform.GetChild(5).GetChild(1).GetComponent<TextMeshProUGUI>();

        UpdateUIParams();
        _needGetPopulation = false;
    }

    public static void Run()
    {
        _inProcess = true;
    }
}
