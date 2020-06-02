using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MenuFramework;

namespace Logging
{
    public class Logger
    {
        // TO USE CREATE INSTANCE AND USE RunLogger()
        // set your preferred file Path below vvvvvvvv
        private string LogPath = @"C:current";
        /// <summary>
        /// TODO allow multiple log files with *configurable location
        /// </summary>

        DateTime CurrentTime = DateTime.Now;
        private Menu MainMenu = new Menu(3);
        private Menu DisplayLog = new Menu(0);
        private Menu LogInput = new Menu(2);
       

        public Logger()
        {
            MainMenu.SetHeaderPrompt("Main Menu");
            MainMenu.addMethod(showLog, "Show Log"); 
            MainMenu.addMethod(addLog, "Add Log");
            DisplayLog.SetHeaderPrompt("Log");
            MainMenu.addMethod(MainMenu.exitMenuLoop, "Quit");
        }

        private bool showLog()
        {
            try
            {
                DisplayLog.SetBodyText(File.ReadAllText(LogPath));
            }
            catch (Exception)
            {
                RunLogger();
            }
           
            DisplayLog.runMenu();
            return true;
        }
        private bool addLog()
        {
            string addendum;
            DateTime CurrentTime = DateTime.Now;
            LogInput.SetHeaderPrompt("New Entry:");
            LogInput.runMenu(out addendum);
            File.AppendAllText(LogPath, "\n" + CurrentTime + ": " + addendum);
            string logReadOut = File.ReadAllText(LogPath);
            return true; // TODO set to return true if file edit successful
        }
          public void RunLogger()
        {
            MainMenu.runMenu();
        }
    }// end logger Class
}
