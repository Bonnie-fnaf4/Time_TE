using System;

[Serializable]
public class TimeData
{
    [Serializable]
    public class Data
    {
        public double now;
    }

    public Data currentData =  new Data();

}
