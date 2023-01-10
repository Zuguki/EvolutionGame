using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
    private readonly List<IPopulation> _openPopulations = new() {new Human()};
    private readonly List<IUnionPopulation> _tryOpenPopulations = new() {new FireHuman()};

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
        TryOpenNewPopulation();
        CheckGameOver();
    }

    private void TryOpenNewPopulation()
    {
        foreach (var tryOpenPopulation in _tryOpenPopulations.Where(population =>
                     !_openPopulations.Contains(population))) 
        {
            if (tryOpenPopulation.TryOpen(_population, out var population))
            {
                _openPopulations.Add(population);
                InfoChecker.ChangeItems("Okey", $"Вы открыли новую популяцию: {population.Name}");
            }
        }
    }

    private void CheckGameOver()
    {
        if (!_population.IsAlive)
        {
            _inProcess = false;
            InfoChecker.ChangeItems("Oooops...", "Популяция погибла");
        }
        else if (TimeController.DaysLeft <= 0)
        {
            _inProcess = false;
            InfoChecker.ChangeItems("Oooops...", "Срок итераций подошел к концу");
            TimeController.Day = 0;
        }
    }

    private void UpdateUIParams()
    {
        _bodyTemperature.text = Math.Round(_population.BodyTemperature, 1).ToString(CultureInfo.InvariantCulture);
        _arterialPressure.text = _population.ArterialPressure.ToCustomString();
        _waterInBody.text = Math.Round(_population.WaterInBody, 1).ToString(CultureInfo.InvariantCulture);
        _bloodInBody.text = Math.Round(_population.BloodInBody, 1).ToString(CultureInfo.InvariantCulture);
        _radiationInBody.text = Math.Round(_population.Radiation, 1).ToString(CultureInfo.InvariantCulture);
        _populationDays.text = _population.DaysAlive.ToString(CultureInfo.InvariantCulture);
    }

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
