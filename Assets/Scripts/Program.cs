using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Population;
using Population.Implementation.ColdHumanPopulation;
using Population.Implementation.FireHumanPopulation;
using Population.Implementation.HumanPopulation;
using Population.Implementation.RadiationHumanPopulation;
using TMPro;
using UnityEngine;

public class Program : MonoBehaviour
{
    public static readonly List<IPopulation> OpenPopulations = new()
        {new Human()};

    public static readonly List<IUnionPopulation> TryOpenPopulations =
        new() { new ColdHuman(), new FireHuman(), new RadiationHuman() };
    public static IPopulation Population;
    public static bool NeedsUpdateUI;
    
    [SerializeField] private GameObject populationPanel;
    [SerializeField] private GameObject advancePopulationPanel;

    public static bool InProcess { get; private set; }

    private TextMeshProUGUI _bodyTemperature;
    private TextMeshProUGUI _arterialPressure;
    private TextMeshProUGUI _waterInBody;
    private TextMeshProUGUI _bloodInBody;
    private TextMeshProUGUI _radiationInBody;
    private TextMeshProUGUI _populationCount;
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
        
        if (!InProcess || _isCoroutineRunning)
            return;

        if (Population is null)
        {
            InfoChecker.ChangeSimpleItem("Сначала стоит выбрать популяцию");
            InProcess = false;
            return;
        }
        
        CheckGameOver();
        if (!InProcess)
            return;
        
        StartCoroutine(ChangeDay());
        Population.Parameters.UpdateParams();
        UpdateUIParams();
        TryOpenNewPopulation();
        UpdateCurrentPopulation.NeedsUpdatePopulation = true;
    }

    private void TryOpenNewPopulation()
    {
        foreach (var tryOpenPopulation in TryOpenPopulations.Where(population =>
                     !OpenPopulations.Contains(population))) 
        {
            if (tryOpenPopulation.TryOpen(Population, out var population))
            {
                OpenPopulations.Add(population);
                InProcess = false;
                InfoChecker.ChangeSimpleItem($"Вы открыли новую популяцию: {population.Name}");
                TimeController.CurrentDay = 0;
            }
        }
    }

    private void CheckGameOver()
    {
        if (!Population.IsAlive)
        {
            InProcess = false;
            InfoChecker.ChangeMediumItem("Популяция погибла", $"Количество пройденных дней: {Population.Parameters.DaysAlive}\n" + string.Join('\n', Population.Parameters.DeadMessages));
            // InfoChecker.ChangeSimpleItem("Популяция погибла из за: " + string.Join(',', Population.Parameters.DeadMessages));

            var oldPopulation = OpenPopulations.Find(population => population == Population);
            OpenPopulations.Remove(oldPopulation);
            
            if (Population is not ITryOpenPopulation)
                OpenPopulations.Insert(0, new Human());
            
            Population = null;
            UpdateCurrentPopulation.CurrentPopulation = null;
            UpdateCurrentPopulation.NeedsUpdatePopulation = true;
            TimeController.CurrentDay = 0;
        }
        else if (TimeController.DaysLeft <= 0)
        {
            InProcess = false;
            InfoChecker.ChangeSimpleItem("Срок итераций подошел к концу");
            TimeController.CurrentDay = 0;
        }
    }

    private void UpdateUIParams()
    {
        _bodyTemperature.text =
            Math.Round(Population.Parameters.BodyTemperature, 1).ToString(CultureInfo.InvariantCulture);
        _arterialPressure.text = Population.Parameters.ArterialPressure.ToCustomString();
        _waterInBody.text = Math.Round(Population.Parameters.WaterInBody * 100, 1).ToString(CultureInfo.InvariantCulture);
        _bloodInBody.text = Math.Round(Population.Parameters.BloodInBody, 1).ToString(CultureInfo.InvariantCulture);
        _radiationInBody.text = Math.Round(Population.Parameters.Radiation, 1).ToString(CultureInfo.InvariantCulture);
        _populationCount.text = Population.Parameters.Count.ToString();
        _populationDays.text = Population.Parameters.DaysAlive.ToString(CultureInfo.InvariantCulture);
    }

    private IEnumerator ChangeDay()
    {
        _isCoroutineRunning = true;
        TimeController.CurrentDay += 1;
        Population.Parameters.DaysAlive += 1;
        yield return new WaitForSeconds(.05f);
        _isCoroutineRunning = false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void GetPopulationStats()
    {
        _arterialPressure = populationPanel.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        _waterInBody = populationPanel.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        _radiationInBody = populationPanel.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        
        _bodyTemperature = populationPanel.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        _bloodInBody = populationPanel.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();

        _populationCount = advancePopulationPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        _populationDays = advancePopulationPanel.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public static void Run()
    {
        InProcess = true;
    }
}
