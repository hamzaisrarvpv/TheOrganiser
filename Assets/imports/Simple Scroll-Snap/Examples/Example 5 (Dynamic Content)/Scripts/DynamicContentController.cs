// Simple Scroll-Snap
// Version: 1.1.2
// Author: Daniel Lochner

using System;
using UnityEngine;
using UnityEngine.UI;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class DynamicContentController : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        
        public GameObject panel;

        //private float toggleWidth;
        private SimpleScrollSnap sss;
        #endregion

        #region Methods
        private void Awake()
        {
            sss = GetComponent<SimpleScrollSnap>();
            Debug.Log("got it");
        }

        public void AddToFront()
        {
            Add(0);
        }
        public void AddToBack()
        {
            Add(sss.NumberOfPanels);
        }
        private void Add(int index)
        {
            //Panel
            //panel.GetComponent<Image>().color = new Color(UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f);
            sss.Add(panel, index);
        }

        public void RemoveFromFront()
        {
            Remove(0);
        }
        public void RemoveFromBack()
        {
            if (sss.NumberOfPanels > 0)
            {
                Remove(sss.NumberOfPanels - 1);
            }
            else
            {
                Remove(0);
            }
        }
        private void Remove(int index)
        {
            if (sss.NumberOfPanels > 0)
            {
                //Pagination
                DestroyImmediate(sss.pagination.transform.GetChild(sss.NumberOfPanels - 1).gameObject);
                //sss.pagination.transform.position += new Vector3(toggleWidth / 2f, 0, 0);

                //Panel
                sss.Remove(index);
            }
        }
        #endregion
    }
}