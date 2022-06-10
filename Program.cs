using Cocona;
using NLipsum.Core;

Dictionary<string, string> LipsumsByLanguage = 
    new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
    {
        ["en"] = Lipsums.TheRaven,
        ["es"] = Lipsums.TierrayLuna,
        ["de"] = Lipsums.InDerFremde,
        ["fr"] = Lipsums.LeBateauIvre
    };


CoconaApp.Run((string? language, int? numberOfParagraphs) => 
{
    var selectedLipsum = LipsumsByLanguage.GetValueOrDefault(
        language?? "default", 
        Lipsums.LoremIpsum);
    
    var lipsumGenerator = new LipsumGenerator(selectedLipsum, false);
    var generated = lipsumGenerator.GenerateParagraphs(numberOfParagraphs ?? 1);

    Console.WriteLine(string.Join("\n\n", generated));
});