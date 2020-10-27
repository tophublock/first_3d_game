using Godot;
using System;

public class MainMenu : Control
{
    public override void _Ready()
    {

    }

//  public override void _Process(float delta)
//  {
//
//  }

    public void OnStartPressed()
    {
        GetTree().ChangeScene("res://src/Levels/Level.tscn");
    }
}
