using Godot;
using System;

public class Level : Spatial
{
    const int MAX_COINS = 12;
    private int coins = 0;
    private HUD hud;

    public override void _Ready()
    {
        coins = 0;
        hud = GetNode<HUD>("HUD");
        hud.UpdateCoinCount(coins);
    }

    public void OnCoinCollected()
    {
        coins++;
        hud.UpdateCoinCount(coins);
    }
}
