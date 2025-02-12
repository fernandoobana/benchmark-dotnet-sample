using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Text;

BenchmarkRunner.Run<StringsBenchmark>();

[MemoryDiagnoser]
public class StringsBenchmark
{
    [Benchmark]
    public void StringInterpolation()
    {
        string text = "O rato roeu a roupa do";
        string name = "João";
        string surname = "da Silva";
        string result = $"{text} {name} {surname}";
    }

    [Benchmark]
    public void StringFormat()
    {
        string text = "O rato roeu a roupa do";
        string name = "João";
        string surname = "da Silva";
        string result = string.Format("{0} {1} {2}", text, name, surname);
    }

    [Benchmark]
    public void StringConcatenation()
    {
        string text = "O rato roeu a roupa do";
        string name = "João";
        string surname = "da Silva";
        string result = text + " " + name + " " + surname;
    }

    [Benchmark]
    public void StringConcat()
    {
        string text = "O rato roeu a roupa do";
        string name = "João";
        string surname = "da Silva";
        string result = string.Concat(text, " ", name, " ", surname);
    }

    [Benchmark]
    public void StringReplace()
    {
        string text = "O rato roeu a roupa do @nome @sobrenome";
        string name = "João";
        string surname = "da Silva";
        string result = text.Replace("@nome", name).Replace("@sobrenome", surname);
    }

    [Benchmark]
    public void StringBuilder()
    {
        StringBuilder text = new();
        text.Append("O rato roeu a roupa do");
        text.Append(' ');
        text.Append("João");
        text.Append(' ');
        text.Append("da Silva");
        string result = text.ToString();
    }

    [Benchmark]
    public void StringReplaceWithManyCharacters()
    {
        // geralmente vamos trocar o texto por dados recebidos de algum outro objeto/classe que foi populado anteriormente
        var fillText = new FillText();

        string text = "What you've just clicked on, @boys and @girls, is the review to easily the most popular videogame ever to hit @nintendo's little black-and-white portable. The game has been available in the states since the end of 1998, but the original @Red and @Blue editions of Pokémon continue to sell like gangbusters. And there's a reason for that ¿ the game isn't just a fad. It's an awesome game worthy of any gamer's Game Boy library. In case you haven't noticed it, there's a little craze going on in the world with these guys known as Pokémon. It doesn't matter if you love 'em, hate 'em, or drop-kick 'em, you've at least heard of them, and they're not going away anytime soon. Pokémon started, believe it or not (and you'll be amazed at how many people don't realize it) as a Game Boy RPG back in 1996, in Japan. After two incredibly successful years as a game, a TV show, and a huge merchandise license, the big wigs at Nintendo decided to bring these little guys to the US. And guess what? It caught on like a cold. And chances are, you've caught it as well. Here's the deal in Pokémon: you're a kid named Ash (which can be changed within the game, but for now, you'll be known as Ash), who dreams of being a Pokémon master. So, you leave home to fulfill your dream. You'll travel from town to town, defeating each town's Gym master with the Pokémon you've captured and trained, until you earn all the badges necessary to be considered a Pokémon @Master.";
        string result = text
            .Replace("@boys", fillText.boys)
            .Replace("@sobrenome", fillText.girls)
            .Replace("@nintendo", fillText.girls)
            .Replace("@Red", fillText.red)
            .Replace("@Blue", fillText.blue)
            .Replace("@Master", fillText.master);
    }

    [Benchmark]
    public void StringBuilderWithManyCharacters()
    {
        // geralmente vamos trocar o texto por dados recebidos de algum outro objeto/classe que foi populado anteriormente
        var fillText = new FillText();

        StringBuilder text = new();
        text.Append("What you've just clicked on, ");
        text.Append(fillText.boys);
        text.Append(" and ");
        text.Append(fillText.girls);
        text.Append(", is the review to easily the most popular videogame ever to hit ");
        text.Append(fillText.nintendo);
        text.Append("'s little black-and-white portable. The game has been available in the states since the end of 1998, but the original ");
        text.Append(fillText.red);
        text.Append(" and ");
        text.Append(fillText.blue);
        text.Append(" editions of Pokémon continue to sell like gangbusters. And there's a reason for that ¿ the game isn't just a fad. It's an awesome game worthy of any gamer's Game Boy library. In case you haven't noticed it, there's a little craze going on in the world with these guys known as Pokémon. It doesn't matter if you love 'em, hate 'em, or drop-kick 'em, you've at least heard of them, and they're not going away anytime soon. Pokémon started, believe it or not (and you'll be amazed at how many people don't realize it) as a Game Boy RPG back in 1996, in Japan. After two incredibly successful years as a game, a TV show, and a huge merchandise license, the big wigs at Nintendo decided to bring these little guys to the US. And guess what? It caught on like a cold. And chances are, you've caught it as well. Here's the deal in Pokémon: you're a kid named Ash (which can be changed within the game, but for now, you'll be known as Ash), who dreams of being a Pokémon master. So, you leave home to fulfill your dream. You'll travel from town to town, defeating each town's Gym master with the Pokémon you've captured and trained, until you earn all the badges necessary to be considered a Pokémon ");
        text.Append(fillText.master);
        text.Append('.');
        string result = text.ToString();
    }
}

public class FillText
{
    public string boys = "boys";
    public string girls = "girls";
    public string nintendo = "nintendo";
    public string red = "Red";
    public string blue = "Blue";
    public string master = "Master";
}