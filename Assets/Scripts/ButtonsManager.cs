using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject weatherSettingsObject;
    [SerializeField] private GameObject timeLineObject;
    [SerializeField] private GameObject populationMenu;

    public void ChangeWeatherSettingsActiveStatus() =>
        weatherSettingsObject.SetActive(!weatherSettingsObject.activeSelf);
    
    public void ChangeTimeLineSettingsActiveStatus() => timeLineObject.SetActive(!timeLineObject.activeSelf);

    public void ChangePopulationMenuActiveStatus()
    {
        if (populationMenu.activeSelf)
            DrawPopulationMenu.NeedsDestroy = true;
        else
            DrawPopulationMenu.NeedsDraw = true;
        populationMenu.SetActive(!populationMenu.activeSelf);  
    } 

    public void StartIteration() => Program.Run();
}