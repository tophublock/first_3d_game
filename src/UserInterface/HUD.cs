using Godot;
using System;

public class HUD : CanvasLayer
{

    private int coins = 0;
    private Label coinCount;

    public override void _Ready()
    {
        coinCount = GetNode<Label>("MarginContainer/HBoxContainer/CoinCount");
        coinCount.Text = "0";
    }

    public void OnCoinCollected()
    {
        coins++;
        coinCount.Text = coins.ToString();
    }
}
