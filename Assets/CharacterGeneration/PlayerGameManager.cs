using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerGameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject player;
    public Vector3Int currentPlayerChunkPosition;
    private Vector3Int currentChunkCenter = Vector3Int.zero;

    public World world;

    public float dectectionTime = 1;
    public CinemachineVirtualCamera cameraVM;

    public void SpawnPlayer()
    {
        if (player != null)
            return;
        Vector3Int raycastStartPoint = new Vector3Int(world.chunkSize / 2, 100, world.chunkSize / 2);
        RaycastHit Hit;
        if (Physics.Raycast(raycastStartPoint, Vector3.down, out Hit, 120))
        {
            player = Instantiate(playerPrefab, Hit.point + Vector3Int.up, Quaternion.identity);
            cameraVM.Follow = player.transform.GetChild(0);
            StartCheckingTheMap();
        }
    }

    private void StartCheckingTheMap()
    {
        SetCurrentChunkCoordinates();
        StopAllCoroutines();
        StartCoroutine(CheckIfShouldLoadNextPosition());
    }
    IEnumerator CheckIfShouldLoadNextPosition()
    {
        yield return new WaitForSeconds(dectectionTime);
        if(Mathf.Abs(currentChunkCenter.x - player.transform.position.x) > world.chunkSize ||
           Mathf.Abs(currentChunkCenter.z - player.transform.position.z) > world.chunkSize ||
           Mathf.Abs(currentPlayerChunkPosition.y - player.transform.position.y) > world.chunkHeight)
        {
            world.LoadAdditionalChunksRequest(player);
        }
        else
        {
            StartCoroutine(CheckIfShouldLoadNextPosition());
        }
    }
    private void SetCurrentChunkCoordinates()
    {
        currentPlayerChunkPosition = WorldDataHelper.ChunkPositionFromBlockCoords(world, Vector3Int.RoundToInt(player.transform.position));
        currentChunkCenter.x = currentPlayerChunkPosition.x + world.chunkSize / 2;
        currentChunkCenter.z = currentPlayerChunkPosition.z + world.chunkSize / 2;
    }
}
