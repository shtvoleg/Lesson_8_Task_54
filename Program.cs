// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] FillArray(int[,] matr, int lBound, int hBound)           //  работа с матрицей - наполнение случайными целыми числами в заданном диапазоне
{
    for (int i = 0; i < matr.GetLength(0); i++)
        for (int j = 0; j < matr.GetLength(1); j++)
            matr[i, j] = new Random().Next(lBound, hBound);
    return matr;
}

int[,] WorkArray(int[,] matr)                                   //  работа с матрицей - упорядочение по убыванию построчно
{
    for (int i = 0; i < matr.GetLength(0); i++)                 //  цикл по строкам
        for (int j = 0; j < matr.GetLength(1); j++)             //  цикл по столбцам
            for (int k = j + 1; k < matr.GetLength(1); k++)     //  цикл по столбцам начиная от столбца (j+1)
                if (matr[i, k] > matr[i, j])                    //  если элемент в строке i в столбце k (последующего) больше находящегося в строке j (предыдущего),...
                    (matr[i, j], matr[i, k]) = (matr[i, k], matr[i, j]);        //  ... то меняем их местами
    return matr;                                                //  возврат изменённой матрицы по ссылке
}

void PrintArray(int[,] matr)                                    //  вывод матрицы в консоль
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
            Console.Write("\t" + matr[i, j]);
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.Clear();				                                //  очистка консоли
Console.WriteLine("Введите размерность по вертикали m: ");	    //  запрос размерности матрицы по вертикали
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите размерность по горизонтали n: ");	//  запрос размерности матрицы по вертикали
int n = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[m, n];
FillArray(matrix, 1, 100);                                      //  работа с массивом - наполнение случайными целыми числами в заданном диапазоне (от 1 до 100)
PrintArray(matrix);                                             //  вывод исходной матрицы, заполненной случайным образом, в консоль
WorkArray(matrix);                                              //  работа с матрицей
Console.WriteLine("Результат:");
PrintArray(matrix);                                             //  вывод обработанной матрицы в консоль