using System;

namespace lab_rob_5
{
    class Training
    {
        public int ID { get; private set; }
        public string Training_topic { get; private set; }
        public DateTime Start_Date { get; private set; }
        public DateTime Finish_Date { get; private set; }
        public int Coach_ID { get; private set; }

        public string Topic { get; private set; }

        public Training(int id, string topic, int coach_id, DateTime start = default(DateTime), DateTime finish = default(DateTime))
        {
            ID = id;
            Training_topic = topic;
            Start_Date = start;
            Finish_Date = finish;
            Coach_ID = coach_id;
        }


    }
}
