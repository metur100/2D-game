using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RotationTilemap : MonoBehaviour
{
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 0f), Vector3.one);
        tilemap.SetTransformMatrix(new Vector3Int(0, 0, 0), matrix);
    }

    private void SetTile(Vector3Int pos, Quaternion rot, Tilemap tilemap, TileBase tile)
    {
        tilemap.SetTile(pos, tile);
        tilemap.SetTransformMatrix(pos, Matrix4x4.TRS(Vector3.zero, rot, Vector3.one));
    }
}
