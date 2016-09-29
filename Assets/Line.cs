using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Assets
{
    class Line : MonoBehaviour
    {
        public Vector3 StartPos;
        public Vector3 CurPos;
        public float Speed = 0.5f;
        public Line Next = null;
        LineRenderer _line;
        List<Vector3> _coord;
        bool _isChange;
        public int _step = 0;
        private int _maxStep = 500;


        const float _tick = 0.03f;
        private float _timer = _tick;


        public bool IsStart = false;
        // Use this for initialization
        void Start()
        {
            StartPos.x = Random.Range(-9f, 9f);
            StartPos.y = Random.Range(-4f, 4f);
            StartPos.z = 0;
            CurPos = StartPos;

            _coord = new List<Vector3>();
            Vector3 v = CurPos;
           // v.x *= Screen.width;
            //v.y *= Screen.height;
           // v = Camera.main.ScreenToWorldPoint(v);
            v.z = 0;
            _coord.Add(v);

            _line = gameObject.GetComponentInParent<LineRenderer>();

            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            Color c = new Color(r, g, b);

            _line.SetColors(c, c);
            _line.SetVertexCount(_step+1);
            _line.SetPositions(_coord.ToArray());

        }
        void Update()
        {
            if (_step > _maxStep) return;
            if (!IsStart) return;
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer += _tick;
                _step++;
                if (_step > _maxStep) return;
               
                Vector3 delt = Next.CurPos - CurPos;
                delt = delt.normalized;
                CurPos = CurPos + delt * Speed;


                Vector3 v = CurPos;
                //v.x *= Screen.width;
                //v.y *= Screen.height;
                //v = Camera.main.ScreenToWorldPoint(v);
                v.z = 0;
                _coord.Add(v);

                
                _line.SetVertexCount(_step+1);
                _line.SetPositions(_coord.ToArray());
            }
        }
    }
}

