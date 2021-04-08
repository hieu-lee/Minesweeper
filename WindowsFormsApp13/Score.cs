using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp13
{
    public class Score : IComparable<Score>
    {
        private Dictionary<string, int> difficulty = new Dictionary<string, int>() {
            { "easy", 0 },
            { "normal", 1},
            { "expert", 2} };

        [BsonId]
        public ObjectId Id;

        [BsonElement("username")]
        public string Username { get; set; }
        
        [BsonElement("mode")]
        public string Mode { get; set; }

        [BsonElement("time (seconds)")]
        public int Time { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            string res = "At " + Date.ToString() + ", username: " + Username + " won, mode: " + Mode + ", time: " + Time;
            return res;
        }

        public int CompareTo(Score other)
        {
            switch (difficulty[this.Mode].CompareTo(difficulty[other.Mode]))
            {
                case (1):
                    return 1;
                case (-1):
                    return -1;
            }
            return - this.Time.CompareTo(other.Time);
        }

        public static bool operator >(Score score1, Score score2)
        {
            return score1.CompareTo(score2) == 1;
        }

        public static bool operator <(Score score1, Score score2)
        {
            return score1.CompareTo(score2) == -1;
        }

        public static bool operator ==(Score score1, Score score2)
        {
            return score1.CompareTo(score2) == 0;
        }

        public static bool operator !=(Score score1, Score score2)
        {
            return score1.CompareTo(score2) != 0;
        }

        public static bool operator >=(Score score1, Score score2)
        {
            return score1.CompareTo(score2) >= 0;
        }

        public static bool operator <=(Score score1, Score score2)
        {
            return score1.CompareTo(score2) <= 0;
        }

        public override int GetHashCode()
        {
            return Time.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Score other = (Score)obj;
            return this == other;
        }
    }
}
