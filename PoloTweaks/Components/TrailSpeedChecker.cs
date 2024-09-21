using Reptile;
using UnityEngine;

namespace PoloTweaks.Components;

public class TrailSpeedChecker : MonoBehaviour {
    public float SpeedBarrier = 0f;

    public Player? player { set; private get; } = null;

    private TrailRenderer trail = null!;
    private Vector3 lastPos;

    private void Awake() {
        this.trail = this.GetComponent<TrailRenderer>();
    }

    private void Update() {
        var pos = this.transform.position;
        
        float speed; 
        
        if (this.player == null)
            speed = (pos - this.lastPos).magnitude / Time.deltaTime;
        else
            speed = this.player.GetVelocity().magnitude;
        
        this.trail.emitting = speed > this.SpeedBarrier;
        this.lastPos = pos;
        
    }
}
