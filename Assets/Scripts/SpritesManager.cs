using System;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private Sprite humanSprite;
    [SerializeField] private Sprite fireHumanSprite;
    [SerializeField] private Sprite coldHumanSprite;

    [SerializeField] private Sprite humanPopulationSprite;
    [SerializeField] private Sprite fireHumanPopulationSprite;
    [SerializeField] private Sprite coldHumanPopulationSprite;

    public static Sprite HumanSprite;
    public static Sprite FireHumanSprite;
    public static Sprite ColdHumanSprite;
    
    public static Sprite HumanPopulationSprite;
    public static Sprite FireHumanPopulationSprite;
    public static Sprite ColdHumanPopulationSprite;

    private void Start()
    {
        HumanSprite = humanSprite;
        FireHumanSprite = fireHumanSprite;
        ColdHumanSprite = coldHumanSprite;

        HumanPopulationSprite = humanPopulationSprite;
        FireHumanPopulationSprite = fireHumanPopulationSprite;
        ColdHumanPopulationSprite = coldHumanPopulationSprite;
    }
}