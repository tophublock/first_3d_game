using Godot;
using System;

public class Coin : Area
{
    [Signal]
    public delegate void CoinCollected();
    public float RotationSpeed = 3;

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
            var collision = GetNode<CollisionShape>("CollisionShape");
            collision.Hide();

            var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
            var timer = GetNode<Timer>("Timer");

            animationPlayer.Play("bounce");
            timer.Start();
        }
    }

    public void OnTimerTimeout()
    {
        EmitSignal(nameof(CoinCollected));
        QueueFree();
    }
}
