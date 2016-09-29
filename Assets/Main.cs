using UnityEngine;
using System.Collections.Generic;

namespace Assets
{
    public class Main : MonoBehaviour
    {
        const string _linePrefPath = "Line";
        public int CountLine = 6;
        private List<Line> Lines = new List<Line>();
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < CountLine; i++)
            {
                GameObject pref = Resources.Load<GameObject>(_linePrefPath);
                GameObject inst = Instantiate(pref);
                inst.transform.parent = gameObject.transform;
                Lines.Add(inst.GetComponent<Line>());
            }
            for (int i = 0; i < CountLine; i++)
            {
                Lines[i].Next = Lines[(i + 1) % CountLine];
            }
            for (int i = 0; i < CountLine; i++)
            {
                Lines[i].IsStart = true;
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
