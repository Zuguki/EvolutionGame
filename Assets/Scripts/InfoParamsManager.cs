using TMPro;
using UnityEngine;
using Weather;

public class InfoParamsManager : MonoBehaviour
{
    [SerializeField] private GameObject factorUI;

    [SerializeField] private TextMeshProUGUI factorTitle;
    [SerializeField] private TextMeshProUGUI factorDetails1;
    [SerializeField] private TextMeshProUGUI factorDetails2;
    [SerializeField] private TextMeshProUGUI factorDetails3;
    
    [SerializeField] private GameObject parameterUi;

    [SerializeField] private TextMeshProUGUI parameterTitle;
    [SerializeField] private TextMeshProUGUI parameterDetails1;
    [SerializeField] private TextMeshProUGUI parameterDetails2;
    [SerializeField] private TextMeshProUGUI parameterDetails3;

    public void ChangeUiActiveStatus() => factorUI.SetActive(!factorUI.activeSelf);

    public void ShowTemperatureDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = Temperature.Title;
        factorDetails1.text = Temperature.Details1;
        factorDetails2.text = Temperature.Details2;
        factorDetails3.text = Temperature.Details3;
    }

    public void ShowHumidityDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = Humidity.Title;
        factorDetails1.text = Humidity.Details1;
        factorDetails2.text = Humidity.Details2;
        factorDetails3.text = Humidity.Details3;
    }

    public void ShowWindSpeedDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = WindSpeed.Title;
        factorDetails1.text = WindSpeed.Details1;
        factorDetails2.text = WindSpeed.Details2;
        factorDetails3.text = WindSpeed.Details3;
    }

    public void ShowPressureDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = Pressure.Title;
        factorDetails1.text = Pressure.Details1;
        factorDetails2.text = Pressure.Details2;
        factorDetails3.text = Pressure.Details3;
    }

    public void ShowRadiationDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = Radiation.Title;
        factorDetails1.text = Radiation.Details1;
        factorDetails2.text = Radiation.Details2;
        factorDetails3.text = Radiation.Details3;
    }

    public void ShowPreciptiationDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = Preciptiation.Title;
        factorDetails1.text = Preciptiation.Details1;
        factorDetails2.text = Preciptiation.Details2;
        factorDetails3.text = Preciptiation.Details3;
    }

    public void ShowAirQualityDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = AirQuality.Title;
        factorDetails1.text = AirQuality.Details1;
        factorDetails2.text = AirQuality.Details2;
        factorDetails3.text = AirQuality.Details3;
    }

    public void ShowNoiseDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = Noise.Title;
        factorDetails1.text = Noise.Details1;
        factorDetails2.text = Noise.Details2;
        factorDetails3.text = Noise.Details3;
    }

    public void ShowSoilPurityDescription()
    {
        ChangeUiActiveStatus();

        factorTitle.text = SoilPurity.Title;
        factorDetails1.text = SoilPurity.Details1;
        factorDetails2.text = SoilPurity.Details2;
        factorDetails3.text = SoilPurity.Details3;
    }
}