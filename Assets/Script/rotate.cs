using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Update()
    {
		this.transform.Rotate(Vector3.down * 0.1f);
    }
}
