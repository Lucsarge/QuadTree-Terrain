using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpatialTree
{
    public class QuadTree
    {
        static int depth = 4;                   //  The number of steps down that the squares are allowed to go
        public Vector2 coordinates;                //  Coordinates for the center of the square
        public float size;                         //  Size of the square, the width or height
        public int level;                          //  The current level of the square
        public QuadTree[] nodes = new QuadTree[4]; //  The 4 child squares that will exist only when subdivided

        //  Constructs a QuadTree with new coordinates, size, and level (which defaults to zero)
        public QuadTree(Vector2 coordinates, float size, int level = 0)
        {
            this.coordinates = coordinates;
            this.size = size;
            this.level = level;

            if (level < depth)
            {
                Subdivide();
            }

            ToString();
        }

        //  Adds four new quadrants to the squares in the order of: TopLeft, TopRight, BottomLeft, BottomRight
        private void Subdivide()
        {
            float fourthSize = this.size / 4;
            int nextLevel = level+1;
            for(int i = 0; i < 4; i++)
            {
                nodes[i] = new QuadTree(NewCoords(i, fourthSize), this.size / 2, nextLevel);
            }
        }

        //  Returns what the new Vector2 coordinates should be by adding or subtracting a quarter of the size from the x or y coordinate
        private Vector2 NewCoords(int quadrant, float fourthSize)
        {
            switch (quadrant) {
                case 0:
                    return new Vector2(this.coordinates.x - fourthSize, this.coordinates.y + fourthSize);
                case 1:
                    return new Vector2(this.coordinates.x + fourthSize, this.coordinates.y + fourthSize);
                case 2:
                    return new Vector2(this.coordinates.x - fourthSize, this.coordinates.y - fourthSize);
                case 3:
                    return new Vector2(this.coordinates.x + fourthSize, this.coordinates.y - fourthSize);
            }
            return Vector2.zero;
        }

        //  Modified ToString to print out the details of the current quad
        public override string ToString()
        {
            return "Coordinates: " + "(" + coordinates[0] + "," + coordinates[1] + ")\n" +
                   "Size: " + size + "\n" +
                   "Level: " + level + "\n" +
                   "QuadTree Depth: " + depth;
        }
    }
}


