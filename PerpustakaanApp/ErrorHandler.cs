using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerpustakaanApp;

public class ErrorHandler
{
    public static void HandleError(string errorMessage)
    {
        Console.WriteLine($"Error: {errorMessage}");
    }
}

