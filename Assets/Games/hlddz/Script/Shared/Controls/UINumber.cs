using UnityEngine;
using System.Collections.Generic;

namespace com.QH.QPGame.DDZ
{
    [AddComponentMenu("Custom/Controls/Number")]
    public class UINumber : MonoBehaviour
    {

        public string NumPrefabs = null;
        public int BaseDepth = 300;
        public int ColSpace = 16;
        public int Height = 26;
        public int Width = 14;

        //--------------------------------------------------------------------------
        private int _number = 0;
        private int _shownumber = 0;
        private List<GameObject> _numlist = new List<GameObject>();
        private int _delay = 50;
        private int _tick = 0;

        private void Start()
        {

        }


        private void FixedUpdate()
        {

            if ((System.Environment.TickCount - _tick) > _delay)
            {
                int step = (int) (_number/10);
                _shownumber += step;
                SetNumber(_shownumber);
                _tick = System.Environment.TickCount;
            }
        }

        public void SetNumber(int num)
        {

            _number = System.Math.Abs(num);
            foreach (GameObject obj in _numlist)
            {
                Destroy(obj);
            }
            _numlist.Clear();


            string strNum = _number.ToString();

            int i = 0;
            foreach (char c in strNum.ToCharArray())
            {
                /*
                if(c=='-') 
                {
				
                }
                else
                {
                */
                GameObject obj = (GameObject) Instantiate(Resources.Load(NumPrefabs));
                obj.transform.parent = transform;

                UISprite sp = obj.GetComponent<UISprite>();
                sp.transform.localScale = new Vector3(Width, Height, 1);
                sp.depth = BaseDepth + i;
                //sp.spriteName = sp.spriteName.Substring(0,sp.spriteName.Length-1) + c.ToString();
                sp.spriteName = "numberc" + c.ToString();
                sp.transform.localPosition = new Vector3(ColSpace*i, 0, 0);
                _numlist.Add(obj);
                i++;
                //}
            }


            //int nX = (-1)*(((_numlist.Count)*Width + ColSpace + (int)Width)/2);
            //transform.localPosition = transform.localPosition + new Vector3(nX,0,0);

        }

        public void SetChangeNumber(int num, int delay)
        {
            _number = num;
            _delay = delay;
            _shownumber = 0;
            _tick = System.Environment.TickCount;
        }
    }

}