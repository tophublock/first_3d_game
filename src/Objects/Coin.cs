using Godot;
using System;

public class Coin : Area
{
    public float RotationSpeed = 3;
    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        this.Transform = new Transform(
            this.Transform.basis.Rotated(Vector3.Up, DegToRad(RotationSpeed)),
            this.Transform.origin
        );
    }
    private float DegToRad(float degrees)
    {
        return (Mathf.Pi / 180) * degrees;
    }

    public void OnCoinBodyEntered(Node body)
    {
        if (body is Player player)
        {
            Console.WriteLine("coin collected!");
            var timer = GetNode<Timer>("Timer");
            timer.Start();
        }
    }

    public void OnTimerTimeout()
    {
        QueueFree();
    }
}
