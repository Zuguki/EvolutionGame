using System;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private Sprite humanSprite;
    [SerializeField] private Sprite fireHumanSprite;
    [SerializeField] private Sprite coldHumanSprite;

    public static Sprite HumanSprite;
    public static Sprite FireHumanSprite;
    public static Sprite ColdHumanSprite;

    private void Start()
    {
        HumanSprite = humanSprite;
        FireHumanSprite = fireHumanSprite;
        ColdHumanSprite = coldHumanSprite;
    }
}