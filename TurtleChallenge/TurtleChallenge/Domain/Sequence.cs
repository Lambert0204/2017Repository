using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Domain
{
    public class Sequence
    {
        public int SequenceNo { get; set; }
        public string[] SequenceList { get; set; }

        public static Sequence SetSquence(int sequenceNo, string[] sequenceList)
        {
            return new Sequence
            {
                SequenceNo = sequenceNo,
                SequenceList = sequenceList
            };
        }
    }
}
