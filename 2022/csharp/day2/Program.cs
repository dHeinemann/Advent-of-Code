string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

int partATotalScore = 0;
int partBTotalScore = 0;
foreach (string round in File.ReadAllLines(filePath))
{
    partATotalScore += CalculatePartAScore(round);
    partBTotalScore += CalculatePartBScore(round);
}

Console.WriteLine($"Part A total score: {partATotalScore} points.");
Console.WriteLine($"Part B total score: {partBTotalScore} points.");

int CalculatePartAScore(string round)
{
    var moves = new Dictionary<char, Move>
    {
        { 'A', Move.Rock     },
        { 'B', Move.Paper    },
        { 'C', Move.Scissors },
        { 'X', Move.Rock     },
        { 'Y', Move.Paper    },
        { 'Z', Move.Scissors },
    };

    var outcomes = new Dictionary<(Move, Move), Outcome>
    {
        { (Move.Rock,     Move.Rock),     Outcome.Draw },
        { (Move.Rock,     Move.Paper),    Outcome.Win  },
        { (Move.Rock,     Move.Scissors), Outcome.Lose },
        { (Move.Paper,    Move.Rock),     Outcome.Lose },
        { (Move.Paper,    Move.Paper),    Outcome.Draw },
        { (Move.Paper,    Move.Scissors), Outcome.Win  },
        { (Move.Scissors, Move.Rock),     Outcome.Win  },
        { (Move.Scissors, Move.Paper),    Outcome.Lose },
        { (Move.Scissors, Move.Scissors), Outcome.Draw }
    };

    Move theirMove = moves[round[0]];
    Move myMove    = moves[round[2]];

    Outcome outcome = outcomes[(theirMove, myMove)];
    return (int)myMove + (int)outcome;
}

int CalculatePartBScore(string round)
{
    var moves = new Dictionary<char, Move>
    {
        { 'A', Move.Rock     },
        { 'B', Move.Paper    },
        { 'C', Move.Scissors }
    };
    
    var outcomes = new Dictionary<char, Outcome>
    {
        { 'X', Outcome.Lose },
        { 'Y', Outcome.Draw },
        { 'Z', Outcome.Win  }
    };

    var targetMoves = new Dictionary<(Move, Outcome), Move>
    {
        { (Move.Rock,     Outcome.Draw), Move.Rock     },
        { (Move.Rock,     Outcome.Win),  Move.Paper    },
        { (Move.Rock,     Outcome.Lose), Move.Scissors },
        { (Move.Paper,    Outcome.Lose), Move.Rock     },
        { (Move.Paper,    Outcome.Draw), Move.Paper    },
        { (Move.Paper,    Outcome.Win),  Move.Scissors },
        { (Move.Scissors, Outcome.Win),  Move.Rock     },
        { (Move.Scissors, Outcome.Lose), Move.Paper    },
        { (Move.Scissors, Outcome.Draw), Move.Scissors }
    };

    Move    theirMove      = moves[round[0]];
    Outcome desiredOutcome = outcomes[round[2]];
    Move    myMove         = targetMoves[(theirMove, desiredOutcome)];

    return (int)myMove + (int)desiredOutcome;
}

internal enum Move
{
    Rock     = 1,
    Paper    = 2,
    Scissors = 3
}

internal enum Outcome
{
    Lose = 0,
    Draw = 3,
    Win  = 6
}