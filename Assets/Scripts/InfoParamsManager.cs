using Parameters;
using TMPro;
using UnityEngine;
using Weather;

public class InfoParamsManager : MonoBehaviour
{
    [SerializeField] private GameObject factorUi;
    [SerializeField] private TextMeshProUGUI factorTitle;
    [SerializeField] private TextMeshProUGUI factorDetails1;
    [SerializeField] private TextMeshProUGUI factorDetails2;
    [SerializeField] private TextMeshProUGUI factorDetails3;
    
    [SerializeField] private GameObject parameterUi;
    [SerializeField] private TextMeshProUGUI parameterTitle;
    [SerializeField] private TextMeshProUGUI parameterDetails1;
    [SerializeField] private TextMeshProUGUI parameterDetails2;
    [SerializeField] private TextMeshProUGUI parameterDetails3;
    
    [SerializeField] private GameObject populationUi;
    [SerializeField] private TextMeshProUGUI populationTitle;
    [SerializeField] private TextMeshProUGUI populationDetails1;
    [SerializeField] private TextMeshProUGUI populationDetails2;
    [SerializeField] private TextMeshProUGUI populationDetails3;

    public void ChangeFactorUiStatus() => ChangeUiActiveStatus(factorUi);
    public void ChangeParameterUiStatus() => ChangeUiActiveStatus(parameterUi);
    public void ChangePopulationUiStatus() => ChangeUiActiveStatus(populationUi);

    public void ShowPopulationDescription()
    {
        ChangeUiActiveStatus(populationUi);
        
        var population = Program.Population;
        if (population is null)
        {
            populationTitle.text = "Популяция не выбрана";
            populationDetails1.text = "Пустоса";
            populationDetails2.text = "Не виден";
            populationDetails3.text = "Везде";
            return;
        }

        populationTitle.text = population.Title;
        populationDetails1.text = population.Details1;
        populationDetails2.text = population.Details2;
        populationDetails3.text = population.Details3;
    }

    public void ShowArterialPressureDescription()
    {
        ChangeUiActiveStatus(parameterUi);

        parameterTitle.text = ArterialPressure.Title;
        parameterDetails1.text = ArterialPressure.Details1;
        parameterDetails2.text = ArterialPressure.Details2;
        parameterDetails3.text = ArterialPressure.Details3;
    }
    
    public void ShowBloodInBodyDescription()
    {
        ChangeUiActiveStatus(parameterUi);

        parameterTitle.text = BloodInBody.Title;
        parameterDetails1.text = BloodInBody.Details1;
        parameterDetails2.text = BloodInBody.Details2;
        parameterDetails3.text = BloodInBody.Details3;
    }
    
    public void ShowBodyTemperatureDescription()
    {
        ChangeUiActiveStatus(parameterUi);

        parameterTitle.text = BodyTemperature.Title;
        parameterDetails1.text = BodyTemperature.Details1;
        parameterDetails2.text = BodyTemperature.Details2;
        parameterDetails3.text = BodyTemperature.Details3;
    }
    
    public void ShowRadiationInBodyDescription()
    {
        ChangeUiActiveStatus(parameterUi);

        parameterTitle.text = RadiationInBody.Title;
        parameterDetails1.text = RadiationInBody.Details1;
        parameterDetails2.text = RadiationInBody.Details2;
        parameterDetails3.text = RadiationInBody.Details3;
    }
    
    public void ShowWaterInBodyDescription()
    {
        ChangeUiActiveStatus(parameterUi);

        parameterTitle.text = WaterInBody.Title;
        parameterDetails1.text = WaterInBody.Details1;
        parameterDetails2.text = WaterInBody.Details2;
        parameterDetails3.text = WaterInBody.Details3;
    }

    public void ShowTemperatureDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = Temperature.Title;
        factorDetails1.text = Temperature.Details1;
        factorDetails2.text = Temperature.Details2;
        factorDetails3.text = Temperature.Details3;
    }

    public void ShowHumidityDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = Humidity.Title;
        factorDetails1.text = Humidity.Details1;
        factorDetails2.text = Humidity.Details2;
        factorDetails3.text = Humidity.Details3;
    }

    public void ShowWindSpeedDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = WindSpeed.Title;
        factorDetails1.text = WindSpeed.Details1;
        factorDetails2.text = WindSpeed.Details2;
        factorDetails3.text = WindSpeed.Details3;
    }

    public void ShowPressureDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = Pressure.Title;
        factorDetails1.text = Pressure.Details1;
        factorDetails2.text = Pressure.Details2;
        factorDetails3.text = Pressure.Details3;
    }

    public void ShowRadiationDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = Radiation.Title;
        factorDetails1.text = Radiation.Details1;
        factorDetails2.text = Radiation.Details2;
        factorDetails3.text = Radiation.Details3;
    }

    public void ShowPreciptiationDescription()
    {
        ChangeUiActiveStatus(factorUi);


        factorTitle.text = Preciptiation.Title;
        factorDetails1.text = Preciptiation.Details1;
        factorDetails2.text = Preciptiation.Details2;
        factorDetails3.text = Preciptiation.Details3;
    }

    public void ShowAirQualityDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = AirQuality.Title;
        factorDetails1.text = AirQuality.Details1;
        factorDetails2.text = AirQuality.Details2;
        factorDetails3.text = AirQuality.Details3;
    }

    public void ShowNoiseDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = Noise.Title;
        factorDetails1.text = Noise.Details1;
        factorDetails2.text = Noise.Details2;
        factorDetails3.text = Noise.Details3;
    }

    public void ShowSoilPurityDescription()
    {
        ChangeUiActiveStatus(factorUi);

        factorTitle.text = SoilPurity.Title;
        factorDetails1.text = SoilPurity.Details1;
        factorDetails2.text = SoilPurity.Details2;
        factorDetails3.text = SoilPurity.Details3;
    }
    
    private static void ChangeUiActiveStatus(GameObject ui) => ui.SetActive(!ui.activeSelf);
}