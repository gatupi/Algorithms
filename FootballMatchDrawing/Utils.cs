using System.Text;

namespace FootballMatchDrawing;

static partial class Utils {

    public static T? GetRandomItem<T>(this IEnumerable<T> items) {

        if (!items.Any()) return default;
        return items.ElementAt(new Random().Next(0, items.Count()));
    }

    public static T? GetRandomItem<T>(this IEnumerable<T> items, IEnumerable<int> removeIndexes) {

        var newList = items.ToList();
        newList.RemoveAll(item => removeIndexes.Contains(items.ToList().IndexOf(item)));
        return newList.GetRandomItem();
    }

    public static void Shuffle<T>(this T[] list) {
        var rng = new Random();
        int n = list.Length;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static string Stringify(this IEnumerable<Match> matches) {
        var sb = new StringBuilder();
        var index = 0;
        foreach (var match in matches) {
            sb.Append($"{(index++ + 1).ToString().PadLeft(3, ' ')}. {match?.HomeTeam.Name} x {match?.AwayTeam.Name}\n");
        }

        return sb.ToString();
    }

    public static string ToArrayString<T>(this T[] array) {
        if (array.Length == 0) return "[]";
        var sb = new StringBuilder("[");
        for (int i = 0; i < array.Length - 1; i++) {
            sb.Append($"{array[i]}, ");
        }
        return sb.Append($"{array[^1]}]").ToString();
    }

    public static string ToMatrixString<T>(this T[,] matrix) {
        var sb = new StringBuilder();
        for (int i = 0; i < matrix.GetLength(0); i++) {
            sb.Append(matrix.GetRow(i).ToArrayString() + "\n");
        }

        return sb.ToString();
    }

    public static T[] GetRow<T>(this T[,] matrix, int row) {

        int length = matrix.GetLength(1);
        T[] array = new T[length];
        for (int i = 0; i < length; i++) {
            array[i] = matrix[row, i];
        }

        return array;
    }

    public static void SetRow<T>(this T[,] matrix, int row, T[] items) {
        if (matrix.GetLength(1) != items.Length) {
            throw new Exception($"Array length is different from matrix number of columns");
        }
        for (int i = 0; i < items.Length; i++) {
            matrix[row, i] = items[i];
        }
    }

    public static void ShuffleRow<T>(this T[,] matrix, int row) {
        var items = matrix.GetRow(row);
        items.Shuffle();
        matrix.SetRow(row, items);
    }

    public static int[] FillArray(int length, int startNumber = 1, int increment = 1) {

        return new int[length].Fill(startNumber, increment);
    }

    public static int[] Fill(this int[] array, int startNumber = 1, int increment = 1) {
        for (int i = 0; i < array.Length; i++) {
            array[i] = startNumber + i * increment;
        }
        return array;
    }

    public static T[] GetCopy<T>(this T[] array) {
        T[] copy = new T[array.Length];
        array.CopyTo(copy, 0);
        return copy;
    }
}
