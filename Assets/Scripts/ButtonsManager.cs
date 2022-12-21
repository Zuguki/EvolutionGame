using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject weatherSettingsObject;
    [SerializeField] private GameObject populationMenu;

    public void ChangeWeatherSettingsActiveStatus() =>
        weatherSettingsObject.SetActive(!weatherSettingsObject.activeSelf);

    public void ChangePopulationMenuActiveStatus() =>
        populationMenu.SetActive(!populationMenu.activeSelf);
}