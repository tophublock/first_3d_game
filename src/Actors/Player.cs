using Godot;
using System;

public class Player : KinematicBody
{
    const int SPEED = 10;
    private Vector3 velocity = Vector3.Zero;

    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("ui_right"))
        {
            velocity.x = SPEED;
        }
        else if (Input.IsActionPressed("ui_left"))
        {
            velocity.x = -SPEED;
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, 0, 0.1f);
        }

        if (Input.IsActionPressed("ui_up"))
        {
            velocity.z = -SPEED;
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            velocity.z = SPEED;
        } else
        {
            velocity.z = Mathf.Lerp(velocity.z, 0, 0.1f);

        }

        MoveAndSlide(velocity);
    }
}
