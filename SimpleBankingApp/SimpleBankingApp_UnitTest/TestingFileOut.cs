using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleBankingApp_UnitTest
{
    public class TestingFileOut
    {
        public String FilePath { get; private set; }
        public String MethodName { get; private set; }
        public String FullFilePath { get; private set; }

        public TestingFileOut()
        {
            this.FilePath = "..\\..\\TestingOutput\\";
        }

        public TestingFileOut(String filePath)
        {
            this.FilePath = filePath;
        }

        public TestingFileOut(String filePath, String methodName)
        {
            this.FilePath = filePath;
            this.MethodName = methodName;
        }

        private void FileCreate()
        {
            this.FullFilePath = this.FilePath + MethodName + ".txt";
            CreateFile();
            WriteLine(MethodName);
        }

        public void SetMethodName(String methodName)
        {
            this.MethodName = methodName;
            FileCreate();
        }

        private void CreateFile()
        {

            if (!File.Exists(FullFilePath))
            {
                File.Create(FullFilePath).Close();
            }
            else
            {
                File.WriteAllText(FullFilePath, String.Empty);
            }
        }

        public void WriteLine(String input)
        {
            if(MethodName == null)
            {
                throw new ArgumentNullException();
            }
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(FullFilePath, append: true))
            {
                file.WriteLine(input.ToString());
                file.Close();
            }
        }
    }
}
