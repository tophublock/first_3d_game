using Godot;
using System;

public class EnemyPathLoop : Path
{
    private Vector3 oldPosition;
    private PathFollow pathFollow;
    private Enemy enemy;

    // TODO: refactor
    public override void _Ready()
    {
        pathFollow = GetNode<PathFollow>("PathFollow");
        enemy = GetNode<Enemy>("PathFollow/Enemy");

        pathFollow.UnitOffset = 0;
        oldPosition = pathFollow.GlobalTransform.origin + pathFollow.Translation;
    }

    public override void _PhysicsProcess(float delta)
    {
        pathFollow.UnitOffset += delta * enemy.Speed;

        var newPosition = pathFollow.GlobalTransform.origin + pathFollow.Translation;
        var direction = (newPosition - oldPosition).Normalized();
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
