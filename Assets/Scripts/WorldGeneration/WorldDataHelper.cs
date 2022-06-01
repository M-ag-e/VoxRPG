using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldDataHelper
{
    public static Vector3Int ChunkPositionFromBlockCoords(World world, Vector3Int playerPos)
    {
        return new Vector3Int
        {
            x = Mathf.FloorToInt(playerPos.x / (float)world.chunkSize) * world.chunkSize,
            z = Mathf.FloorToInt(playerPos.z / (float)world.chunkSize) * world.chunkSize,
            y = Mathf.FloorToInt(playerPos.y / (float)world.chunkHeight) * world.chunkHeight
        };
    }
}
