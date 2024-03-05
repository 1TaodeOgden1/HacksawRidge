using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIToCam : MonoBehaviour
{
    [SerializeField] private Transform trackTo;
    public Vector3 offset;
    private Vector3 iniaitlOffset;
    private Camera cam;
    private void OnEnable()
    {
        if (RectOverlapSolver.Instance == null) return;
        RectOverlapSolver.Instance.UpdateActiveContents();
    }
    private void OnDisable()
    {
        RectOverlapSolver.Instance.UpdateActiveContents();
    }
    private void OnDestroy()
    {
        RectOverlapSolver.Instance.UpdateContents();
    }
    void Start()
    {
        cam = Camera.main;
        iniaitlOffset = offset;
    }

    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(trackTo.position);
        if(transform.position != pos + offset) transform.position = pos + offset;
    }
    public void TweakOffset(int i)
    {
        if (offset.x > iniaitlOffset.x - 1f && offset.x < iniaitlOffset.x + 1f)
        offset.x -= iniaitlOffset.x * i;
    }
    public void RestoreOffset()
    {
        offset.x = iniaitlOffset.x;
    }
}
