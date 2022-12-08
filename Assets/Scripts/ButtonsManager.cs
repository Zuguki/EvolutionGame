using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject weatherSettingsObject;

    public void ChangeWeatherSettingsActiveStatus() =>
        weatherSettingsObject.SetActive(!weatherSettingsObject.activeSelf);
}