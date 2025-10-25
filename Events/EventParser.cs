using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NeverlandAdventure.Events
{
    public static class EventParser
    {
        public static StructuredEvent Parse(string filePath)
        {
            var e = new StructuredEvent();

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Event-filen saknas: {filePath}");

            string[] lines = File.ReadAllLines(filePath);

            string currentSection = "";
            foreach (var line in lines)
            {
                string trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed)) continue;

                if (trimmed.StartsWith("Björn") || trimmed.StartsWith("Namn"))
                    e.Name = trimmed.Replace("Namn:", "").Trim();
                else if (trimmed.StartsWith("Trigger:"))
                    e.Trigger = trimmed.Replace("Trigger:", "").Trim();
                else if (trimmed.StartsWith("Spelarens sannolikhet"))
                {
                    var match = Regex.Match(trimmed, @"(\d+)%");
                    if (match.Success) e.BaseChance = int.Parse(match.Groups[1].Value) / 100.0;
                }
                else if (trimmed.StartsWith("Val:"))
                    currentSection = "Choices";
                else if (trimmed.StartsWith("Händelse/resultat:"))
                    currentSection = "Outcome";
                else if (trimmed.StartsWith("Statusrapport:"))
                    currentSection = "Status";
                else if (trimmed.StartsWith("Uppdrag efteråt:"))
                    currentSection = "Followup";
                else
                {
                    switch (currentSection)
                    {
                        case "Choices":
                            if (trimmed.StartsWith("Försök") || trimmed.StartsWith("Göm"))
                                e.Choices.Add(trimmed);
                            break;
                        case "Outcome":
                            if (trimmed.StartsWith("Lyckas"))
                                e.SuccessOutcome = trimmed;
                            else if (trimmed.StartsWith("Misslyckas"))
                                e.FailureOutcome = trimmed;
                            break;
                        case "Status":
                            e.StatusReport = trimmed.Replace("Statusrapport:", "").Trim();
                            break;
                        case "Followup":
                            e.FollowupNPCs.AddRange(trimmed.Split(',').Select(x => x.Trim()));
                            break;
                    }
                }
            }

            return e;
        }
    }
}