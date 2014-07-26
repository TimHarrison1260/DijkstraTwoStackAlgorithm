using System;

namespace DijkstrasWeb.Models
{
    public class DijkstrasTwoStackAlgorithmModel
    {
        public DijkstrasTwoStackAlgorithmModel()
        {
            Expression = String.Empty;
            Answer = 0D;
            Message = string.Empty;
        }

        public string Expression { get; set; }
        public double Answer { get; set; }
        public string Message { get; set; }
    }
}