﻿namespace LeagueTables.Models.Team;

public class TeamTableScoreModel
{
    public Guid TeamId { get; set; }

    public string TeamName { get; set; } = string.Empty;

    public int MatchesPlayed { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Draws { get; set; }

    public int GoalsFor { get; set; }

    public int GoalsAgainst { get; set; }

    public int GoalsDifference { get; set; }

    public int Points { get; set; }
}
