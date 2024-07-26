// See https://aka.ms/new-console-template for more information
using Python.Runtime;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

string pathToVirtualEnv = "";
if (Debugger.IsAttached)
{
    pathToVirtualEnv = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + @"\.conda\";
}

// be sure not to overwrite your existing "PATH" environmental variable.
var path = Environment.GetEnvironmentVariable("PATH").TrimEnd(';');
path = string.IsNullOrEmpty(path) ? pathToVirtualEnv : path + ";" + pathToVirtualEnv;
var process = EnvironmentVariableTarget.Process;
Environment.SetEnvironmentVariable("PATH", path, process);
Environment.SetEnvironmentVariable("PATH", pathToVirtualEnv, process);
Environment.SetEnvironmentVariable("PYTHONHOME", pathToVirtualEnv, process);
Environment.SetEnvironmentVariable("PYTHONPATH", $"{pathToVirtualEnv}\\Lib\\site-packages;{pathToVirtualEnv}\\Lib", process);

Runtime.PythonDLL = pathToVirtualEnv + @"python311.dll";

PythonEngine.PythonHome = pathToVirtualEnv;
PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);

PythonEngine.Initialize();
dynamic sys = Py.Import("sys");
Console.WriteLine("Python version: " + sys.version);
