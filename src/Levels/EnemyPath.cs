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

        // Rotate
        if (Math.Abs(direction.x) == 1)
        {
            var axis = direction.x > 0 ? Vector3.Forward: Vector3.Back;
            this.enemy.Transform = new Transform(
                this.enemy.Transform.basis.Rotated(axis, DegToRad(enemy.RotationAngle)),
                this.enemy.Transform.origin
            );
        }
        if (Math.Abs(direction.z) == 1)
        {
            var axis = direction.z > 0 ? Vector3.Right : Vector3.Left;
            this.enemy.Transform = new Transform(
                this.enemy.Transform.basis.Rotated(axis, DegToRad(enemy.RotationAngle)),
                this.enemy.Transform.origin
            );
        }

        oldPosition = newPosition;
    }

    private float DegToRad(float degrees)
    {
        return (Mathf.Pi / 180) * degrees;
    }

}
