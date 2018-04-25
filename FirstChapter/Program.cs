using System;
using UseExtension;

namespace FirstChapter
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Chapter1 chapter1 = new Chapter1();
            chapter1.Run();
            
            var extensionHelper = new ExtensionHelperTesting();
            extensionHelper.useStringExtensionMethod();
        }
    }
}