using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private Vector3 _worldPos;
    public Vector3 _planeSize { get; private set; }
    public Vector3 _planeWorldSize { get; private set; }

    private Material _material;
    private MeshFilter _meshFilter;
    public Transform _flowersParent { get; private set; }
    public Transform _trees1Parent { get; private set; }
    public Transform _trees2Parent { get; private set; }

    private void Awake()
    {       
        _worldPos = Vector3.zero;
        _material = Resources.Load<Material>("Materials/Green");
        _meshFilter = GetComponent<MeshFilter>();
        _planeSize = this._meshFilter.mesh.bounds.size;

        this.transform.localScale = new Vector3(6, 1, 6); // это первый
        _planeWorldSize = Vector3.Scale(_planeSize, this.transform.localScale); // умножаем размер на скейл;

        this.GetComponent<Renderer>().material = _material;
        this.tag = "Map";

        _flowersParent = new GameObject("Flowers").transform; // нужно обязательно инициализировать объект, иначе не создастся
        _trees1Parent = new GameObject("Trees1").transform;
        _trees2Parent = new GameObject("Trees2").transform;

        _flowersParent.transform.SetParent(this.transform);
        _trees1Parent.transform.SetParent(this.transform);
        _trees2Parent.transform.SetParent(this.transform);
    }
}
