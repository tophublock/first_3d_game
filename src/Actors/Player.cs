using Godot;
using System;

public class Player : KinematicBody
{
    const int SPEED = 10;
    const int ROT_ANGLE = 7;
    private Vector3 velocity = Vector3.Zero;
    private MeshInstance _mesh;

    public override void _Ready()
    {
        _mesh = GetNode<MeshInstance>("MeshInstance");
    }

    public override void _PhysicsProcess(float delta)
    {
        bool isMovingOnXAxis = true;
        bool isMovingOnZAxis = true;
        var rotation = Vector3.Zero;

        if (Input.IsActionPressed("ui_right"))
        {
            velocity.x = SPEED;
            rotation.z = DegToRad(-ROT_ANGLE);
        }
        else if (Input.IsActionPressed("ui_left"))
        {
            velocity.x = -SPEED;
            rotation.z = DegToRad(ROT_ANGLE);
        }
        else
        {
            isMovingOnXAxis = false;
            velocity.x = Mathf.Lerp(velocity.x, 0, 0.1f);
        }

        if (Input.IsActionPressed("ui_up"))
        {
            velocity.z = -SPEED;
            rotation.x = DegToRad(-ROT_ANGLE);
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            velocity.z = SPEED;
            rotation.x = DegToRad(-ROT_ANGLE);
        } else
        {
            isMovingOnZAxis = false;
            velocity.z = Mathf.Lerp(velocity.z, 0, 0.1f);
        }

        // Slow down rotation when moving diagonally
        if (isMovingOnXAxis && isMovingOnZAxis)
        {
            rotation.x /= 2;
            rotation.z /= 2;
        }

        _mesh.RotateX(rotation.x);
        _mesh.RotateZ(rotation.z);
        MoveAndSlide(velocity);
    }

    private float DegToRad(float degrees)
    {
        return (Mathf.Pi / 180) * degrees;
    }
}
