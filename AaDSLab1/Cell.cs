using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaDSLab1
{
    class Cell
    {
        private int value;
        private bool isVisited;
        private int possibleWaysToGo;

        public int Value { get => value; set => this.value = value; }
        public bool IsVisited { get { return isVisited; } set { this.isVisited = value; } }
        public int PossibleWaysToGo { get { return possibleWaysToGo; } set { this.possibleWaysToGo = value; } }

        public Cell()
        {
            isVisited = false;
            PossibleWaysToGo = 0;
        }

        public override string ToString() => this.Value.ToString();
    }
}
