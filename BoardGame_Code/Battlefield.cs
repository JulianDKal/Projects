using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    public GameObject NothingBlock;
    public GameObject MoveBlock;
    public GameObject AttackBlock;
    public GameObject ShieldBlock;

    List<GameObject> field = new List<GameObject>(16);

    public GameObject posChecker;

    void Start()
    {
        int fieldCount = -1;

        for (int i = 0; i < 4; i++)
        {
            field.Add(NothingBlock);
            field.Add(MoveBlock);
            field.Add(AttackBlock);
            field.Add(ShieldBlock);
        }

        field.Shuffle();

        for (int x = 0; x < 4; x++)
        {
            
            for (int y = 0; y < 4; y++)
            {
            fieldCount++;
            Instantiate(field[fieldCount], new Vector3(x*1.1f, 0,y*1.1f ), Quaternion.identity);
            
            }

        }

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                Instantiate(posChecker, new Vector3(x*1.1f, 0,y*1.1f ), Quaternion.identity);
            }
        }
    }
}
