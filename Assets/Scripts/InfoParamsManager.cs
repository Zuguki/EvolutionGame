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
        factorUi.SetActive(false);
        parameterUi.SetActive(false);
        populationUi.SetActive(true);
        
        var population = Program.Population;
        if (population is null)
        {
            populationTitle.text = "Популяция не выбрана";
            populationDetails1.text = "Пустоса";
            populationDetails2.text = "Не виден";
            populationDetails3.text = "Везде";
            return;
        }

        var populationDescription = population.Description;
        populationTitle.text = populationDescription.Title;
        populationDetails1.text = populationDescription.Details1;
        populationDetails2.text = populationDescription.Details2;
        populationDetails3.text = populationDescription.Details3;
    }

    public void ShowArterialPressureDescription()
    {
        factorUi.SetActive(false);
        populationUi.SetActive(false);
        parameterUi.SetActive(true);

        parameterTitle.text = ArterialPressure.Title;
        parameterDetails1.text = ArterialPressure.Details1;
        parameterDetails2.text = ArterialPressure.Details2;
        parameterDetails3.text = ArterialPressure.Details3;
    }
    
    public void ShowBloodInBodyDescription()
    {
        factorUi.SetActive(false);
        parameterUi.SetActive(true);
        populationUi.SetActive(false);

        parameterTitle.text = BloodInBody.Title;
        parameterDetails1.text = BloodInBody.Details1;
        parameterDetails2.text = BloodInBody.Details2;
        parameterDetails3.text = BloodInBody.Details3;
    }
    
    public void ShowBodyTemperatureDescription()
    {
        factorUi.SetActive(false);
        parameterUi.SetActive(true);
        populationUi.SetActive(false);

        parameterTitle.text = BodyTemperature.Title;
        parameterDetails1.text = BodyTemperature.Details1;
        parameterDetails2.text = BodyTemperature.Details2;
        parameterDetails3.text = BodyTemperature.Details3;
    }
    
    public void ShowRadiationInBodyDescription()
    {
        factorUi.SetActive(false);
        populationUi.SetActive(false);
        parameterUi.SetActive(true);

        parameterTitle.text = RadiationInBody.Title;
        parameterDetails1.text = RadiationInBody.Details1;
        parameterDetails2.text = RadiationInBody.Details2;
        parameterDetails3.text = RadiationInBody.Details3;
    }
    
    public void ShowWaterInBodyDescription()
    {
        factorUi.SetActive(false);
        populationUi.SetActive(false);
        parameterUi.SetActive(true);

        parameterTitle.text = WaterInBody.Title;
        parameterDetails1.text = WaterInBody.Details1;
        parameterDetails2.text = WaterInBody.Details2;
        parameterDetails3.text = WaterInBody.Details3;
    }

    public void ShowTemperatureDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = Temperature.Title;
        factorDetails1.text = Temperature.Details1;
        factorDetails2.text = Temperature.Details2;
        factorDetails3.text = Temperature.Details3;
    }

    public void ShowHumidityDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = Humidity.Title;
        factorDetails1.text = Humidity.Details1;
        factorDetails2.text = Humidity.Details2;
        factorDetails3.text = Humidity.Details3;
    }

    public void ShowWindSpeedDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = WindSpeed.Title;
        factorDetails1.text = WindSpeed.Details1;
        factorDetails2.text = WindSpeed.Details2;
        factorDetails3.text = WindSpeed.Details3;
    }

    public void ShowPressureDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = Pressure.Title;
        factorDetails1.text = Pressure.Details1;
        factorDetails2.text = Pressure.Details2;
        factorDetails3.text = Pressure.Details3;
    }

    public void ShowRadiationDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = Radiation.Title;
        factorDetails1.text = Radiation.Details1;
        factorDetails2.text = Radiation.Details2;
        factorDetails3.text = Radiation.Details3;
    }

    public void ShowPreciptiationDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);


        factorTitle.text = Preciptiation.Title;
        factorDetails1.text = Preciptiation.Details1;
        factorDetails2.text = Preciptiation.Details2;
        factorDetails3.text = Preciptiation.Details3;
    }

    public void ShowAirQualityDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = AirQuality.Title;
        factorDetails1.text = AirQuality.Details1;
        factorDetails2.text = AirQuality.Details2;
        factorDetails3.text = AirQuality.Details3;
    }

    public void ShowNoiseDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = Noise.Title;
        factorDetails1.text = Noise.Details1;
        factorDetails2.text = Noise.Details2;
        factorDetails3.text = Noise.Details3;
    }

    public void ShowSoilPurityDescription()
    {
        parameterUi.SetActive(false);
        populationUi.SetActive(false);
        factorUi.SetActive(true);

        factorTitle.text = SoilPurity.Title;
        factorDetails1.text = SoilPurity.Details1;
        factorDetails2.text = SoilPurity.Details2;
        factorDetails3.text = SoilPurity.Details3;
    }
    
    private static void ChangeUiActiveStatus(GameObject ui) => ui.SetActive(!ui.activeSelf);
}