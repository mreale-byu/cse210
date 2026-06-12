//---------------------------------------------------------------------------------
// CSE210 - Trophy.cs
// Author: Mauricio Reale
//
// Description:
//
//   1) Displays a trophy ASCII art when the user completes all checklist tasks. 
//      This is a way to achieve some sort of gamification and make the program 
//      more appealing.
//
//--------------------------------------------------------------------------------    

public static class Trophy
{
    private const string _art =
@" __________
 '.       .'
  _\:.   /_
 //|::   |\\
 \\|::   |//
  `\::.  /`
    `\ /`
      T
   __/ \__
  |       |
 _| BONUS |_
|  POINTS!  |
-------------";

    public static void Display()
    {
        Console.WriteLine(_art);
    }
}