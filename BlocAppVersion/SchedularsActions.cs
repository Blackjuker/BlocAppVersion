using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.Win32.TaskScheduler;

namespace BlocAppVersion
{
    class SchedularsActions
    {
        string[] lines;
        public SchedularsActions()
        {
             lines = File.ReadAllLines(Globalvars.PATHFICHIERSCHEDULES);
          

            if (IsFolderExist())
            {
                DeleteRootFolderAndTask(lines.Length);
                SchedulerStart1();
            }
            else
            {
                SchedulerStart1();
            }
        }
        public void SchedularCreation()
        {
            try
            {
                string[] lines = File.ReadAllLines(Globalvars.PATHFICHIERSCHEDULES);
                foreach (string line in lines)
                { 
                    Console.WriteLine(line);
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "schtasks.exe",
                            Arguments = $"/create /tn TaskName_{line} /tr {Globalvars.PATHFICHIERSCHEDULES} /sc hourly /st {line}:00",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = false
                        }
                    };
                    process.Start();
                    //process.WaitForExit();
                    //process = new Process
                    //{
                    //    StartInfo = new ProcessStartInfo
                    //    {
                    //        FileName = "schtasks.exe",
                    //        Arguments = $"/delete /tn TaskName_{line} /f",
                    //        UseShellExecute = false,
                    //        RedirectStandardOutput = true,
                    //        CreateNoWindow = true
                    //    }
                    //};
                    //process.Start();
                }
                Console.WriteLine("Tasks created and deleted."+Globalvars.PATHFICHIERSCHEDULES);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void SchedulerStart()
        {
            try
            {
                TaskDefinition td;
                TaskService ts;
                string[] lines = File.ReadAllLines(Globalvars.PATHFICHIERSCHEDULES);
                foreach (string line in lines)
                {
                    ts = new TaskService();
                    td = ts.NewTask();
                    td.RegistrationInfo.Author = "Arnaud NGABGNA tel 0033695001446";
                    td.RegistrationInfo.Description = "This app bloc the screen";
                    string[] timeParts = line.Split(':');
                    int hours = int.Parse(timeParts[0]);
                    int minutes = int.Parse(timeParts[1]);

                    LogonTrigger trigger = new LogonTrigger();
                    trigger.Repetition.Interval = TimeSpan.FromDays(1);
                    trigger.StartBoundary = DateTime.Today + new TimeSpan(hours, minutes, 0);

                    ExecAction action = new ExecAction(@Globalvars.PATHFICHIERSCHEDULES, null, null);


                    td.Triggers.Add(trigger);
                    td.Actions.Add(action);


                    ts.RootFolder.RegisterTaskDefinition(@"AppBlock", td);
                }
                Console.WriteLine("Tasks created and deleted." + Globalvars.PATHFICHIERSCHEDULES);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


        public void SchedulerStart1()
        {
            try
            {
                TaskDefinition td;
                TaskService ts;
                int i = 1;
               
                var folder = TaskService.Instance.RootFolder.CreateFolder(Globalvars.ROOTFOLDERSCHEDULERNAME);

                foreach (string line in lines)
                {
                    ts = new TaskService();
                    td = ts.NewTask();
                    td.RegistrationInfo.Author = "Arnaud NGABGNA tel 0033695001446";
                    td.RegistrationInfo.Description = "This app bloc the screen";
                    string[] timeParts = line.Split(':');
                    int hours = int.Parse(timeParts[0]);
                    int minutes = int.Parse(timeParts[1]);

                   
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 1, StartBoundary = DateTime.Today + new TimeSpan(hours, minutes, 0) });
                    td.Actions.Add(new ExecAction(Globalvars.ProjetNamePath + @"\BlocAppVersion.exe", null, null));

                    folder.RegisterTaskDefinition(Globalvars.TASKNAME+ i.ToString(), td);

                    i++;
                }
             


               
              //  Console.WriteLine("Tasks created and deleted." + Globalvars.PATHFICHIERSCHEDULES);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

       private bool IsFolderExist()
        {

            // Connect to the root task folder
            TaskService taskService1 = new TaskService();
            TaskFolder rootFolder1 = taskService1.RootFolder;

            // Check if the folder already exists
            bool folderExists = rootFolder1.SubFolders.Any(f => f.Name == Globalvars.ROOTFOLDERSCHEDULERNAME);
            if (folderExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteRootFolderAndTask(int allTasks)
        {
           
            TaskService ts = TaskService.Instance;
            TaskFolder folder = ts.GetFolder("\\"+Globalvars.ROOTFOLDERSCHEDULERNAME);

            //for (int i = 1; i <= allTasks; i++)
            //{
            //    folder.DeleteTask(Globalvars.TASKNAME + i.ToString());
            //}
            foreach(Task task in folder.GetTasks(null))
            {
                folder.DeleteTask(task.Name);
            }

            DeleteRootFolder();
        }

        private void DeleteRootFolder()
        {
            using (TaskService ts = new TaskService())
            {
                TaskFolder rootFolder = ts.GetFolder("\\");
                rootFolder.DeleteFolder(Globalvars.ROOTFOLDERSCHEDULERNAME, true);
            }
        }


    }
}
