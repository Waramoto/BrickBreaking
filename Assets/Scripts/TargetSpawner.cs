using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    private List<Target> _targets;
    private List<float> _xRand;
    private int _randomNumber;
    
    private readonly List<float> _xCoords = new List<float>();
    private readonly float _yCoord = 4.65f;
    private readonly System.Random _rand = new System.Random();

    [SerializeField] private Block block;
    [SerializeField] private LineBomb lineBomb;
    [SerializeField] private AoeBomb aoeBomb;
    [SerializeField] private GameIteration gameIteration;
    [SerializeField] private Button ballsReturnButton;

    private void Start()
    {
        for (var i = 0; i < 8; i++)
        {
            _xCoords.Add((float) Math.Round(-2.45 + 0.7 * i, 2));
        }

        _targets = new List<Target>();
        _xRand = new List<float>(_xCoords);
        gameIteration.InProcess = false;
    }

    private void Update()
    {
        if (gameIteration.InProcess == false)
        {
            ballsReturnButton.gameObject.SetActive(false);
            
            for (var i = _targets.Count - 1; i >= 0; i--)
            {
                if (_targets[i].IsDestroyed)
                {
                    _targets.RemoveAt(i);
                }
            }
            
            foreach (var t in _targets)
            {
                var transform1 = t.transform;
                var tp = transform1.position;
                transform1.position = new Vector3(tp.x, tp.y - 0.7f, tp.z);
            }

            MixList(_xRand);

            for (var i = 0; i < 3; i++)
            {
                var pos = new Vector3(_xRand[i], _yCoord, -1);
                var target = Instantiate(block, pos, Quaternion.identity);
                _targets.Add(target);
            }

            _randomNumber = Convert.ToInt32(Random.Range(1f, 6f));
            if (_randomNumber % 6 == 0)
            {
                var pos = new Vector3(_xRand[3], _yCoord, -1);
                var target = Instantiate(lineBomb, pos, Quaternion.identity);
                _targets.Add(target);
            }
            else if (_randomNumber % 5 == 0)
            {
                var pos = new Vector3(_xRand[3], _yCoord, -1);
                var target = Instantiate(aoeBomb, pos, Quaternion.identity);
                _targets.Add(target);
            }

            gameIteration.InProcess = true;
        }
    }

    private void MixList(List<float> list)
    {
        for (var i = list.Count - 1; i >= 1; i--)
        {
            var j = _rand.Next(i + 1);
            (list[j], list[i]) = (list[i], list[j]);
        }
    }
}
