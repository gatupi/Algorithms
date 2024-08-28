namespace FootballMatchDrawing.Classes;

struct PairListPermutation
{

    private int[] _array = [];
    public PairListPermutation(int totalIndexes)
    {
        TotalIndexes = totalIndexes;
    }

    public int TotalIndexes { get; }

    public (int, int)[,] Permutate(bool randomize = false)
    {
        FillArray();
        if (randomize)
        {
            _array.Shuffle();
        }
        int totalLists = _array.Length - 1;
        int totalListPairs = _array.Length / 2;
        var matrix = new (int, int)[totalLists, totalListPairs];

        for (int i = 0; i < totalLists; i++)
        {
            for (int j = 0; j < totalListPairs; j++)
            {
                matrix[i, j].Item1 = _array[j];
                matrix[i, j].Item2 = _array[_array.Length - 1 - j];
            }
            if (randomize)
            {
                matrix.ShuffleRow(i);
            }
            RotateArray();
        }
        return matrix;
    }

    private void RotateArray()
    {
        for (int i = 1; i < _array.Length - 1; i++)
        {
            int swap = _array[i];
            _array[i] = _array[i + 1];
            _array[i + 1] = swap;
        }
    }

    private void FillArray()
    {
        int startNumber = 0;
        int length = TotalIndexes;
        if (length % 2 == 1)
        {
            startNumber--;
            length++;
        }
        _array = Utils.FillArray(length, startNumber);
    }
}
