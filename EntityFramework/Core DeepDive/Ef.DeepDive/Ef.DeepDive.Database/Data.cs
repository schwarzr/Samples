using System;
using System.Collections.Generic;
using System.Text;
using Ef.DeepDive.Database.Model;

namespace Ef.DeepDive.Database
{
    public class Data
    {
        public static IEnumerable<Speaker> CreateSpeakers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Speaker
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"Angry",
                    LastName = $"Coder {i}",
                    Company = i % 2 == 0 ? $"coder company {i}" : null
                };
            }
        }

        public static IEnumerable<Session> CreateSessions(IList<Speaker> speakers, int count)
        {
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                yield return new Session
                {
                    Id = Guid.NewGuid(),
                    Title = $"Demo Session {i}",
                    Description = $"Demo Session Description {i}",
                    Rating = Convert.ToDecimal(random.NextDouble()),
                    SpeakerId = speakers[random.Next(speakers.Count)].Id
                };
            }
        }

    }
}
