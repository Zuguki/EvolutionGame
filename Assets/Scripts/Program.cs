using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Population;
using Population.Implementation;
using TMPro;
using UnityEngine;
using Weather;

public class Program : MonoBehaviour
{
    public static readonly List<IPopulation> OpenPopulations = new() {new Human()};
    public static readonly List<IUnionPopulation> TryOpenPopulations = new() {new FireHuman(), new ColdHuman()};
    public static IPopulation Population;
    public static bool NeedsUpdateUI;
    
    [SerializeField] private GameObject populationPanel;
    
    private static bool _inProcess;

    private TextMeshProUGUI _bodyTemperature;
    private TextMeshProUGUI _arterialPressure;
    private TextMeshProUGUI _waterInBody;
    private TextMeshProUGUI _bloodInBody;
    private TextMeshProUGUI _radiationInBody;
    private TextMeshProUGUI _populationDays;

    private bool _isCoroutineRunning;

    private void Start()
    {
        GetPopulationStats();
    }

    private void Update()
    {
        if (NeedsUpdateUI)
        {
            UpdateUIParams();
            NeedsUpdateUI = false;
        }
        
        if (!_inProcess || _isCoroutineRunning)
            return;

        if (Population is null)
        {
            InfoChecker.ChangeItems("Oooops...", "Сначала стоит выбрать популяцию");
            _inProcess = false;
            return;
        }
        
        CheckGameOver();
        if (!_inProcess)
            return;
        
        StartCoroutine(ChangeDay());
        Population.UpdateParams();
        UpdateUIParams();
        TryOpenNewPopulation();
    }

    private void TryOpenNewPopulation()
    {
        foreach (var tryOpenPopulation in TryOpenPopulations.Where(population =>
                     !OpenPopulations.Contains(population))) 
        {
            if (tryOpenPopulation.TryOpen(Population, out var population))
            {
                OpenPopulations.Add(population);
                _inProcess = false;
                InfoChecker.ChangeItems("Okey", $"Вы открыли новую популяцию: {population.Name}");
            }
        }
    }

    private void CheckGameOver()
    {
        if (!Population.IsAlive)
        {
            _inProcess = false;
            InfoChecker.ChangeItems("Oooops...", "Популяция погибла");

            var oldPopulation = OpenPopulations.Find(population => population == Population);
            OpenPopulations.Remove(oldPopulation);
            
            if (Population is not ITryOpenPopulation)
                OpenPopulations.Add(new Human());
            
            Population = null;
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
        _bodyTemperature.text = Math.Round(Population.BodyTemperature, 1).ToString(CultureInfo.InvariantCulture);
        _arterialPressure.text = Population.ArterialPressure.ToCustomString();
        _waterInBody.text = Math.Round(Population.WaterInBody, 1).ToString(CultureInfo.InvariantCulture);
        _bloodInBody.text = Math.Round(Population.BloodInBody, 1).ToString(CultureInfo.InvariantCulture);
        _radiationInBody.text = Math.Round(Population.Radiation, 1).ToString(CultureInfo.InvariantCulture);
        _populationDays.text = Population.DaysAlive.ToString(CultureInfo.InvariantCulture);
    }

    private IEnumerator ChangeDay()
    {
        _isCoroutineRunning = true;
        TimeController.Day += 1;
        Population.DaysAlive += 1;
        Temperature.AddTemperature();
        Pressure.AddPressure();
        yield return new WaitForSeconds(.3f);
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
    }

    public static void Run()
    {
        _inProcess = true;
    }
}
