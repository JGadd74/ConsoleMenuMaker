using System;


namespace MenuFramework
{
    class Program
    {

        static int nmbr = 0;
        static Menu TestMenu = new Menu(MenuType.NmbrChoices, "Test " + Convert.ToString(nmbr));

        static bool updateSelection()
        {
            nmbr = TestMenu.GetCurrentScrollSelection();
            TestMenu.SetHeaderPrompt("Test " + Convert.ToString(nmbr));
            return true;
        }
        static void Main(string[] args)
        {

            TestMenu.addMethod(updateSelection, "Test");
            TestMenu.addMethod(updateSelection, "Test");


            TestMenu.runMenu();
            
        }

     
    }
}
