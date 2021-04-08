using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    static class Program
    {
        /// var client = new MongoClient("mongodb+srv://hieu_le:phamleha@cluster0.w5i0k.mongodb.net/<dbname>?retryWrites=true&w=majority");
        /// var database = client.GetDatabase("test");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
