using System.Globalization;
using TMPro;
using UnityEngine;
using Weather;

public class WeatherSettingsController : MonoBehaviour
{
    [SerializeField] private TMP_InputField temperatureValue;
    [SerializeField] private TMP_InputField humidityValue;
    [SerializeField] private TMP_InputField windSpeedValue;
    
    [SerializeField] private TMP_InputField pressureValue;
    [SerializeField] private TMP_InputField radiationValue;
    [SerializeField] private TMP_InputField preciptiationValue;
    
    [SerializeField] private TMP_InputField airQualityValue;
    [SerializeField] private TMP_InputField noiseValue;
    [SerializeField] private TMP_InputField soilPurityValue;
    
    public void Start()
    {
        ResetValues();
        UpdateTextValues();
        temperatureValue.onEndEdit.AddListener(value => Temperature.Value = value.ToFloatDef(0) ?? 0);
        temperatureValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        humidityValue.onEndEdit.AddListener(value => Humidity.Value = value.ToFloatDef(0) ?? 0);
        humidityValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        windSpeedValue.onEndEdit.AddListener(value => WindSpeed.Value = value.ToFloatDef(0) ?? 0);
        windSpeedValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        pressureValue.onEndEdit.AddListener(value => Pressure.Value = value.ToFloatDef(0) ?? 0);
        pressureValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        radiationValue.onEndEdit.AddListener(value => Radiation.Value = value.ToFloatDef(0) ?? 0);
        radiationValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        preciptiationValue.onEndEdit.AddListener(value => Preciptiation.Value = value.ToFloatDef(0) ?? 0);
        preciptiationValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        airQualityValue.onEndEdit.AddListener(value => AirQuality.Value = value.ToFloatDef(0) ?? 0);
        airQualityValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        noiseValue.onEndEdit.AddListener(value => Noise.Value = value.ToFloatDef(0) ?? 0);
        noiseValue.onEndEdit.AddListener(_ => UpdateTextValues());
        
        soilPurityValue.onEndEdit.AddListener(value => SoilPurity.Value = value.ToFloatDef(0) ?? 0);
        soilPurityValue.onEndEdit.AddListener(_ => UpdateTextValues());
    }

    private void UpdateTextValues()
    {
        temperatureValue.text = Temperature.Value.ToString(CultureInfo.InvariantCulture);
        humidityValue.text = Humidity.Value.ToString(CultureInfo.InvariantCulture);
        windSpeedValue.text = WindSpeed.Value.ToString(CultureInfo.InvariantCulture);
        pressureValue.text = Pressure.Value.ToString(CultureInfo.InvariantCulture);
        radiationValue.text = Radiation.Value.ToString(CultureInfo.InvariantCulture);
        preciptiationValue.text = Preciptiation.Value.ToString(CultureInfo.InvariantCulture);
        airQualityValue.text = AirQuality.Value.ToString(CultureInfo.InvariantCulture);
        noiseValue.text = Noise.Value.ToString(CultureInfo.InvariantCulture);
        soilPurityValue.text = SoilPurity.Value.ToString(CultureInfo.InvariantCulture);
    }

    private void ResetValues()
    {
        Temperature.Value = Temperature.DefaultValue;
        Pressure.Value = Pressure.DefaultValue;
        Radiation.Value = Radiation.DefaultValue;
        Humidity.Value = Humidity.DefaultValue;
        WindSpeed.Value = WindSpeed.DefaultValue;
        Preciptiation.Value = Preciptiation.DefaultValue;
    }
}
