//---------------------------------------------------------------------------------
// CSE210 - ScriptureLoader.cs
// Author: Mauricio Reale
//
// Represents a loader for scriptures, which initializes a list of scriptures and
// provides a method to randomly retrieve a scripture. Yes, in production code, 
// the data would likely be retrieved from a database or an external API, rather
// than being hardcoded. But, as its stands, this class serves the purpose of
// providing a simple way to manage and access a collection of scriptures for the
// Scripture Memorizer. Its use makes the main program cleaner and more focused
// on the user interaction and memorization logic, rather than on the details of
// how the scriptures are loaded and managed. 
//
//--------------------------------------------------------------------------------    

class ScriptureLoader
{
    private static readonly List<Scripture> _scriptures = [];

    static ScriptureLoader() // static constructor to initialize the list of scriptures
    {
        _scriptures.Add(new Scripture(new Reference("Amos", 3, 7), "Surely the Lord God will do nothing, but he revealeth his secret unto his servants the prophets."));
        _scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        _scriptures.Add(new Scripture(new Reference("Moroni", 7, 16), "For behold, the Spirit of Christ is given to every man, that he may know good from evil; wherefore, I show unto you the way to judge; for every thing which inviteth to do good, and to persuade to believe in Christ, is sent forth by the power and gift of Christ; wherefore ye may know with a perfect knowledge it is of God."));
        _scriptures.Add(new Scripture(new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."));    
        _scriptures.Add(new Scripture(new Reference("D&C", 88, 68), "Therefore, sanctify yourselves that your minds become single to God, and the days will come that you shall see him; for he will unveil his face unto you, and it shall be in his own time, and in his own way, and according to his own will."));
        _scriptures.Add(new Scripture(new Reference("D&C", 4, 1, 7), "Now behold, a marvelous work is about to come forth among the children of men. Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day. Therefore, if ye have desires to serve God ye are called to the work; For behold the field is white already to harvest; and lo, he that thrusteth in his sickle with his might, the same layeth up in store that he perisheth not, but bringeth salvation to his soul; And faith, hope, charity and love, with an eye single to the glory of God, qualify him for the work. Remember faith, virtue, knowledge, temperance, patience, brotherly kindness, godliness, charity, humility, diligence. Ask, and ye shall receive; knock, and it shall be opened unto you. Amen."));
        _scriptures.Add(new Scripture(new Reference("Articles of Faith", 1, 13), "We believe in being honest, true, chaste, benevolent, virtuous, and in doing good to all men; indeed, we may say that we follow the admonition of Paul—We believe all things, we hope all things, we have endured many things, and hope to be able to endure all things. If there is anything virtuous, lovely, or of good report or praiseworthy, we seek after these things."));
    }

    public static Scripture GetRandomScripture()
    {
        return _scriptures[new Random().Next(_scriptures.Count)];
    }
}