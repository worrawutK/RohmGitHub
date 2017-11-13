using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.CellController
{
    using System.IO;
    using System.Threading;
    using System.Runtime.InteropServices;

    public class TextFileTestProgramAutoloader : ITestProgramAutoloader
    {

        private const string FILENAME_LOADINF = "loadinf.txt";

        private const string FILENAME_ANSINF = "loadans.txt";
        public event EventHandler AutoLoadTimedout;
        public event EventHandler AutoLoadFinished;
        public event EventHandler AutoLoadAborted;

        private Thread c_WorkerThread;

        private string c_MailboxDirectory;
        public string MailboxDirectory
        {
            get { return c_MailboxDirectory; }
            set { c_MailboxDirectory = value; }
        }

        private TimeSpan c_TimeoutDuration;
        public TimeSpan TimeoutDuration
        {
            get { return c_TimeoutDuration; }
            set { c_TimeoutDuration = value; }
        }

        private int c_CheckInterval;
        public int CheckInterval
        {
            get { return c_CheckInterval; }
            set { c_CheckInterval = value; }
        }

        private string c_LoadAnswer;
        public string LoadAnswer
        {
            get { return c_LoadAnswer; }
            set { c_LoadAnswer = value; }
        }


        private SynchronizationContext c_SyncContext;
        public TextFileTestProgramAutoloader()
        {
            c_SyncContext = SynchronizationContext.Current;
        }

        public void WriteLoadInformation(string mcNo, string channel, 
            string ftDevice, string testFlow, string packageName, 
            string testerType, string programName, string lotNo, string channelFlag)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(c_MailboxDirectory, FILENAME_LOADINF)))
            {
                writer.WriteLine(ftDevice + "," + testFlow + "," 
                    + packageName + "," + testerType + "," + programName 
                    + "," + lotNo + "," + DateTime.Now.ToString("yyyy/MM/dd") 
                    + "," + channel + "," + channelFlag + ",");
            }

            NeccessaryAutoloadData d = new NeccessaryAutoloadData();
            
            d.ExpectedAnswer = programName;
            d.Channel = channel;
            d.LotNo = lotNo;

            StartWaitThread(d);
        }

        public void AbortAutoLoad()
        {
            if (c_WorkerThread != null && c_WorkerThread.IsAlive)
            {
                c_WorkerThread.Abort();
                c_WorkerThread.Join(1000);
                c_WorkerThread = null;

                if (AutoLoadAborted != null)
                {
                    AutoLoadAborted(this, EventArgs.Empty);
                }
            }
        }
        
        private struct NeccessaryAutoloadData
        {
            public string ExpectedAnswer { get; set; }
            public string Channel { get; set; }
            public string LotNo { get; set; }
        }

        private void StartWaitThread(NeccessaryAutoloadData d)
        {
            c_WorkerThread = new Thread(WaitLoadAnswer);
            c_WorkerThread.IsBackground = true;
            c_WorkerThread.Start(d);
        }

        private void ClearMailBox(string mailBoxDirectory)
        {
            if (!Directory.Exists(mailBoxDirectory))
            {
                return;
            }

            string[] fs = Directory.GetFiles(mailBoxDirectory);

            foreach (string f in fs)
            {
                File.Delete(f);
            }

        }

        private void WaitLoadAnswer(object state)
        {
            NeccessaryAutoloadData d = (NeccessaryAutoloadData)state;
            TimeSpan t = default(TimeSpan);
            DateTime stamp = DateTime.Now;
            string fileName = Path.Combine(c_MailboxDirectory, FILENAME_ANSINF);

            do
            {
                LoadAnsResult result = TryGetLoadAns(fileName);
                if (result.IsOk)
                {
                    //delete all file in mail box
                    ClearMailBox(c_MailboxDirectory);
                    //if result program is same as OIS 
                    if (d.ExpectedAnswer == result.Answer)
                    {
                        string shortLotNo = d.LotNo.Substring(5);
                        switch (d.Channel)
                        {
                            case "A":
                                File.Create(Path.Combine(c_MailboxDirectory, "a" + shortLotNo + "ok.txt"));
                                break;
                            case "B":
                                File.Create(Path.Combine(c_MailboxDirectory, "b" + shortLotNo + "ok.txt"));
                                break;
                            case "AB":
                                File.Create(Path.Combine(c_MailboxDirectory, "a" + shortLotNo + "ok.txt"));
                                File.Create(Path.Combine(c_MailboxDirectory, "b" + shortLotNo + "ok.txt"));
                                break;
                            default:
                                break;
                        }
                    }

                    c_SyncContext.Post(PostAutoLoadFinished, result.Answer);
                    //exit function
                    return;
                }
                Thread.Sleep(c_CheckInterval);
                t = DateTime.Now.Subtract(stamp).Duration();
            } while (t.TotalSeconds < c_TimeoutDuration.TotalSeconds);

            c_SyncContext.Post(PostAutoLoadTimedout, null);
            c_WorkerThread = null;

        }

        private LoadAnsResult TryGetLoadAns(string fileName)
        {

            LoadAnsResult ret = new LoadAnsResult();
            ret.IsOk = false;

            if (File.Exists(fileName))
            {
            LB001:
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        ret.Answer = sr.ReadLine().Trim();
                    }
                }
                catch (IOException ex)
                {
                    //** i do not handle another error
                    int errorCode = Marshal.GetHRForException(ex) & ((1 << 16) - 1);
                    if (errorCode == 32 || errorCode == 33)
                    {
                        //file is being used by another process or tester
                        Thread.Sleep(1000);
                        goto LB001;
                    }
                    else
                    {
                        ret.Answer = ex.Message;
                    }
                }
                catch (Exception ex2)
                {
                    ret.Answer = ex2.Message;
                }

                ret.IsOk = true;
            }

            // if (File.Exists(e.FullPath))
            return ret;
        }

        private void PostAutoLoadFinished(object state)
        {
            c_LoadAnswer = (string)state;

            if (AutoLoadFinished != null)
            {
                AutoLoadFinished(this, EventArgs.Empty);
            }
        }

        private void PostAutoLoadTimedout(object state)
        {

            if (AutoLoadTimedout != null)
            {
                AutoLoadTimedout(this, EventArgs.Empty);
            }
        }

        private struct LoadAnsResult
        {

            private string c_Answer;
            public string Answer
            {
                get { return c_Answer; }
                set { c_Answer = value; }
            }

            private bool c_IsOk;
            public bool IsOk
            {
                get { return c_IsOk; }
                set { c_IsOk = value; }
            }

        }

        ~TextFileTestProgramAutoloader() {
            EventHandler.RemoveAll(AutoLoadFinished, AutoLoadFinished);
            if (c_WorkerThread != null && c_WorkerThread.IsAlive)
            {
                c_WorkerThread.Abort();
                c_WorkerThread.Join(1000);
                c_WorkerThread = null;
            }
        }

    }

}
