﻿using System.Collections.Generic;

namespace ShapeTask.Comparators
{
    class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}