
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public void Activate(bool activate = true)
    {
        if (activate)
        {
            _trailRenderer.enabled = true;
            // turn of particle effects
            // turn on sound
            // etc.
        }
        else
        {
            _trailRenderer.enabled = false;
            // turn off particle effects
            // turn off sound
            // etc.

        }
    }

}
