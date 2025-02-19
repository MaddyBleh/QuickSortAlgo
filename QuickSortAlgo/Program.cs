using System.Net.NetworkInformation;
using System.Reflection.Metadata;

static int Partition(int[] arr, int low, int high)
{

    // Middle index
    int middle = (low + high) / 2;

    // Find middle values of low, middle, and high portions
    int pivotIndex = low;
    if (arr[middle] < arr[low])
    {
        pivotIndex = middle;
    }
    if (arr[high] < arr[pivotIndex])
    {
        pivotIndex = high;
    }
    if (arr[middle] > arr[low])
    {
        pivotIndex = low;
    }

    // Pick pivot point and move to end of array
    int pivot = arr[pivotIndex];
    Swap(arr, pivotIndex, high);

    // Starts at -1, so the first element smaller than pivot makes i = 0.
    int i = low - 1;

    // Look through the list
    for (int j = low; j <= high - 1; j++)
    {
        // If the currently held number is less than the pivot point
        if (arr[j] < pivot)
        {
            // Increment i, then swap the 2 numbers
            i++;
            Swap(arr, i, j);
        }
    }

    // Place the pivot correctly
    Swap(arr, i + 1, high);
    return i + 1;
}

static void Swap(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

static void QuickSort(int[] arr, int low, int high)
{
    if (low < high)
    {
        int pi = Partition(arr, low, high);

        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
    }
}

int[] arr = { 2, 5, 8, 10, 6, 1, 3, 4, 9, 7, 12, 43, 51, 23, 67, 88, 101, 62, 75 };
int n = arr.Length;

QuickSort(arr, 0, n - 1);
foreach (int val in arr)
{
    Console.Write($"{val} ");
}