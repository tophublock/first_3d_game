using Godot;
using System;

public class EnemyPath : Path
{
    // 1 = forwards, -1 =  backwards
    private int pathDirection = 1;
    private Vector3 oldPosition;
    private PathFollow pathFollow;
    private Enemy enemy;

    public override void _Ready()
    {
        pathFollow = GetNode<PathFollow>("PathFollow");
        enemy = GetNode<Enemy>("PathFollow/Enemy");

        pathFollow.UnitOffset = 0;
        oldPosition = pathFollow.GlobalTransform.origin + pathFollow.Translation;
    }

    public override void _PhysicsProcess(float delta)
    {
        float offset = delta * enemy.Speed * pathDirection;
        if (pathDirection == 1 && pathFollow.UnitOffset + offset >= 1)
        {
            pathFollow.UnitOffset = 1;
            pathDirection *= -1;
        }
        else if (pathDirection == -1 && pathFollow.UnitOffset + offset <= 0)
        {
            pathFollow.UnitOffset = 0;
            pathDirection *= -1;
        }
        else
        {
            pathFollow.UnitOffset += delta * enemy.Speed * pathDirection;
        }

        var newPosition = pathFollow.GlobalTransform.origin + pathFollow.Translation;
        var direction = (newPosition - oldPosition).Normalized();
        if (this.Name == "EnemyPath")
        {
            Console.WriteLine(oldPosition);
            Console.WriteLine(newPosition);
            Console.WriteLine(direction);
            Console.WriteLine("--------");
        }

        // Rotate
        if (direction.x != 0)
        {
            var orientation = direction.x > 0 ? 1 : -1;
            enemy.RotateZ(DegToRad(enemy.RotationAngle * -1 * orientation));
        }
        if (direction.z != 0)
        {
            var orientation = direction.z > 0 ? -1 : 1;
            enemy.RotateX(DegToRad(enemy.RotationAngle * -1 * orientation));
        }

        oldPosition = newPosition;
    }

    private float DegToRad(float degrees)
    {
        return (Mathf.Pi / 180) * degrees;
    }

}
