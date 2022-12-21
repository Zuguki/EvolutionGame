using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weather;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI temperaturePanelValue;
    [SerializeField] private TextMeshProUGUI pressurePanelValue;
    [SerializeField] private TextMeshProUGUI radiationPanelValue;
    [SerializeField] private TextMeshProUGUI humidityPanelValue;
    [SerializeField] private TextMeshProUGUI windSpeedPanelValue;
    [SerializeField] private TextMeshProUGUI preciptiationPanelValue;
    
    private TMP_InputField _temperatureValue;
    private Slider _temperatureSlider;
    private TMP_InputField _pressureValue;
    private Slider _pressureSlider;
    private TMP_InputField _radiationValue;
    private Slider _radiationSlider;
    private TMP_InputField _humidityValue;
    private Slider _humiditySlider;
    private TMP_InputField _windSpeedValue;
    private Slider _windSpeedSlider;
    private TMP_InputField _preciptiationValue;
    private Slider _preciptioationSlider;

    private Button _resetButton;

    private void Awake()
    {
        _temperatureValue = transform.GetChild(1).GetChild(2).GetComponent<TMP_InputField>();
        _temperatureSlider = transform.GetChild(1).GetChild(1).GetComponent<Slider>();
        _pressureValue = transform.GetChild(2).GetChild(2).GetComponent<TMP_InputField>();
        _pressureSlider = transform.GetChild(2).GetChild(1).GetComponent<Slider>();
        _radiationValue = transform.GetChild(3).GetChild(2).GetComponent<TMP_InputField>();
        _radiationSlider = transform.GetChild(3).GetChild(1).GetComponent<Slider>();
        _humidityValue = transform.GetChild(4).GetChild(2).GetComponent<TMP_InputField>();
        _humiditySlider = transform.GetChild(4).GetChild(1).GetComponent<Slider>();
        _windSpeedValue = transform.GetChild(5).GetChild(2).GetComponent<TMP_InputField>();
        _windSpeedSlider = transform.GetChild(5).GetChild(1).GetComponent<Slider>();
        _preciptiationValue = transform.GetChild(6).GetChild(2).GetComponent<TMP_InputField>();
        _preciptioationSlider = transform.GetChild(6).GetChild(1).GetComponent<Slider>();
        
        _resetButton = transform.GetChild(7).GetChild(0).GetComponent<Button>();
    }

    public void Start()
    {
        _temperatureValue.onValueChanged.AddListener(value => Temperature.Value = ParseFloat(value));
        _temperatureSlider.onValueChanged.AddListener(value => Temperature.Value = value);
        
        _pressureValue.onValueChanged.AddListener(value => Pressure.Value = ParseFloat(value));
        _pressureSlider.onValueChanged.AddListener(value => Pressure.Value = value);
        
        _radiationValue.onValueChanged.AddListener(value => Radiation.Value = ParseFloat(value));
        _radiationSlider.onValueChanged.AddListener(value => Radiation.Value = value);
        
        _humidityValue.onValueChanged.AddListener(value => Humidity.Value = ParseFloat(value));
        _humiditySlider.onValueChanged.AddListener(value => Humidity.Value = value);
        
        _windSpeedValue.onValueChanged.AddListener(value => WindSpeed.Value = ParseFloat(value));
        _windSpeedSlider.onValueChanged.AddListener(value => WindSpeed.Value = value);
        
        _preciptiationValue.onValueChanged.AddListener(value => Preciptiation.Value = ParseFloat(value));
        _preciptioationSlider.onValueChanged.AddListener(value => Preciptiation.Value = value);
        
        _resetButton.onClick.AddListener(ResetValues);
    }

    private void Update()
    {
        UpdateSliderValues();
        UpdateTextValues();
        UpdateTextPanels();
    }

    private void UpdateTextPanels()
    {
        temperaturePanelValue.text = Temperature.Value.ToString(CultureInfo.InvariantCulture);
        pressurePanelValue.text = Pressure.Value.ToString(CultureInfo.InvariantCulture);
        radiationPanelValue.text = Radiation.Value.ToString(CultureInfo.InvariantCulture);
        humidityPanelValue.text = Humidity.Value.ToString(CultureInfo.InvariantCulture);
        windSpeedPanelValue.text = WindSpeed.Value.ToString(CultureInfo.InvariantCulture);
        preciptiationPanelValue.text = Preciptiation.Value.ToString(CultureInfo.InvariantCulture);
    }

    private void UpdateTextValues()
    {
        _temperatureValue.text = Temperature.Value.ToString(CultureInfo.InvariantCulture);
        _pressureValue.text = Pressure.Value.ToString(CultureInfo.InvariantCulture);
        _radiationValue.text = Radiation.Value.ToString(CultureInfo.InvariantCulture);
        _humidityValue.text = Humidity.Value.ToString(CultureInfo.InvariantCulture);
        _windSpeedValue.text = WindSpeed.Value.ToString(CultureInfo.InvariantCulture);
        _preciptiationValue.text = Preciptiation.Value.ToString(CultureInfo.InvariantCulture);
    }

    private void UpdateSliderValues()
    {
        _temperatureSlider.value = Temperature.Value;
        _pressureSlider.value = Pressure.Value;
        _radiationSlider.value = Radiation.Value;
        _humiditySlider.value = Humidity.Value;
        _windSpeedSlider.value = WindSpeed.Value;
        _preciptioationSlider.value = Preciptiation.Value;
    }

    private float ParseFloat(string value)
    {
        var isFloat = float.TryParse(value, out var result);
        if (isFloat)
            return result;
        
        _temperatureValue.text = _temperatureSlider.value.ToString(CultureInfo.InvariantCulture);
        return _temperatureSlider.value;
    }

    private static void ResetValues()
    {
        Temperature.Value = Temperature.DefaultValue;
        Pressure.Value = Pressure.DefaultValue;
        Radiation.Value = Radiation.DefaultValue;
        Humidity.Value = Humidity.DefaultValue;
        WindSpeed.Value = WindSpeed.DefaultValue;
        Preciptiation.Value = Preciptiation.DefaultValue;
    }
}
