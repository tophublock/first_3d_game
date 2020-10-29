using Godot;
using System;

public class HUD : CanvasLayer
{
    private Label coinCount;

    public override void _Ready()
    {
        coinCount = GetNode<Label>("MarginContainer/HBoxContainer/CoinCount");
        coinCount.Text = "0";
    }

    public void UpdateCoinCount(int count)
    {
        coinCount.Text = count.ToString();
    }
}
