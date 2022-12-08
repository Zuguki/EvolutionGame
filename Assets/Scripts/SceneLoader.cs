using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject weatherSettingsObject;

    public void ChangeWeatherSettingsActiveStatus() =>
        weatherSettingsObject.SetActive(!weatherSettingsObject.activeSelf);
}