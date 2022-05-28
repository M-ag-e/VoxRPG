using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGenerator : MonoBehaviour
{
    public NoiseSettings biomeNoiseSettings;
    public BlockLayerHandler startLayerHandler;
    public DomainWarping domainWarping;

    public List<BlockLayerHandler> additionalLayerHandlers;
    public ChunkData ProcessChunkColumn(ChunkData data, int x, int z, Vector2Int mapSeedOffset)
    {
        biomeNoiseSettings.worldOffset = mapSeedOffset;
        int groundPosition = GetSurfaceHeightNoise(data.worldPosition.x + x, data.worldPosition.z + z, data.chunkHeight);

        for (int y = 0; y < data.chunkHeight; y++)
        {
            startLayerHandler.Handle(data, x, y, z, groundPosition, mapSeedOffset);
        }
        foreach (var layer in additionalLayerHandlers)
        {
            layer.Handle(data, x, data.worldPosition.y, z, groundPosition, mapSeedOffset);
        }
        return data;
    }

    private int GetSurfaceHeightNoise(int x, int z, int chunkHeight)
    {
        //float terrainHeight = CustomNoise.OctavePerlin(x, z, biomeNoiseSettings);
        float terrainHeight = domainWarping.GenerateDomainNoise(x, z, biomeNoiseSettings);
        terrainHeight = CustomNoise.Redistribution(terrainHeight, biomeNoiseSettings);
        int surfaceHeight = CustomNoise.RemapValue01ToInt(terrainHeight, 0, chunkHeight);
        return surfaceHeight;
    }
}
