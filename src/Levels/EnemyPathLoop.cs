using Godot;
using System;

public class EnemyPathLoop : Path
{
    private PathFollow pathFollow;
    private Enemy enemy;

    public override void _Ready()
    {
        pathFollow = GetNode<PathFollow>("PathFollow");
        enemy = GetNode<Enemy>("PathFollow/Enemy");
    }

    public override void _PhysicsProcess(float delta)
    {
        float offset = delta * enemy.Speed;
        pathFollow.UnitOffset += delta * enemy.Speed;
    }
}
