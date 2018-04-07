using System;
using System.Linq;
using System.Reflection;

namespace IteratorTest
{
    class Program
    {
        
            public static void Main()
            {
                ExecuteCommands();
            }

            private static void ExecuteCommands()
            {
                var InitializationArgs = Console.ReadLine().Split();
                var list = new ListIterator(InitializationArgs.Skip(1));

                var iteratorMethods = list.GetType().GetMethods();

                var command = Console.ReadLine();

                while (command != "END")
                {
                    try
                    {
                        var parsedMethod = iteratorMethods
                            .FirstOrDefault(m => m.Name == command);

                        if (parsedMethod == null)
                        {
                            Console.WriteLine($"This type of command - {command} does not exists");
                        }

                        Console.WriteLine(parsedMethod.Invoke(list, new object[] { }));
                    }
                    catch (TargetInvocationException tie)
                    {
                        if (tie.InnerException is InvalidOperationException)
                        {
                            Console.WriteLine(tie.InnerException.Message);
                        }
                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine(ane.Message);
                    }

                    command = Console.ReadLine();
                }
            }
    }
}
