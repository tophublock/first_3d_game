using Godot;
using System;

public class GameOver : MarginContainer
{

    public override void _Ready()
    {

    }

//  public override void _Process(float delta)
//  {
//
//  }

    public void OnPlayAgainPressed()
    {
        GetTree().ChangeScene("res://src/Levels/Level.tscn");
    }
}
