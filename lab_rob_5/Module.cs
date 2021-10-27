using System;

namespace lab_rob_5
{
    class Module
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public DateTime Event_date { get; private set; }
        public DateTime Duration { get; private set; }
        public int Training_ID { get; private set; }

        public Module(int id, string name, int training_id, DateTime date = default(DateTime), DateTime duration = default(DateTime))
        {
            ID = id;
            Name = name;
            Event_date = date;
            Duration = duration;
            Training_ID = training_id;
        }
    }
}
