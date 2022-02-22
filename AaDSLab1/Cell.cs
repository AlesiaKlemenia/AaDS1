namespace AaDSLab1
{
    class Cell
    {
        private int _value;
        private bool _isVisited;
        private int _possibleWaysToGo;

        public int Value { 
            get => _value; 
            set => this._value = value; 
        }

        public bool IsVisited { 
            get => _isVisited;
            set => this._isVisited = value;
        }

        public int PossibleWaysToGo { 
            get => _possibleWaysToGo; 
            set => this._possibleWaysToGo = value; 
        }

        public Cell()
        {
            IsVisited = false;
            PossibleWaysToGo = 0;
        }

        public override string ToString() => this.Value.ToString();
    }
}