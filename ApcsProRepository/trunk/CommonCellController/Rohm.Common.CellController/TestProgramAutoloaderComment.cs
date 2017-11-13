using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.CellController
{
    using System.IO;

    public class TestProgramAutoloaderComment : ITestProgramAutoloader
    {


        private ITestProgramAutoloader c_Loader;
        public TestProgramAutoloaderComment(ITestProgramAutoloader loader)
        {
            c_Loader = loader;
        }

        private string c_CommentText;
        public string CommentText
        {
            get { return c_CommentText; }
            set { c_CommentText = value; }
        }

        private string c_CommentFileName;
        public string CommentFileName
        {
            get { return c_CommentFileName; }
            set { c_CommentFileName = value; }
        }


        public void WriteLoadInformation(string mcNo, string channel, string ftDevice, string testFlow, string packageName, string testerType, string programName, string lotNo, string channelFlag)
        {
            using (StreamWriter writer = new StreamWriter(c_CommentFileName, true))
            {
                writer.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ":" + c_CommentText);
            }

            c_Loader.WriteLoadInformation(mcNo, channel, ftDevice, testFlow, packageName, testerType, programName, lotNo, channelFlag);

        }
    }
}
