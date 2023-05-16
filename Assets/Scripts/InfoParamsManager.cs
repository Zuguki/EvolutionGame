using TMPro;
using UnityEngine;
using Weather;

public class InfoParamsManager : MonoBehaviour
{
    [SerializeField] private GameObject ui;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI details1;
    [SerializeField] private TextMeshProUGUI details2;
    [SerializeField] private TextMeshProUGUI details3;

    public void ChangeUiActiveStatus() => ui.SetActive(!ui.activeSelf);

    public void ShowTemperatureDescription()
    {
        ChangeUiActiveStatus();

        title.text = Temperature.Title;
        details1.text = Temperature.Details1;
        details2.text = Temperature.Details2;
        details3.text = Temperature.Details3;
    }

    public void ShowHumidityDescription()
    {
        ChangeUiActiveStatus();

        title.text = Humidity.Title;
        details1.text = Humidity.Details1;
        details2.text = Humidity.Details2;
        details3.text = Humidity.Details3;
    }

    public void ShowWindSpeedDescription()
    {
        ChangeUiActiveStatus();

        title.text = WindSpeed.Title;
        details1.text = WindSpeed.Details1;
        details2.text = WindSpeed.Details2;
        details3.text = WindSpeed.Details3;
    }

    public void ShowPressureDescription()
    {
        ChangeUiActiveStatus();

        title.text = Pressure.Title;
        details1.text = Pressure.Details1;
        details2.text = Pressure.Details2;
        details3.text = Pressure.Details3;
    }

    public void ShowRadiationDescription()
    {
        ChangeUiActiveStatus();

        title.text = Radiation.Title;
        details1.text = Radiation.Details1;
        details2.text = Radiation.Details2;
        details3.text = Radiation.Details3;
    }

    public void ShowPreciptiationDescription()
    {
        ChangeUiActiveStatus();

        title.text = Preciptiation.Title;
        details1.text = Preciptiation.Details1;
        details2.text = Preciptiation.Details2;
        details3.text = Preciptiation.Details3;
    }

    public void ShowAirQualityDescription()
    {
        ChangeUiActiveStatus();

        title.text = AirQuality.Title;
        details1.text = AirQuality.Details1;
        details2.text = AirQuality.Details2;
        details3.text = AirQuality.Details3;
    }

    public void ShowNoiseDescription()
    {
        ChangeUiActiveStatus();

        title.text = Noise.Title;
        details1.text = Noise.Details1;
        details2.text = Noise.Details2;
        details3.text = Noise.Details3;
    }

    public void ShowSoilPurityDescription()
    {
        ChangeUiActiveStatus();

        title.text = SoilPurity.Title;
        details1.text = SoilPurity.Details1;
        details2.text = SoilPurity.Details2;
        details3.text = SoilPurity.Details3;
    }
}