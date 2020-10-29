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

        if (coins >= MAX_COINS)
        {
            var timer = new Timer();
            timer.WaitTime = 0.25f;
            timer.OneShot = true;
            timer.Connect("timeout", this, nameof(EndGame));

            AddChild(timer);
            timer.Start();
        }
    }

    public void EndGame()
    {
        GetTree().ChangeScene("res://src/UserInterface/End.tscn");
    }
}
