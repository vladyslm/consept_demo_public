using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class Environment : MonoBehaviour
{
    [SerializeField] private GameObject _tile;

    [SerializeField] private GameObject _blockContainer;

    [SerializeField] private int _chankSize;

    private Vector3Int _initPos = Vector3Int.zero;


    private Hashtable _blockHashtable = new Hashtable();

    [Header("Area")] [SerializeField] private Vector3Reference areaSize;

    [SerializeField] private Vector3Reference areaPosition;

    void Awake()
    {
        GenerateChank(_initPos);
    }


    private void GenerateChank(Vector3Int initPos)
    {
        for (int x = -_chankSize; x < _chankSize; x++)
        {
            for (int z = -_chankSize; z < _chankSize; z++)
            {
                //     var xAxis = initPos.x >= 0 ? initPos.x + x : initPos.x - x;
                //     var zAxis = initPos.z >= 0 ? initPos.z + z : initPos.z - z;

                var blockPos = new Vector3Int(x, 0, z);
                // var blockPos = 

                if (!_blockHashtable.ContainsKey(blockPos))
                {
                    GameObject block = Instantiate(_tile, _blockContainer.transform);
                    block.transform.position = blockPos;

                    _blockHashtable.Add(blockPos, block);
                }
            }
        }
    }


    public void OnCleanArea()
    {
        var x = (int)areaPosition.Value.x;
        var z = (int)areaPosition.Value.z;
        var key = new Vector3Int(x, 0, z);
        if (!_blockHashtable.ContainsKey(key)) return;

        var sizeX = areaSize.Value.x;
        var sizeZ = areaSize.Value.z;

        var startX = x - Mathf.FloorToInt(areaSize.Value.x / 2);
        var startZ = z - Mathf.FloorToInt(areaSize.Value.z / 2);

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                var keyVal = new Vector3Int(i + startX, 0, j + startZ);
                var groundEl = (GameObject)_blockHashtable[keyVal];
                groundEl.SetActive(false);
            }
        }
    }
}