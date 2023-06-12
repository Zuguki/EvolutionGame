using System;
using Parameters;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject populationCountSettings;
    [SerializeField] private GameObject weatherSettingsObject;
    [SerializeField] private GameObject timeLineObject;
    [SerializeField] private GameObject populationMenu;
    [SerializeField] private GameObject escMenu;
    [SerializeField] private GameObject ideaMenu;
    [SerializeField] private GameObject rules;
    [SerializeField] private TMP_InputField populationCount;

    public static bool ChangeMenuStatus = false;

    public void Update()
    {
        if (!ChangeMenuStatus)
            return;
        
        ChangePopulationMenuActiveStatus();
        ChangeMenuStatus = false;
    }

    public void ChangeWeatherSettingsActiveStatus() =>
        weatherSettingsObject.SetActive(!weatherSettingsObject.activeSelf);
    
    public void ChangeTimeLineSettingsActiveStatus() => timeLineObject.SetActive(!timeLineObject.activeSelf);

    public void ChangePopulationCountSettings()
    {
        populationCountSettings.SetActive(!populationCountSettings.activeSelf);
        Program.Population.IsNew = false;

        PopulationCount.Value =
            populationCount.text.ToLongDef(PopulationCount.DefaultValue) ?? PopulationCount.DefaultValue;
        Program.Population.Parameters.Count = PopulationCount.Value;
        
        UpdateCurrentPopulation.CurrentPopulation = Program.Population;
        UpdateCurrentPopulation.NeedsUpdatePopulation = true;
        Program.NeedsUpdateUI = true;
    }

    public void ChangePopulationMenuActiveStatus()
    {
        if (populationMenu.activeSelf)
        {
            DrawPopulationMenu.DestroyObjects();
            if (Program.Population is not null && Program.Population.IsNew)
                populationCountSettings.SetActive(true);
        }
        else
            DrawPopulationMenu.DrawObjects();
        
        // UpdateCurrentPopulation.NeedsUpdatePopulation = true;
        populationMenu.SetActive(!populationMenu.activeSelf);  
    }

    public void ChangeEscMenuActiveStatus()
    {
        escMenu.SetActive(!escMenu.activeSelf);
        Time.timeScale = PauseMenu.IsGamePaused ? 1f : 0f;
        PauseMenu.IsGamePaused = !PauseMenu.IsGamePaused;
    }

    public void ChangeIdeaMenuActiveStatus() => ideaMenu.SetActive(!ideaMenu.activeSelf);

    public void ChangeRulesMenuActiveStatus() => rules.SetActive(!rules.activeSelf);

    public void CloseGame() => Application.Quit();

    public void StartIteration() => Program.Run();

    public void StartGame() => SceneManager.LoadScene("SampleScene");
}