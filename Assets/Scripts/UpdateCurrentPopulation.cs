using Population;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrentPopulation : MonoBehaviour
{
    public static bool NeedsUpdatePopulation;
    public static IPopulation CurrentPopulation;

    [SerializeField] private TextMeshProUGUI populationName;
    [SerializeField] private Image populationImage;

    private void Update()
    {
        if (!NeedsUpdatePopulation)
            return;

        populationName.text = CurrentPopulation.Name;
        Program.Population = CurrentPopulation;
        NeedsUpdatePopulation = false;
    }
}
