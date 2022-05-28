using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomNoise
{
    public static float RemapValue(float value, float initalMin, float initalMax, float outputMin, float outputMax)
    {
        return outputMin + (value - initalMin) * (outputMax - outputMin) / (initalMax - initalMin);
    }

    public static float RemapValue01(float value, float outputMin, float outputMax)
    {
        return outputMin + (value - 0) * (outputMax - outputMin) / (1 - 0);
    }

    public static int RemapValue01ToInt(float value, float outputMin, float outputMax)
    {
        return (int)RemapValue01(value, outputMin, outputMax);
    }

    public static float Redistribution(float noise, NoiseSettings settings)
    {
        return Mathf.Pow(noise * settings.redisributionModifier, settings.exponent);
    }

    public static float OctavePerlin(float x, float z, NoiseSettings settings)
    {
        x *= settings.noiseZoom;
        z *= settings.noiseZoom;
        x += settings.noiseZoom;    //Adding a small float (eg 0.001f) to make sure that x or z
        z += settings.noiseZoom;    //are not Int, as this causes the perlin noise to generate the same map
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float amplitudeSum = 0;     // Used for normalizing result to 0.0 - 1.0 ranges
        for (int i = 0; i < settings.octaves; i++)
        {
            total += Mathf.PerlinNoise((settings.offset.x + settings.worldOffset.x + x) * frequency, (settings.offset.y + settings.worldOffset.y + z) * frequency) * amplitude;
            amplitudeSum += amplitude;
            amplitude *= settings.persistance;
            frequency *= 2;
        }
        return total / amplitudeSum;
    }
}
