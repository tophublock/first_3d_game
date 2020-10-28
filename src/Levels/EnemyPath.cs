using Godot;
using System;

public class EnemyPath : Path
{
    // 1 = forwards, -1 =  backwards
    private int direction = 1;
    private PathFollow pathFollow;
    private Enemy enemy;

    public override void _Ready()
    {
        pathFollow = GetNode<PathFollow>("PathFollow");
        enemy = GetNode<Enemy>("PathFollow/Enemy");
    }

    public override void _PhysicsProcess(float delta)
    {
        float offset = delta * enemy.Speed * direction;
        if (direction == 1 && pathFollow.UnitOffset + offset >= 1)
        {
            pathFollow.UnitOffset = 1;
            direction *= -1;
        }
        else if (direction == -1 && pathFollow.UnitOffset + offset <= 0)
        {
            pathFollow.UnitOffset = 0;
            direction *= -1;
        }
        else
        {
            pathFollow.UnitOffset += delta * enemy.Speed * direction;
        }
    }
}
