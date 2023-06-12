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
        if (CurrentPopulation.Parameters.Count <= 1)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite1;
        else if (CurrentPopulation.Parameters.Count is >= 2 and < 10)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite2_10;
        else if (CurrentPopulation.Parameters.Count is >= 10 and < 100)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite10_100;
        else if (CurrentPopulation.Parameters.Count is >= 100 and < 1000)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite100_1000;
        else if (CurrentPopulation.Parameters.Count is >= 1000 and < 10000)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite1000_10000;
        else if (CurrentPopulation.Parameters.Count is >= 10000 and < 100000)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite10000_100000;
        else if (CurrentPopulation.Parameters.Count is >= 100000 and < 1000000)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite100000_1000000;
        else if (CurrentPopulation.Parameters.Count is >= 1000000 and < 10000000)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite1000000_10000000;
        else if (CurrentPopulation.Parameters.Count is >= 10000000 and < 100000000)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite10000000_100000000;
        else if (CurrentPopulation.Parameters.Count is >= 100000000 and < 1000000000)
            populationImage.sprite = CurrentPopulation.Sprites.Sprite100000000_1000000000;
        else
            populationImage.sprite = CurrentPopulation.Sprites.Sprite1000000000_10000000000;
        
        Program.Population = CurrentPopulation;
        Program.NeedsUpdateUI = true;
        NeedsUpdatePopulation = false;
    }
}
