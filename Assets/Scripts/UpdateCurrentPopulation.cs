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

        if (CurrentPopulation is null)
        {
            populationName.text = "";
            populationImage.sprite = SpritesManager.DefaultPopulationSprite;
            NeedsUpdatePopulation = false;
            return;
        }
        
        populationName.text = CurrentPopulation.Name;
        populationImage.sprite = CurrentPopulation.SpriteOfPopulationMenu;
        Program.Population = CurrentPopulation;
        Program.NeedsUpdateUI = true;
        NeedsUpdatePopulation = false;
    }
}
