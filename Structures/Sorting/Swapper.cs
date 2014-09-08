namespace Structures.Sorting
{
    public class Swapper
    {
        public static void Swap<T>(T[] array, int i, int j)
        {
            var aux = array[i];
            array[i] = array[j];
            array[j] = aux;
        }
    }
}