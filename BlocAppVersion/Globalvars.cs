using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlocAppVersion
{
    class Globalvars
    {

        private static string _nomFichierSchedules = "Schedules.txt";
       
        private static string _folderSchedulerRootName = "SetupBlockApp";
        private static int _allTaskCreated;
        private static string _taskName = "AppBlock";
        private static List<Form> _listForms;

        private static string _appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string _filePath = Path.Combine(_appDataLocal, Globalvars.NOMFICHIERSCHEDULES);

        private static string _programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        private static string _projetName = Path.Combine(_programFiles, _folderSchedulerRootName);
       


        public static string ProjetNamePath
        {
            get => _projetName;
        }
        public static List<Form> ListForms
        {
            get => _listForms;
            set => _listForms = value;
        }

        public static string NOMFICHIERSCHEDULES
        {
            get => _nomFichierSchedules;
        }
        public static string PATHFICHIERSCHEDULES
        {
            get => _filePath;
          
        }

        public static string ROOTFOLDERSCHEDULERNAME
        {
            get => _folderSchedulerRootName;
        }

        public static int ALLTASKCREATED
        {
            get => _allTaskCreated;
            set => _allTaskCreated = value;
        }

        public static string TASKNAME
        {
            get => _taskName;
        }
    }
}
