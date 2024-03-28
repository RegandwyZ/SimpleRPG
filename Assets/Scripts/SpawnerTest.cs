using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerTest : MonoBehaviour
{
    [SerializeField] private GameObject[] _skeleton;
    [SerializeField] private Transform[] _points;

    private float _timer;
    private const float _cooldown = 3f;

    private void Start()
    {
        Instantiate(_skeleton[0], _points[0].position, Quaternion.identity);
    }

    private void Spawn()
    {
        var random = Random.Range(0, 3);
        Instantiate(_skeleton[random], _points[random].position, Quaternion.identity);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (!(_timer >= _cooldown)) return;
        Spawn();
        _timer = 0;
    }
}
