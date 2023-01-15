using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject weatherSettingsObject;
    [SerializeField] private GameObject timeLineObject;
    [SerializeField] private GameObject populationMenu;
    [SerializeField] private GameObject escMenu;
    [SerializeField] private GameObject ideaMenu;

    public void ChangeWeatherSettingsActiveStatus() =>
        weatherSettingsObject.SetActive(!weatherSettingsObject.activeSelf);
    
    public void ChangeTimeLineSettingsActiveStatus() => timeLineObject.SetActive(!timeLineObject.activeSelf);

    public void ChangePopulationMenuActiveStatus()
    {
        if (populationMenu.activeSelf)
            DrawPopulationMenu.DestroyObjects();
        else
            DrawPopulationMenu.DrawObjects();
        populationMenu.SetActive(!populationMenu.activeSelf);  
    }

    public void ChangeEscMenuActiveStatus()
    {
        escMenu.SetActive(!escMenu.activeSelf);
        PauseMenu.IsGamePaused = !PauseMenu.IsGamePaused;
    }

    public void ChangeIdeaMenuActiveStatus() => ideaMenu.SetActive(!ideaMenu.activeSelf);

    public void CloseGame() => Application.Quit();

    public void StartIteration() => Program.Run();

    public void StartGame() => SceneManager.LoadScene("SampleScene");
}