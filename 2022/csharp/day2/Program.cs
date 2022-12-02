string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");

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

int totalScore = 0;
foreach (string round in File.ReadAllLines(filePath))
{
    Move theirMove = moves[round[0]];
    Move myMove    = moves[round[2]];
    totalScore += (int)myMove;

    Outcome outcome = outcomes[(theirMove, myMove)];
    totalScore += (int)outcome;
}

Console.WriteLine($"Total score: {totalScore} points.");

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