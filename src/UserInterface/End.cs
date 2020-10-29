using Godot;
using System;

public class End : MarginContainer
{
    public override void _Ready()
    {

    }

    public void OnPlayAgainPressed()
    {
        GetTree().ChangeScene("res://src/Levels/Level.tscn");

    }

    public void OnQuitPressed()
    {
        GetTree().Quit();
    }
}
