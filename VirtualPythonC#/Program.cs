// See https://aka.ms/new-console-template for more information
using Python.Runtime;

Console.WriteLine("Hello, World!");

var pathToVirtualEnv = @"D:\Dev\VirtualPythonC#\.conda\";

var path = Environment.GetEnvironmentVariable("PATH").TrimEnd(';');
path = string.IsNullOrEmpty(path) ? pathToVirtualEnv : path + ";" + pathToVirtualEnv;
Environment.SetEnvironmentVariable("PATH", path, EnvironmentVariableTarget.Process);
Environment.SetEnvironmentVariable("PATH", pathToVirtualEnv, EnvironmentVariableTarget.Process);
Environment.SetEnvironmentVariable("PYTHONHOME", pathToVirtualEnv, EnvironmentVariableTarget.Process);
Environment.SetEnvironmentVariable("PYTHONPATH", $"{pathToVirtualEnv}\\Lib\\site-packages;{pathToVirtualEnv}\\Lib", EnvironmentVariableTarget.Process);

Runtime.PythonDLL = pathToVirtualEnv + @"python311.dll";

PythonEngine.PythonHome = pathToVirtualEnv;
PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);

PythonEngine.Initialize();
dynamic sys = Py.Import("sys");
Console.WriteLine("Python version: " + sys.version);
