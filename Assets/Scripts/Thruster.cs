
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour
{
    private TrailRenderer _thrusterTrail;
    private Light _thrusterLight;

    private void Awake()
    {
        _thrusterTrail = GetComponent<TrailRenderer>();
        _thrusterLight = GetComponent<Light>();
    }

    private void Start()
    {
        _thrusterTrail.enabled = false;
        _thrusterLight.enabled = false;
    }

    public void Activate(bool activate = true)
    {
        if (activate)
        {
            _thrusterTrail.enabled = true;
            _thrusterLight.enabled = true;
            // turn of particle effects
            // turn on sound
            // etc.
        }
        else
        {
            _thrusterTrail.enabled = false;
            _thrusterLight.enabled = false;
            // turn off particle effects
            // turn off sound
            // etc.

        }
    }

}
