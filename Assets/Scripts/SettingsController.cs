using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weather;
using Weather.Implementation;

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
        _temperatureValue.onValueChanged.AddListener((value) =>
        {
            Temperature.Value = ParseFloat(value);
        });
        
        _pressureValue.onValueChanged.AddListener((value) =>
        {
            _pressureSlider.value = ParseFloat(value);
            pressurePanelValue.text = value;
        });
        _pressureSlider.onValueChanged.AddListener((value) =>
            _pressureValue.text = value.ToString(CultureInfo.InvariantCulture));
        
        _radiationValue.onValueChanged.AddListener((value) =>
        {
            _radiationSlider.value = ParseFloat(value);
            radiationPanelValue.text = value;
        });
        _radiationSlider.onValueChanged.AddListener((value) =>
            _radiationValue.text = value.ToString(CultureInfo.InvariantCulture));
        
        _humidityValue.onValueChanged.AddListener((value) =>
        {
            _humiditySlider.value = ParseFloat(value);
            humidityPanelValue.text = value;
        });
        _humiditySlider.onValueChanged.AddListener((value) =>
            _humidityValue.text = value.ToString(CultureInfo.InvariantCulture));
        
        _windSpeedValue.onValueChanged.AddListener((value) =>
        {
            _windSpeedSlider.value = ParseFloat(value);
            windSpeedPanelValue.text = value;
        });
        _windSpeedSlider.onValueChanged.AddListener((value) =>
            _windSpeedValue.text = value.ToString(CultureInfo.InvariantCulture));
        
        _preciptiationValue.onValueChanged.AddListener((value) =>
        {
            _preciptioationSlider.value = ParseFloat(value);
            preciptiationPanelValue.text = value;
        });
        _preciptioationSlider.onValueChanged.AddListener((value) =>
            _preciptiationValue.text = value.ToString(CultureInfo.InvariantCulture));
        
        _resetButton.onClick.AddListener(ResetValues);
    }

    private void ResetValues()
    {
        Temperature.Value = Temperature.DefaultValue;
    }

    private float ParseFloat(string value)
    {
        var isFloat = float.TryParse(value, out var result);
        if (isFloat)
            return result;
        
        _temperatureValue.text = _temperatureSlider.value.ToString(CultureInfo.InvariantCulture);
        return _temperatureSlider.value;
    }
}
