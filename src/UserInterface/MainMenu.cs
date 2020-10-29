using Godot;
using System;

public class MainMenu : Control
{
    public override void _Ready()
    {

    }

    public void OnStartPressed()
    {
        GetTree().ChangeScene("res://src/Levels/Level.tscn");
    }
}
