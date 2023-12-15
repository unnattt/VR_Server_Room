using System;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particles; 
    private ParticleSystem.NoiseModule particleNoise;  
    private ParticleSystem.EmissionModule emissionModule;
    private ParticleSystem.MainModule mainModule;

    private float pitch;
    private float volume;
    public static Action<float, float> OnVoiceBeingSpoken;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        OnVoiceBeingSpoken += UpdateParticleSystem;
    }
    
    void Start()
    {
        particleNoise = particles.noise;
        emissionModule = particles.emission;
        mainModule = particles.main;
    }

    void Update()
    {
        // Manipulate particle system based on pitch and volume
        // Example: adjust emission rate and speed        
        //particleNoise.strength = Map(volume, 0f, 1f, 1f, 10f);
        emissionModule.rateOverTime = Map(volume, 0f, 30f, 1f, 80f);
        mainModule.startSpeed = Map(volume, 0f, 30f, 1f, 15f);
        
        //mainModule.startLifetime = volume; // Adjust based on volume
        //mainModule.startSpeed = pitch; // Adjust based on pitch
    }

    void UpdateParticleSystem(float pitch, float volume)
    {
        // Implement particle system manipulation based on pitch and volume
        // Adjust particle system parameters, speed, emission rate, etc.
        this.pitch = pitch;
        this.volume = volume;
        Debug.Log($"Pitch: {pitch}, Volume: {volume}");
    }

    public float Map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
        {
            return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
        }    
}
