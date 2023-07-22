using System;
using System.Linq;

public class Program
{
    // Sigmoid function to normalize inputs
    public static double Sigmoid(double x)
    {
        return 1 / (1 + Math.Exp(-x));
    }

    // Sigmoid derivatives to adjust synaptic weights
    public static double SigmoidDerivative(double x)
    {
        return x * (1 - x);
    }

    public static void Main()
    {
        double[,] trainingInputs = new double[,]
        {
            {0, 0, 1},
            {1, 1, 1},
            {1, 0, 1},
            {0, 1, 1}
        };

        double[,] trainingOutputs = new double[,]
        {
            {0},
            {1},
            {1},
            {0}
        };

        // Initialize weights randomly with mean 0 to create weight matrix, synaptic weights
        double[,] synapticWeights = new double[3, 1];
        Random random = new Random(1);
        for (int i = 0; i < 3; i++)
        {
            synapticWeights[i, 0] = 2 * random.NextDouble() - 1;
        }

        Console.WriteLine("Random starting synaptic weights:");
        PrintMatrix(synapticWeights);

        double[,] outputs = null;

        // Iterate 10,000 times
        for (int iteration = 0; iteration < 10000; iteration++)
        {
            // Define input layer
            double[,] inputLayer = trainingInputs;

            // Normalize the product of the input layer with the synaptic weights
            outputs = new double[inputLayer.GetLength(0), synapticWeights.GetLength(1)];
            for (int i = 0; i < inputLayer.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < synapticWeights.GetLength(0); j++)
                {
                    sum += inputLayer[i, j] * synapticWeights[j, 0];
                }
                outputs[i, 0] = Sigmoid(sum);
            }

            // How much did we miss?
            double[,] error = new double[outputs.GetLength(0), outputs.GetLength(1)];
            for (int i = 0; i < outputs.GetLength(0); i++)
            {
                error[i, 0] = trainingOutputs[i, 0] - outputs[i, 0];
            }

            // Multiply how much we missed by the slope of the sigmoid at the values in outputs
            double[,] adjustments = new double[outputs.GetLength(0), outputs.GetLength(1)];
            for (int i = 0; i < outputs.GetLength(0); i++)
            {
                adjustments[i, 0] = error[i, 0] * SigmoidDerivative(outputs[i, 0]);
            }

            // Update weights
            double[,] inputLayerTransposed = TransposeMatrix(inputLayer);
            double[,] weightAdjustments = MultiplyMatrices(inputLayerTransposed, adjustments);
            synapticWeights = AddMatrices(synapticWeights, weightAdjustments);
        }

        Console.WriteLine("Synaptic weights after training:");
        PrintMatrix(synapticWeights);

        Console.WriteLine("Output After Training:");
        PrintMatrix(outputs);
    }

    // Helper method to transpose a matrix
    public static double[,] TransposeMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        double[,] result = new double[columns, rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[j, i] = matrix[i, j];
            }
        }
        return result;
    }

    // Helper method to multiply two matrices
    public static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int columns1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int columns2 = matrix2.GetLength(1);

        if (columns1 != rows2)
        {
            throw new ArgumentException("Invalid dimensions for matrix multiplication.");
        }

        double[,] result = new double[rows1, columns2];
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < columns2; j++)
            {
                double sum = 0;
                for (int k = 0; k < columns1; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    // Helper method to add two matrices
    public static double[,] AddMatrices(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int columns = matrix1.GetLength(1);
        double[,] result = new double[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    // Helper method to print a matrix
    public static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
