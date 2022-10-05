using UnityEngine;
using UnityEngine.UI;

public class UILine : Graphic
{
    [SerializeField]
    private Vector2 _pos1;

    [SerializeField]
    private Vector2 _pos2;

    [SerializeField]
    private float _weight;

    [SerializeField]
    private float _targetLength;

    private void Update()
    {
        if (Vector2.Distance(_pos1, _pos2) >= _targetLength) return;

        if(_pos1.x > _pos2.x)
        {
            _pos1.x++;
        }
        else
        {
            _pos2.x++;
        }

        SetAllDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        // 過去にAddした頂点を全部削除
        vh.Clear();

        // 点を頂点リストに追加
        AddVert(vh, new Vector2(_pos1.x, _pos1.y - _weight / 2));
        AddVert(vh, new Vector2(_pos1.x, _pos1.y + _weight / 2));
        AddVert(vh, new Vector2(_pos2.x, _pos2.y - _weight / 2));
        AddVert(vh, new Vector2(_pos2.x, _pos2.y + _weight / 2));

        // 頂点リストを元にメッシュを貼る
        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(1, 2, 3);
    }

    private void AddVert(VertexHelper vh, Vector2 pos)
    {
        var vert = UIVertex.simpleVert;
        vert.position = pos;
        vert.color = color;
        vh.AddVert(vert);
    }
}
