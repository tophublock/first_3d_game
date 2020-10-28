using Godot;
using System;

public class Enemy : Area
{
    [Export]
    public float Speed = 0.5f;

    public override void _Ready()
    {
    }

    public override void _PhysicsProcess(float delta)
    {
    }
}
