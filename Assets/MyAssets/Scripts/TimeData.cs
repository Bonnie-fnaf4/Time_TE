using System;

[Serializable]
public class TimeData
{
    [Serializable]
    public class Data
    {
        public long time;
        public string clocks;
    }

    public Data currentData =  new Data();

}
